
Imports System.Runtime.InteropServices

Namespace Native.jl_cdecl

    Partial Class Cdecl

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_exception_occurred() As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_current_exception() As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_exception_clear()
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_errno() As Integer
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_set_errno(e As Integer)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_error(str As String)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_too_few_args(fname As String, min As Integer)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_too_many_args(fname As String, max As Integer)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_type_error(fname As String, expected As IntPtr, got As IntPtr)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_type_error_rt(fname As String, context As String, ty As IntPtr, got As IntPtr)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_undefined_var_error(var As IntPtr)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_atomic_error(str As String)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_bounds_error(v As IntPtr, t As IntPtr)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_eof_error()
        End Sub
    End Class
End Namespace