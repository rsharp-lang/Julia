Imports System.Runtime.InteropServices
Imports size_t = System.UIntPtr

Namespace Native.jl_cdecl

    ''' <summary>
    ''' imports julia C declare
    ''' </summary>
    Friend Class Cdecl

        <DllImport(JuliaNative.LibraryName, EntryPoint:="jl_init__threading", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Sub Jl_init__threading()
        End Sub

        <DllImport(JuliaNative.LibraryName, EntryPoint:="jl_atexit_hook", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Sub Jl_atexit_hook(status As Integer)
        End Sub

        <DllImport(JuliaNative.LibraryName, EntryPoint:="jl_eval_string", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Function Jl_eval_string(<MarshalAs(UnmanagedType.LPStr)> str As String) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, EntryPoint:="jl_unbox_float64", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Function Jl_unbox_float64(v As IntPtr) As Double
        End Function

        <DllImport(JuliaNative.LibraryName, EntryPoint:="jl_box_float64", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Function Jl_box_float64(x As Double) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, EntryPoint:="jl_unbox_int64", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Function Jl_unbox_int64(v As IntPtr) As Long
        End Function

        <DllImport(JuliaNative.LibraryName, EntryPoint:="jl_box_int64", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Function Jl_box_int64(x As Long) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, EntryPoint:="jl_get_global", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Function Jl_get_global(m As IntPtr, var As IntPtr) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, EntryPoint:="jl_symbol", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Function Jl_symbol(<MarshalAs(UnmanagedType.LPStr)> str As String) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, EntryPoint:="jl_call1", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Function Jl_call1(f As IntPtr, a As IntPtr) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, EntryPoint:="jl_apply_array_type", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Function Jl_apply_array_type(type As IntPtr, [dim] As ULong) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, EntryPoint:="jl_alloc_array_1d", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Function Jl_alloc_array_1d(atype As IntPtr, nr As size_t) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, EntryPoint:="jl_alloc_array_2d", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Function Jl_alloc_array_2d(atype As IntPtr, nr As size_t, nc As size_t) As IntPtr
        End Function
    End Class
End Namespace