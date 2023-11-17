Imports Microsoft.VisualBasic.ApplicationServices.DynamicInterop

Namespace Native

    ''' <summary>
    ''' the windows julia directory
    ''' </summary>
    Public Class Windows

        Public Shared Sub LoadJulia(libjulia As UnmanagedDll)
            JuliaNative.InitThreading = AddressOf Cdecl.Jl_init__threading
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
        End Sub
    End Class
End Namespace