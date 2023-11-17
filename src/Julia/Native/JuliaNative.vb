Imports System.Runtime.InteropServices
Imports size_t = System.UIntPtr

Namespace Native

    Public Class JuliaNative
        Private Const LibraryName As String = "libjulia"

        Friend Shared LibPtr As IntPtr = IntPtr.Zero

        Public Shared Sub LoadDll(fileName As String)
            If RuntimeInformation.IsOSPlatform(OSPlatform.Windows) Then
                Windows.LoadJulia(fileName)
            ElseIf RuntimeInformation.IsOSPlatform(OSPlatform.Linux) Then
                Linux.LoadJulia(fileName)
            Else
                Throw New NotImplementedException
            End If
        End Sub


        <DllImport(LibraryName, EntryPoint:="jl_init__threading", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Sub Jl_init__threading()
        End Sub

        Public Shared InitThreading As JuliaInitDelegate = Nothing


        <DllImport(LibraryName, EntryPoint:="jl_atexit_hook", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Sub Jl_atexit_hook(status As Integer)
        End Sub
        Public Shared AtExitHook As JuliaAtExitHookDelegate = Nothing


        <DllImport(LibraryName, EntryPoint:="jl_eval_string", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Function Jl_eval_string(
    <MarshalAs(UnmanagedType.LPStr)> str As String) As IntPtr
        End Function
        Public Shared EvalString As JuliaEvalStringDelegate = Nothing


        <DllImport(LibraryName, EntryPoint:="jl_unbox_float64", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Function Jl_unbox_float64(v As IntPtr) As Double
        End Function
        Public Shared UnboxFloat64 As JuliaUnboxFloat64Delegate = Nothing


        <DllImport(LibraryName, EntryPoint:="jl_box_float64", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Function Jl_box_float64(x As Double) As IntPtr
        End Function
        Public Shared BoxFloat64 As JuliaBoxFloat64Delegate = Nothing


        <DllImport(LibraryName, EntryPoint:="jl_unbox_int64", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Function Jl_unbox_int64(v As IntPtr) As Long
        End Function
        Public Shared UnboxInt64 As JuliaUnboxInt64Delegate = Nothing


        <DllImport(LibraryName, EntryPoint:="jl_box_int64", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Function Jl_box_int64(x As Long) As IntPtr
        End Function
        Public Shared BoxInt64 As JuliaBoxInt64Delegate = Nothing


        <DllImport(LibraryName, EntryPoint:="jl_get_global", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Function Jl_get_global(m As IntPtr, var As IntPtr) As IntPtr
        End Function
        Public Shared GetGlobal As JuliaGetGlobalDelegate = Nothing

        <DllImport(LibraryName, EntryPoint:="jl_symbol", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Function Jl_symbol(
    <MarshalAs(UnmanagedType.LPStr)> str As String) As IntPtr
        End Function
        Public Shared Symbol As JuliaSymbolDelegate = Nothing

        Public Delegate Function JuliaGetFunctionDelegate(m As IntPtr, name As String) As IntPtr
        Public Shared GetFunction As JuliaGetFunctionDelegate = New JuliaGetFunctionDelegate(Function(m, name)
                                                                                                 Dim bstr = Symbol(name)
                                                                                                 Return GetGlobal(m, bstr)
                                                                                             End Function)


        <DllImport(LibraryName, EntryPoint:="jl_call1", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Function Jl_call1(f As IntPtr, a As IntPtr) As IntPtr
        End Function
        Public Shared Call1 As JuliaCall1Delegate = Nothing


        <DllImport(LibraryName, EntryPoint:="jl_apply_array_type", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Function Jl_apply_array_type(type As IntPtr, [dim] As size_t) As IntPtr
        End Function
        Public Shared ApplyArrayType As JuliaApplyArrayTypeDelegate = Nothing


        <DllImport(LibraryName, EntryPoint:="jl_alloc_array_1d", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Function Jl_alloc_array_1d(atype As IntPtr, nr As size_t) As IntPtr
        End Function
        Public Shared AllocArray1D As JuliaAllocArray1DDelegate = Nothing


        <DllImport(LibraryName, EntryPoint:="jl_alloc_array_2d", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Function Jl_alloc_array_2d(atype As IntPtr, nr As size_t, nc As size_t) As IntPtr
        End Function
        Public Shared AllocArray2D As JuliaAllocArray2DDelegate = Nothing

        Public Shared Float64Type As IntPtr
        Public Shared Int64Type As IntPtr
        Public Shared BaseModule As IntPtr

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