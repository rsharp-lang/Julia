Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.ApplicationServices.DynamicInterop
Imports SMRUCC.Julia.Native.Platform
Imports SMRUCC.Julia.Native.Platform.clr
Imports jl_type_id = System.IntPtr

Namespace Native

    Public Class JuliaNative

        Public Const LibraryName As String = "libjulia"

        Friend Shared LibPtr As IntPtr = IntPtr.Zero
        Friend Shared Julia As UnmanagedDll
        Friend Shared Type As jlType

        Friend Shared julia_init__threading As julia_init__threading = Nothing

        Public Shared AtExitHook As JuliaAtExitHookDelegate = Nothing
        Public Shared EvalString As JuliaEvalStringDelegate = Nothing
        Public Shared UnboxFloat64 As JuliaUnboxFloat64Delegate = Nothing
        Public Shared BoxFloat64 As JuliaBoxFloat64Delegate = Nothing
        Public Shared UnboxInt64 As JuliaUnboxInt64Delegate = Nothing
        Public Shared BoxInt64 As JuliaBoxInt64Delegate = Nothing
        Public Shared GetGlobal As JuliaGetGlobalDelegate = Nothing
        Public Shared Symbol As JuliaSymbolDelegate = Nothing
        Public Shared ReadOnly GetFunction As JuliaGetFunctionDelegate = AddressOf JuliaGetFunction
        Public Shared Call1 As JuliaCall1Delegate = Nothing
        Public Shared ApplyArrayType As JuliaApplyArrayTypeDelegate = Nothing
        Public Shared AllocArray1D As JuliaAllocArray1DDelegate = Nothing
        Public Shared AllocArray2D As JuliaAllocArray2DDelegate = Nothing

        Public Shared julia_gc_collect As julia_gc_collect
        Public Shared julia_gc_enable As julia_gc_enable

        Private Shared Function JuliaGetFunction(m As IntPtr, name As String) As IntPtr
            Dim bstr = Symbol(name)
            Dim f = GetGlobal(m, bstr)

            Return f
        End Function

#Region "julia types"

        <TypeForward(GetType(Boolean))> Public Shared jl_bool_type As jl_type_id
        <TypeForward(GetType(Char))> Public Shared jl_char_type As jl_type_id
        <TypeForward(GetType(SByte))> Public Shared jl_int8_type As jl_type_id
        <TypeForward(GetType(Byte))> Public Shared jl_uint8_type As jl_type_id
        <TypeForward(GetType(Int16))> Public Shared jl_int16_type As jl_type_id
        <TypeForward(GetType(UInt16))> Public Shared jl_uint16_type As jl_type_id
        <TypeForward(GetType(Int32))> Public Shared jl_int32_type As jl_type_id
        <TypeForward(GetType(UInt32))> Public Shared jl_uint32_type As jl_type_id
        <TypeForward(GetType(Int64))> Public Shared jl_int64_type As jl_type_id
        <TypeForward(GetType(UInt64))> Public Shared jl_uint64_type As jl_type_id
        <TypeForward(GetType(Half))> Public Shared jl_float16_type As jl_type_id
        <TypeForward(GetType(Single))> Public Shared jl_float32_type As jl_type_id
        <TypeForward(GetType(Double))> Public Shared jl_float64_type As jl_type_id
        Public Shared jl_floatingpoint_type As jl_type_id
        Public Shared jl_number_type As jl_type_id
        Public Shared jl_void_type As jl_type_id
        Public Shared jl_nothing_type As jl_type_id

        Public Shared BaseModule As IntPtr
