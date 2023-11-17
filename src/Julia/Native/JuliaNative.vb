Imports System.Runtime.InteropServices
Imports size_t = System.UIntPtr

Namespace Native

    Public Class JuliaNative

        Public Const LibraryName As String = "libjulia"

        Friend Shared LibPtr As IntPtr = IntPtr.Zero

        Public Shared InitThreading As JuliaInitDelegate = Nothing
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

        Private Shared Function JuliaGetFunction(m As IntPtr, name As String) As IntPtr
            Dim bstr = Symbol(name)
            Dim f = GetGlobal(m, bstr)

            Return f
        End Function

#Region "julia types"
        Public Shared Float64Type As IntPtr
        Public Shared Int64Type As IntPtr
        Public Shared BaseModule As IntPtr
#End Region

        Public Shared Sub LoadDll(fileName As String)
            If RuntimeInformation.IsOSPlatform(OSPlatform.Windows) Then
                Windows.LoadJulia(fileName)
            ElseIf RuntimeInformation.IsOSPlatform(OSPlatform.Linux) Then
                Linux.LoadJulia(fileName)
            Else
                Throw New NotImplementedException
            End If
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