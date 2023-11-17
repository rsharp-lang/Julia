Imports Microsoft.VisualBasic.ApplicationServices.DynamicInterop
Imports SMRUCC.Julia.Native.jl_cdecl

Namespace Native.Platform

    ''' <summary>
    ''' the windows julia directory
    ''' </summary>
    Public Class Windows

        Public Shared Sub LoadJulia(libjulia As UnmanagedDll)
            JuliaNative.julia_init__threading = AddressOf Cdecl.Jl_init__threading
            JuliaNative.AtExitHook = AddressOf Cdecl.Jl_atexit_hook
            JuliaNative.EvalString = AddressOf Cdecl.Jl_eval_string
            JuliaNative.UnboxFloat64 = AddressOf Cdecl.Jl_unbox_float64
            JuliaNative.BoxFloat64 = AddressOf Cdecl.Jl_box_float64
            JuliaNative.UnboxInt64 = AddressOf Cdecl.Jl_unbox_int64
            JuliaNative.BoxInt64 = AddressOf Cdecl.Jl_box_int64
            JuliaNative.GetGlobal = AddressOf Cdecl.Jl_get_global
            JuliaNative.Call1 = AddressOf Cdecl.Jl_call1
            JuliaNative.Symbol = AddressOf Cdecl.Jl_symbol
            JuliaNative.ApplyArrayType = AddressOf Cdecl.Jl_apply_array_type
            JuliaNative.AllocArray1D = AddressOf Cdecl.Jl_alloc_array_1d
            JuliaNative.AllocArray2D = AddressOf Cdecl.Jl_alloc_array_2d

            JuliaNative.julia_gc_collect = AddressOf Cdecl.Jl_gc_collect
            JuliaNative.julia_gc_enable = AddressOf Cdecl.Jl_gc_enable
        End Sub
    End Class
End Namespace