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
            JuliaNative.julia_init__threading = Marshal.GetDelegateForFunctionPointer(Of Native.julia_init__threading)(julia_so.GetFunctionAddress("jl_init"))
            JuliaNative.AtExitHook = Marshal.GetDelegateForFunctionPointer(Of Native.julia_atexit_hook)(julia_so.GetFunctionAddress("jl_atexit_hook"))
            JuliaNative.julia_eval_string = Marshal.GetDelegateForFunctionPointer(Of Native.julia_eval_string)(julia_so.GetFunctionAddress("jl_eval_string"))
            JuliaNative.UnboxFloat64 = Marshal.GetDelegateForFunctionPointer(Of Native.julia_unbox_float64)(julia_so.GetFunctionAddress("jl_unbox_float64"))
            JuliaNative.BoxFloat64 = Marshal.GetDelegateForFunctionPointer(Of Native.julia_box_float64)(julia_so.GetFunctionAddress("jl_box_float64"))
            JuliaNative.GetGlobal = Marshal.GetDelegateForFunctionPointer(Of Native.julia_get_global)(julia_so.GetFunctionAddress("jl_get_global"))
            JuliaNative.UnboxInt64 = Marshal.GetDelegateForFunctionPointer(Of Native.julia_unbox_int64)(julia_so.GetFunctionAddress("jl_unbox_int64"))
            JuliaNative.BoxInt64 = Marshal.GetDelegateForFunctionPointer(Of Native.julia_box_int64)(julia_so.GetFunctionAddress("jl_box_int64"))
            JuliaNative.Call1 = Marshal.GetDelegateForFunctionPointer(Of Native.julia_call1)(julia_so.GetFunctionAddress("jl_call1"))
            JuliaNative.Symbol = Marshal.GetDelegateForFunctionPointer(Of Native.julia_symbol)(julia_so.GetFunctionAddress("jl_symbol"))
            JuliaNative.ApplyArrayType = Marshal.GetDelegateForFunctionPointer(Of Native.julia_apply_array_type)(julia_so.GetFunctionAddress("jl_apply_array_type"))
            JuliaNative.AllocArray1D = Marshal.GetDelegateForFunctionPointer(Of Native.julia_alloc_array_1d)(julia_so.GetFunctionAddress("jl_alloc_array_1d"))
            JuliaNative.AllocArray2D = Marshal.GetDelegateForFunctionPointer(Of Native.julia_alloc_array_2d)(julia_so.GetFunctionAddress("jl_alloc_array_2d"))

            JuliaNative.julia_gc_collect = Marshal.GetDelegateForFunctionPointer(Of Native.julia_gc_collect)(julia_so.GetFunctionAddress("jl_gc_collect"))
            JuliaNative.julia_gc_enable = Marshal.GetDelegateForFunctionPointer(Of Native.julia_gc_enable)(julia_so.GetFunctionAddress("jl_gc_enable"))
        End Sub
    End Class
End Namespace