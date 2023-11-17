Imports System.Runtime.InteropServices

Namespace Native

    ''' <summary>
    ''' the windows julia directory
    ''' </summary>
    Public Class Windows

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

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="libname">file path to the ``bin\libjulia.dll`` on windows</param>
        Public Shared Sub LoadJulia(libname As String)
            JuliaNative.LibPtr = LoadLibrary(libname)

            JuliaNative.InitThreading = AddressOf JuliaNative.Jl_init__threading
            JuliaNative.AtExitHook = AddressOf JuliaNative.Jl_atexit_hook
            JuliaNative.EvalString = AddressOf JuliaNative.Jl_eval_string
            JuliaNative.UnboxFloat64 = AddressOf JuliaNative.Jl_unbox_float64
            JuliaNative.BoxFloat64 = AddressOf JuliaNative.Jl_box_float64
            JuliaNative.UnboxInt64 = AddressOf JuliaNative.Jl_unbox_int64
            JuliaNative.BoxInt64 = AddressOf JuliaNative.Jl_box_int64
            JuliaNative.GetGlobal = AddressOf JuliaNative.Jl_get_global
            JuliaNative.Call1 = AddressOf JuliaNative.Jl_call1
            JuliaNative.Symbol = AddressOf JuliaNative.Jl_symbol
            JuliaNative.ApplyArrayType = AddressOf JuliaNative.Jl_apply_array_type
            JuliaNative.AllocArray1D = AddressOf JuliaNative.Jl_alloc_array_1d
            JuliaNative.AllocArray2D = AddressOf JuliaNative.Jl_alloc_array_2d

            JuliaNative.Float64Type = GetProcAddress(JuliaNative.LibPtr, "jl_float64_type")
            JuliaNative.Int64Type = GetProcAddress(JuliaNative.LibPtr, "jl_int64_type")
            JuliaNative.BaseModule = GetProcAddress(JuliaNative.LibPtr, "jl_base_module")
        End Sub
    End Class
End Namespace