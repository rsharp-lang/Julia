Imports System.IO
Imports System.Runtime.InteropServices
Imports size_t = System.UIntPtr

Public Class JuliaNative
    Private Const LibraryName As String = "libjulia"

    Const RTLD_NOW As Integer = &H2
    Const RTLD_GLOBAL As Integer = &H100
    <DllImport("libdl")>
    Private Shared Function dlopen(ByVal filename As String, ByVal flags As Integer) As IntPtr
    End Function
    <DllImport("libdl")>
    Protected Shared Function dlsym(ByVal handle As IntPtr, ByVal symbol As String) As IntPtr
    End Function

    <DllImport("kernel32.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Ansi)>
    Private Shared Function LoadLibrary(
    <MarshalAs(UnmanagedType.LPStr)> ByVal filename As String) As IntPtr
    End Function

    <DllImport("Kernel32.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Ansi)>
    Private Shared Function GetProcAddress(ByVal hModule As IntPtr,
    <MarshalAs(UnmanagedType.LPStr)> ByVal lpProcName As String) As IntPtr
    End Function

    <DllImport("Kernel32.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Ansi)>
    Private Shared Function FreeLibrary(ByVal hModule As IntPtr) As Boolean
    End Function

    Private Shared LibPtr As IntPtr = IntPtr.Zero

    Shared Sub New()
        Debug.WriteLine("OSArchitecture:{0}", RuntimeInformation.OSArchitecture)

        Try
            Dim arch = "x64"
            If RuntimeInformation.OSArchitecture = Architecture.X64 Then
                '仅支持64位
                arch = "x64"
            Else
                Debug.WriteLine("仅支持64位")
            End If

            If RuntimeInformation.IsOSPlatform(OSPlatform.Windows) Then
                Dim libName = "C:\Users\Administrator\AppData\Local\Programs\Julia-1.9.4\bin\libjulia.dll" ' Path.Combine(AppContext.BaseDirectory, "julia", $"win-{arch}", $"{LibraryName}.dll")
                Debug.WriteLine($"windows:{libName}")
                LibPtr = LoadLibrary(libName)

                InitThreading = AddressOf Jl_init__threading
                AtExitHook = AddressOf Jl_atexit_hook
                EvalString = AddressOf Jl_eval_string
                UnboxFloat64 = AddressOf Jl_unbox_float64
                BoxFloat64 = AddressOf Jl_box_float64
                UnboxInt64 = AddressOf Jl_unbox_int64
                BoxInt64 = AddressOf Jl_box_int64
                GetGlobal = AddressOf Jl_get_global
                Call1 = AddressOf Jl_call1
                Symbol = AddressOf Jl_symbol
                ApplyArrayType = AddressOf Jl_apply_array_type
                AllocArray1D = AddressOf Jl_alloc_array_1d
                AllocArray2D = AddressOf Jl_alloc_array_2d

                Float64Type = GetProcAddress(LibPtr, "jl_float64_type")
                Int64Type = GetProcAddress(LibPtr, "jl_int64_type")
                BaseModule = GetProcAddress(LibPtr, "jl_base_module")
            ElseIf RuntimeInformation.IsOSPlatform(OSPlatform.Linux) Then
                Dim libName = Path.Combine(AppContext.BaseDirectory, "julia", $"linux-{arch}", $"{LibraryName}.so")
                Debug.WriteLine($"linux:{libName}")
                LibPtr = dlopen(libName, RTLD_NOW Or RTLD_GLOBAL)


                If LibPtr <> IntPtr.Zero Then
                    Dim ptr1 = dlsym(LibPtr, "jl_init")
                    InitThreading = Marshal.GetDelegateForFunctionPointer(Of JuliaInitDelegate)(ptr1)

                    ptr1 = dlsym(LibPtr, "jl_atexit_hook")
                    AtExitHook = Marshal.GetDelegateForFunctionPointer(Of JuliaAtExitHookDelegate)(ptr1)

                    ptr1 = dlsym(LibPtr, "jl_eval_string")
                    EvalString = Marshal.GetDelegateForFunctionPointer(Of JuliaEvalStringDelegate)(ptr1)

                    ptr1 = dlsym(LibPtr, "jl_unbox_float64")
                    UnboxFloat64 = Marshal.GetDelegateForFunctionPointer(Of JuliaUnboxFloat64Delegate)(ptr1)

                    ptr1 = dlsym(LibPtr, "jl_box_float64")
                    BoxFloat64 = Marshal.GetDelegateForFunctionPointer(Of JuliaBoxFloat64Delegate)(ptr1)

                    ptr1 = dlsym(LibPtr, "jl_get_global")
                    GetGlobal = Marshal.GetDelegateForFunctionPointer(Of JuliaGetGlobalDelegate)(ptr1)

                    ptr1 = dlsym(LibPtr, "jl_unbox_int64")
                    UnboxInt64 = Marshal.GetDelegateForFunctionPointer(Of JuliaUnboxInt64Delegate)(ptr1)

                    ptr1 = dlsym(LibPtr, "jl_box_int64")
                    BoxInt64 = Marshal.GetDelegateForFunctionPointer(Of JuliaBoxInt64Delegate)(ptr1)

                    ptr1 = dlsym(LibPtr, "jl_call1")
                    Call1 = Marshal.GetDelegateForFunctionPointer(Of JuliaCall1Delegate)(ptr1)

                    ptr1 = dlsym(LibPtr, "jl_symbol")
                    Symbol = Marshal.GetDelegateForFunctionPointer(Of JuliaSymbolDelegate)(ptr1)

                    ptr1 = dlsym(LibPtr, "jl_apply_array_type")
                    ApplyArrayType = Marshal.GetDelegateForFunctionPointer(Of JuliaApplyArrayTypeDelegate)(ptr1)

                    ptr1 = dlsym(LibPtr, "jl_alloc_array_1d")
                    AllocArray1D = Marshal.GetDelegateForFunctionPointer(Of JuliaAllocArray1DDelegate)(ptr1)

                    ptr1 = dlsym(LibPtr, "jl_alloc_array_2d")
                    AllocArray2D = Marshal.GetDelegateForFunctionPointer(Of JuliaAllocArray2DDelegate)(ptr1)

                    Float64Type = dlsym(LibPtr, "jl_float64_type")
                    Int64Type = dlsym(LibPtr, "jl_int64_type")
                    BaseModule = dlsym(LibPtr, "jl_base_module")
                End If
            Else
                Debug.WriteLine("仅支持Windows和Linux")
            End If
            If LibPtr <> IntPtr.Zero Then
                Debug.WriteLine("加载Julia成功!")
            Else
                Throw New BadImageFormatException("加载Julia失败")
            End If
        Catch ex As Exception
            Throw New BadImageFormatException(ex.Message)
        End Try
    End Sub

    Public Delegate Sub JuliaInitDelegate()
    <DllImport(LibraryName, EntryPoint:="jl_init__threading", CallingConvention:=CallingConvention.Cdecl)>
    Private Shared Sub Jl_init__threading()
    End Sub
    Public Shared InitThreading As JuliaInitDelegate = Nothing

    Public Delegate Sub JuliaAtExitHookDelegate(ByVal status As Integer)
    <DllImport(LibraryName, EntryPoint:="jl_atexit_hook", CallingConvention:=CallingConvention.Cdecl)>
    Private Shared Sub Jl_atexit_hook(ByVal status As Integer)
    End Sub
    Public Shared AtExitHook As JuliaAtExitHookDelegate = Nothing

    Public Delegate Function JuliaEvalStringDelegate(
    <MarshalAs(UnmanagedType.LPStr)> ByVal str As String) As IntPtr
    <DllImport(LibraryName, EntryPoint:="jl_eval_string", CallingConvention:=CallingConvention.Cdecl)>
    Private Shared Function Jl_eval_string(
    <MarshalAs(UnmanagedType.LPStr)> ByVal str As String) As IntPtr
    End Function
    Public Shared EvalString As JuliaEvalStringDelegate = Nothing

    Public Delegate Function JuliaUnboxFloat64Delegate(ByVal v As IntPtr) As Double
    <DllImport(LibraryName, EntryPoint:="jl_unbox_float64", CallingConvention:=CallingConvention.Cdecl)>
    Private Shared Function Jl_unbox_float64(ByVal v As IntPtr) As Double
    End Function
    Public Shared UnboxFloat64 As JuliaUnboxFloat64Delegate = Nothing

    Public Delegate Function JuliaBoxFloat64Delegate(ByVal x As Double) As IntPtr
    <DllImport(LibraryName, EntryPoint:="jl_box_float64", CallingConvention:=CallingConvention.Cdecl)>
    Private Shared Function Jl_box_float64(ByVal x As Double) As IntPtr
    End Function
    Public Shared BoxFloat64 As JuliaBoxFloat64Delegate = Nothing

    Public Delegate Function JuliaUnboxInt64Delegate(ByVal v As IntPtr) As Long
    <DllImport(LibraryName, EntryPoint:="jl_unbox_int64", CallingConvention:=CallingConvention.Cdecl)>
    Private Shared Function Jl_unbox_int64(ByVal v As IntPtr) As Long
    End Function
    Public Shared UnboxInt64 As JuliaUnboxInt64Delegate = Nothing

    Public Delegate Function JuliaBoxInt64Delegate(ByVal x As Long) As IntPtr
    <DllImport(LibraryName, EntryPoint:="jl_box_int64", CallingConvention:=CallingConvention.Cdecl)>
    Private Shared Function Jl_box_int64(ByVal x As Long) As IntPtr
    End Function
    Public Shared BoxInt64 As JuliaBoxInt64Delegate = Nothing

    Public Delegate Function JuliaGetGlobalDelegate(ByVal m As IntPtr, ByVal var As IntPtr) As IntPtr
    <DllImport(LibraryName, EntryPoint:="jl_get_global", CallingConvention:=CallingConvention.Cdecl)>
    Private Shared Function Jl_get_global(ByVal m As IntPtr, ByVal var As IntPtr) As IntPtr
    End Function
    Public Shared GetGlobal As JuliaGetGlobalDelegate = Nothing

    Public Delegate Function JuliaSymbolDelegate(
    <MarshalAs(UnmanagedType.LPStr)> ByVal str As String) As IntPtr
    <DllImport(LibraryName, EntryPoint:="jl_symbol", CallingConvention:=CallingConvention.Cdecl)>
    Private Shared Function Jl_symbol(
    <MarshalAs(UnmanagedType.LPStr)> ByVal str As String) As IntPtr
    End Function
    Public Shared Symbol As JuliaSymbolDelegate = Nothing

    Public Delegate Function JuliaGetFunctionDelegate(ByVal m As IntPtr, ByVal name As String) As IntPtr
    Public Shared GetFunction As JuliaGetFunctionDelegate = New JuliaGetFunctionDelegate(Function(m, name)
                                                                                             Dim bstr = Symbol(name)
                                                                                             Return GetGlobal(m, bstr)
                                                                                         End Function)

    Public Delegate Function JuliaCall1Delegate(ByVal f As IntPtr, ByVal a As IntPtr) As IntPtr
    <DllImport(LibraryName, EntryPoint:="jl_call1", CallingConvention:=CallingConvention.Cdecl)>
    Private Shared Function Jl_call1(ByVal f As IntPtr, ByVal a As IntPtr) As IntPtr
    End Function
    Public Shared Call1 As JuliaCall1Delegate = Nothing

    Public Delegate Function JuliaApplyArrayTypeDelegate(ByVal type As IntPtr, ByVal [dim] As size_t) As IntPtr
    <DllImport(LibraryName, EntryPoint:="jl_apply_array_type", CallingConvention:=CallingConvention.Cdecl)>
    Private Shared Function Jl_apply_array_type(ByVal type As IntPtr, ByVal [dim] As size_t) As IntPtr
    End Function
    Public Shared ApplyArrayType As JuliaApplyArrayTypeDelegate = Nothing

    Public Delegate Function JuliaAllocArray1DDelegate(ByVal atype As IntPtr, ByVal nr As size_t) As IntPtr
    <DllImport(LibraryName, EntryPoint:="jl_alloc_array_1d", CallingConvention:=CallingConvention.Cdecl)>
    Private Shared Function Jl_alloc_array_1d(ByVal atype As IntPtr, ByVal nr As size_t) As IntPtr
    End Function
    Public Shared AllocArray1D As JuliaAllocArray1DDelegate = Nothing

    Public Delegate Function JuliaAllocArray2DDelegate(ByVal atype As IntPtr, ByVal nr As size_t, ByVal nc As size_t) As IntPtr
    <DllImport(LibraryName, EntryPoint:="jl_alloc_array_2d", CallingConvention:=CallingConvention.Cdecl)>
    Private Shared Function Jl_alloc_array_2d(ByVal atype As IntPtr, ByVal nr As size_t, ByVal nc As size_t) As IntPtr
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