#End Region

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="fileName">
        ''' 1. file path to the ``bin\libjulia.dll`` on windows
        ''' 2. filepath to the file ``libjulia.so`` on linux platform
        ''' </param>
        Public Shared Sub LoadDll(fileName As String)
            Julia = New UnmanagedDll(fileName, UnixLibraryLoader.RTLD_NOW Or UnixLibraryLoader.RTLD_GLOBAL)
            LibPtr = Julia.LibraryHandle

            If RuntimeInformation.IsOSPlatform(OSPlatform.Windows) Then
                Windows.LoadJulia(Julia)
            ElseIf RuntimeInformation.IsOSPlatform(OSPlatform.Linux) Then
                Linux.LoadJulia(Julia)
            Else
                Throw New NotImplementedException
            End If

            ' get julia data type
            JuliaNative.jl_bool_type = Julia.GetFunctionAddress("jl_bool_type")
            JuliaNative.jl_char_type = Julia.GetFunctionAddress("jl_char_type")
            JuliaNative.jl_int8_type = Julia.GetFunctionAddress("jl_int8_type")
            JuliaNative.jl_uint8_type = Julia.GetFunctionAddress("jl_uint8_type")
            JuliaNative.jl_int16_type = Julia.GetFunctionAddress("jl_int16_type")
            JuliaNative.jl_uint16_type = Julia.GetFunctionAddress("jl_uint16_type")
            JuliaNative.jl_int32_type = Julia.GetFunctionAddress("jl_int32_type")
            JuliaNative.jl_uint32_type = Julia.GetFunctionAddress("jl_uint32_type")
            JuliaNative.jl_int64_type = Julia.GetFunctionAddress("jl_int64_type")
            JuliaNative.jl_uint64_type = Julia.GetFunctionAddress("jl_uint64_type")
            JuliaNative.jl_float16_type = Julia.GetFunctionAddress("jl_float16_type")
            JuliaNative.jl_float32_type = Julia.GetFunctionAddress("jl_float32_type")
            JuliaNative.jl_float64_type = Julia.GetFunctionAddress("jl_float64_type")
            JuliaNative.jl_floatingpoint_type = Julia.GetFunctionAddress("jl_floatingpoint_type")
            JuliaNative.jl_number_type = Julia.GetFunctionAddress("jl_number_type")
            JuliaNative.jl_void_type = Julia.GetFunctionAddress("jl_void_type")
            JuliaNative.jl_nothing_type = Julia.GetFunctionAddress("jl_nothing_type")
            JuliaNative.BaseModule = Julia.GetFunctionAddress("jl_base_module")

            ' jl_init__threading function must be called at very first!
            Call JuliaNative.julia_init__threading()
            Call JuliaNative.julia_gc_enable([on]:=1)
            Call JuliaNative.julia_gc_collect()

            Type = New jlType
        End Sub

        'struct JuliaModuleT
        '{
        '    //JL_DATA_TYPE
        '    IntPtr name;
        '    IntPtr parent;
        '    HTableT bindings;
        '    ArrayListT usings;
        '    byte istopmod;
        '    UInt64 uuid;
        '    size_t primary_world;
        '    UInt32 counter;
        '}

        Const HT_N_INLINE As Integer = 32

        'struct HTableT
        '{
        '    size_t size;
        '    IntPtr table;//void **table
        '    IntPtr _space;//void *_space[HT_N_INLINE]
        '}

        'struct ArrayListT
        '{
        '    size_t len;
        '    size_t max;
        '    IntPtr items;//void **items;
        '    IntPtr _space;//void *_space[AL_N_INLINE];
        '}

        'struct JlSymT
        '{
        '    IntPtr left;
        '    IntPtr right;
        '    UIntPtr hash;
        '}

        '    typedef struct _jl_module_t
        '    {
        '        JL_DATA_TYPE
        '        jl_sym_t* name;
        '        struct _jl_module_t *parent;
        '        htable_t bindings;
        '        arraylist_t usings;  // modules with all bindings potentially imported
        '        uint8_t istopmod;
        '        uint64_t uuid;
        '        size_t primary_world;
        '        uint32_t counter;
        '    }
        '    jl_module_t;


    End Class
End Namespace