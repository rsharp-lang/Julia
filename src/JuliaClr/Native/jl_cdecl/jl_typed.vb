Imports System.Runtime.InteropServices

Namespace Native.jl_cdecl

    Partial Class Cdecl

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_typename_str(val As IntPtr) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_typeof_str(v As IntPtr) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_typeof(v As IntPtr) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_is_operator(sym As String) As Integer
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_is_unary_operator(sym As String) As Integer
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_is_unary_and_binary_operator(sym As String) As Integer
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_is_syntactic_operator(sym As String) As Integer
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_operator_precedence(sym As String) As Integer
        End Function
    End Class
End Namespace