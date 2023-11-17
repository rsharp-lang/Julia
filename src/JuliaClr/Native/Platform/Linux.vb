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
            JuliaNative.julia_init__threading = julia_so.GetFunction(Of Native.julia_init__threading)("jl_init")
            JuliaNative.julia_atexit_hook = julia_so.GetFunction(Of Native.julia_atexit_hook)("jl_atexit_hook")
            JuliaNative.julia_eval_string = julia_so.GetFunction(Of Native.julia_eval_string)("jl_eval_string")
            JuliaNative.julia_unbox_float64 = julia_so.GetFunction(Of Native.julia_unbox_float64)("jl_unbox_float64")
            JuliaNative.julia_box_float64 = julia_so.GetFunction(Of Native.julia_box_float64)("jl_box_float64")
            JuliaNative.julia_get_global = julia_so.GetFunction(Of Native.julia_get_global)("jl_get_global")
            JuliaNative.julia_unbox_int64 = julia_so.GetFunction(Of Native.julia_unbox_int64)("jl_unbox_int64")
            JuliaNative.julia_box_int64 = julia_so.GetFunction(Of Native.julia_box_int64)("jl_box_int64")
            JuliaNative.julia_call1 = julia_so.GetFunction(Of Native.julia_call1)("jl_call1")
            JuliaNative.julia_symbol = julia_so.GetFunction(Of Native.julia_symbol)("jl_symbol")
            JuliaNative.julia_apply_array_type = julia_so.GetFunction(Of Native.julia_apply_array_type)("jl_apply_array_type")
            JuliaNative.julia_alloc_array_1d = julia_so.GetFunction(Of Native.julia_alloc_array_1d)("jl_alloc_array_1d")
            JuliaNative.julia_alloc_array_2d = julia_so.GetFunction(Of Native.julia_alloc_array_2d)("jl_alloc_array_2d")

            JuliaNative.julia_gc_collect = julia_so.GetFunction(Of Native.julia_gc_collect)("jl_gc_collect")
            JuliaNative.julia_gc_enable = julia_so.GetFunction(Of Native.julia_gc_enable)("jl_gc_enable")
        End Sub
    End Class
End Namespace