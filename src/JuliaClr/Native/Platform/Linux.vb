Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.ApplicationServices.DynamicInterop

Namespace Native.Platform

    Public Class Linux

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="libname"></param>
        Public Shared Sub LoadJulia(libjulia As UnmanagedDll)
            If JuliaNative.LibPtr <> IntPtr.Zero Then
                Call UnixLoadLibrary(libjulia)
            End If
        End Sub

        Private Shared Sub UnixLoadLibrary(julia_so As UnmanagedDll)
            JuliaNative.InitThreading = Marshal.GetDelegateForFunctionPointer(Of Native.JuliaInitDelegate)(julia_so.GetFunctionAddress("jl_init"))
            JuliaNative.AtExitHook = Marshal.GetDelegateForFunctionPointer(Of Native.JuliaAtExitHookDelegate)(julia_so.GetFunctionAddress("jl_atexit_hook"))
            JuliaNative.EvalString = Marshal.GetDelegateForFunctionPointer(Of Native.JuliaEvalStringDelegate)(julia_so.GetFunctionAddress("jl_eval_string"))
            JuliaNative.UnboxFloat64 = Marshal.GetDelegateForFunctionPointer(Of Native.JuliaUnboxFloat64Delegate)(julia_so.GetFunctionAddress("jl_unbox_float64"))
            JuliaNative.BoxFloat64 = Marshal.GetDelegateForFunctionPointer(Of Native.JuliaBoxFloat64Delegate)(julia_so.GetFunctionAddress("jl_box_float64"))
            JuliaNative.GetGlobal = Marshal.GetDelegateForFunctionPointer(Of Native.JuliaGetGlobalDelegate)(julia_so.GetFunctionAddress("jl_get_global"))
            JuliaNative.UnboxInt64 = Marshal.GetDelegateForFunctionPointer(Of Native.JuliaUnboxInt64Delegate)(julia_so.GetFunctionAddress("jl_unbox_int64"))
            JuliaNative.BoxInt64 = Marshal.GetDelegateForFunctionPointer(Of Native.JuliaBoxInt64Delegate)(julia_so.GetFunctionAddress("jl_box_int64"))
            JuliaNative.Call1 = Marshal.GetDelegateForFunctionPointer(Of Native.JuliaCall1Delegate)(julia_so.GetFunctionAddress("jl_call1"))
            JuliaNative.Symbol = Marshal.GetDelegateForFunctionPointer(Of Native.JuliaSymbolDelegate)(julia_so.GetFunctionAddress("jl_symbol"))
            JuliaNative.ApplyArrayType = Marshal.GetDelegateForFunctionPointer(Of Native.JuliaApplyArrayTypeDelegate)(julia_so.GetFunctionAddress("jl_apply_array_type"))
            JuliaNative.AllocArray1D = Marshal.GetDelegateForFunctionPointer(Of Native.JuliaAllocArray1DDelegate)(julia_so.GetFunctionAddress("jl_alloc_array_1d"))
            JuliaNative.AllocArray2D = Marshal.GetDelegateForFunctionPointer(Of Native.JuliaAllocArray2DDelegate)(julia_so.GetFunctionAddress("jl_alloc_array_2d"))
        End Sub
    End Class
End Namespace