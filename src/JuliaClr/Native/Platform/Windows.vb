Imports Microsoft.VisualBasic.ApplicationServices.DynamicInterop
Imports SMRUCC.Julia.Native.jl_cdecl

Namespace Native.Platform

    ''' <summary>
    ''' the windows julia directory
    ''' </summary>
    Public Class Windows

        Public Shared Sub LoadJulia(libjulia As UnmanagedDll)
            JuliaNative.julia_init__threading = AddressOf Cdecl.Jl_init__threading
            JuliaNative.julia_atexit_hook = AddressOf Cdecl.Jl_atexit_hook
            JuliaNative.julia_eval_string = AddressOf Cdecl.Jl_eval_string
            JuliaNative.julia_unbox_float64 = AddressOf Cdecl.Jl_unbox_float64
            JuliaNative.julia_box_float64 = AddressOf Cdecl.Jl_box_float64
            JuliaNative.julia_unbox_int64 = AddressOf Cdecl.Jl_unbox_int64
            JuliaNative.julia_box_int64 = AddressOf Cdecl.Jl_box_int64
            JuliaNative.julia_get_global = AddressOf Cdecl.Jl_get_global
            JuliaNative.julia_call1 = AddressOf Cdecl.Jl_call1
            JuliaNative.julia_symbol = AddressOf Cdecl.Jl_symbol
            JuliaNative.julia_apply_array_type = AddressOf Cdecl.Jl_apply_array_type
            JuliaNative.julia_alloc_array_1d = AddressOf Cdecl.Jl_alloc_array_1d
            JuliaNative.julia_alloc_array_2d = AddressOf Cdecl.Jl_alloc_array_2d

            JuliaNative.julia_typeof_str = AddressOf Cdecl.jl_typeof_str

            JuliaNative.julia_gc_collect = AddressOf Cdecl.Jl_gc_collect
            JuliaNative.julia_gc_enable = AddressOf Cdecl.Jl_gc_enable
        End Sub
    End Class
End Namespace