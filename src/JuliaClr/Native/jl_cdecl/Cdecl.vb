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

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_string_ptr(v As IntPtr) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_cstr_to_string(s As String) As IntPtr
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

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_typename_str(val As IntPtr) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_typeof_str(v As IntPtr) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_new_module(name As IntPtr) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_set_module_nospecialize(self As IntPtr, [on] As Integer)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_set_module_optlevel(self As IntPtr, lvl As Integer)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_get_module_optlevel(m As IntPtr) As Integer
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_set_module_compile(self As IntPtr, value As Integer)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_get_module_compile(m As IntPtr) As Integer
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_set_module_infer(self As IntPtr, value As Integer)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_get_module_infer(m As IntPtr) As Integer
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_get_binding(m As IntPtr, var As IntPtr) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_get_binding_or_error(m As IntPtr, var As IntPtr) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_module_globalref(m As IntPtr, var As IntPtr) As IntPtr
        End Function


        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_get_binding_wr(m As IntPtr, var As IntPtr, [error] As Integer) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_get_binding_for_method_def(m As IntPtr, var As IntPtr) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_boundp(m As IntPtr, var As IntPtr) As Integer
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_defines_or_exports_p(m As IntPtr, var As IntPtr) As Integer
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_binding_resolved_p(m As IntPtr, var As IntPtr) As Integer
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_set_global(m As IntPtr, var As IntPtr, val As IntPtr)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_set_const(m As IntPtr, var As IntPtr, val As IntPtr)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_checked_assignment(b As IntPtr, rhs As IntPtr)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_declare_constant(b As IntPtr)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_module_using([to] As IntPtr, from As IntPtr)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_module_use([to] As IntPtr, from As IntPtr, s As IntPtr)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_module_use_as([to] As IntPtr, from As IntPtr, s As IntPtr, asname As IntPtr)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_module_import([to] As IntPtr, from As IntPtr, s As IntPtr)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_module_import_as([to] As IntPtr, from As IntPtr, s As IntPtr, asname As IntPtr)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_module_export(from As IntPtr, s As IntPtr)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_is_imported(m As IntPtr, s As IntPtr) As Integer
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_module_exports_p(m As IntPtr, var As IntPtr) As Integer
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_add_standard_imports(m As IntPtr)
        End Sub


        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_eqtable_put(h As IntPtr, key As IntPtr, val As IntPtr, inserted As IntPtr) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_eqtable_get(h As IntPtr, key As IntPtr, deflt As IntPtr) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_stat(path As String, statbuf As String) As Integer
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_cpu_threads() As Integer
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_getpagesize() As Long
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_getallocationgranularity() As Long
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_is_debugbuild() As Integer
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_get_UNAME() As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_get_ARCH() As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_get_libllvm() As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_environ(i As Integer) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_get_libdir() As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_init_with_image(julia_bindir As String, image_relative_path As String)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_get_default_sysimg_path() As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_is_initialized() As Integer
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_exit(status As Integer)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_pathname_for_handle(handle As IntPtr) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_deserialize_verify_header(s As IntPtr) As Integer
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_preload_sysimg_so(fname As String)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_set_sysimg_so(handle As IntPtr)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_create_system_image(p As IntPtr) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_save_system_image(fname As String)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_restore_system_image(fname As String)
        End Sub

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

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_yield()
        End Sub
    End Class
End Namespace