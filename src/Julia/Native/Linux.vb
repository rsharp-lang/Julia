Imports System.Runtime.InteropServices

Namespace Native

    Public Class Linux

        Const RTLD_NOW As Integer = &H2
        Const RTLD_GLOBAL As Integer = &H100

        <DllImport("libdl")>
        Private Shared Function dlopen(ByVal filename As String, ByVal flags As Integer) As IntPtr
        End Function

        <DllImport("libdl")>
        Protected Shared Function dlsym(ByVal handle As IntPtr, ByVal symbol As String) As IntPtr
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="libname">filepath to the file ``libjulia.so`` on linux platform</param>
        Public Shared Sub LoadJulia(libname As String)
            JuliaNative.LibPtr = dlopen(libname, RTLD_NOW Or RTLD_GLOBAL)

            If JuliaNative.LibPtr <> IntPtr.Zero Then
                Dim ptr1 = dlsym(JuliaNative.LibPtr, "jl_init")
                JuliaNative.InitThreading = Marshal.GetDelegateForFunctionPointer(Of Native.JuliaInitDelegate)(ptr1)

                ptr1 = dlsym(JuliaNative.LibPtr, "jl_atexit_hook")
                JuliaNative.AtExitHook = Marshal.GetDelegateForFunctionPointer(Of Native.JuliaAtExitHookDelegate)(ptr1)

                ptr1 = dlsym(JuliaNative.LibPtr, "jl_eval_string")
                JuliaNative.EvalString = Marshal.GetDelegateForFunctionPointer(Of Native.JuliaEvalStringDelegate)(ptr1)

                ptr1 = dlsym(JuliaNative.LibPtr, "jl_unbox_float64")
                JuliaNative.UnboxFloat64 = Marshal.GetDelegateForFunctionPointer(Of Native.JuliaUnboxFloat64Delegate)(ptr1)

                ptr1 = dlsym(JuliaNative.LibPtr, "jl_box_float64")
                JuliaNative.BoxFloat64 = Marshal.GetDelegateForFunctionPointer(Of Native.JuliaBoxFloat64Delegate)(ptr1)

                ptr1 = dlsym(JuliaNative.LibPtr, "jl_get_global")
                JuliaNative.GetGlobal = Marshal.GetDelegateForFunctionPointer(Of Native.JuliaGetGlobalDelegate)(ptr1)

                ptr1 = dlsym(JuliaNative.LibPtr, "jl_unbox_int64")
                JuliaNative.UnboxInt64 = Marshal.GetDelegateForFunctionPointer(Of Native.JuliaUnboxInt64Delegate)(ptr1)

                ptr1 = dlsym(JuliaNative.LibPtr, "jl_box_int64")
                JuliaNative.BoxInt64 = Marshal.GetDelegateForFunctionPointer(Of Native.JuliaBoxInt64Delegate)(ptr1)

                ptr1 = dlsym(JuliaNative.LibPtr, "jl_call1")
                JuliaNative.Call1 = Marshal.GetDelegateForFunctionPointer(Of Native.JuliaCall1Delegate)(ptr1)

                ptr1 = dlsym(JuliaNative.LibPtr, "jl_symbol")
                JuliaNative.Symbol = Marshal.GetDelegateForFunctionPointer(Of Native.JuliaSymbolDelegate)(ptr1)

                ptr1 = dlsym(JuliaNative.LibPtr, "jl_apply_array_type")
                JuliaNative.ApplyArrayType = Marshal.GetDelegateForFunctionPointer(Of Native.JuliaApplyArrayTypeDelegate)(ptr1)

                ptr1 = dlsym(JuliaNative.LibPtr, "jl_alloc_array_1d")
                JuliaNative.AllocArray1D = Marshal.GetDelegateForFunctionPointer(Of Native.JuliaAllocArray1DDelegate)(ptr1)

                ptr1 = dlsym(JuliaNative.LibPtr, "jl_alloc_array_2d")
                JuliaNative.AllocArray2D = Marshal.GetDelegateForFunctionPointer(Of Native.JuliaAllocArray2DDelegate)(ptr1)

                JuliaNative.Float64Type = dlsym(JuliaNative.LibPtr, "jl_float64_type")
                JuliaNative.Int64Type = dlsym(JuliaNative.LibPtr, "jl_int64_type")
                JuliaNative.BaseModule = dlsym(JuliaNative.LibPtr, "jl_base_module")
            End If
        End Sub
    End Class
End Namespace