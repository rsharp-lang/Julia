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

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_string_ptr(ByVal v As IntPtr) As IntPtr
        End Function


        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_unbox_float64(ByVal t As IntPtr) As Double
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_unbox_float32(ByVal t As IntPtr) As Single
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_unbox_int32(ByVal t As IntPtr) As Integer
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_unbox_int16(ByVal t As IntPtr) As Short
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_unbox_int8(ByVal t As IntPtr) As SByte
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_unbox_bool(ByVal t As IntPtr) As Boolean
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_unbox_uint64(ByVal t As IntPtr) As ULong
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_unbox_uint32(ByVal t As IntPtr) As UInteger
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_unbox_uint16(ByVal t As IntPtr) As UShort
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_unbox_uint8(ByVal t As IntPtr) As Byte
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_unbox_voidpointer(ByVal v As IntPtr) As IntPtr
        End Function


        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_box_float64(ByVal t As Double) As IntPtr
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_box_float32(ByVal t As Single) As IntPtr
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_box_int32(ByVal t As Integer) As IntPtr
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_box_int16(ByVal t As Short) As IntPtr
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_box_int8(ByVal t As SByte) As IntPtr
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_box_bool(ByVal t As Boolean) As IntPtr
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_box_uint64(ByVal t As ULong) As IntPtr
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_box_uint32(ByVal t As UInteger) As IntPtr
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_box_uint16(ByVal t As UShort) As IntPtr
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_box_uint8(ByVal t As Byte) As IntPtr
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_box_voidpointer(ByVal x As IntPtr) As IntPtr
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_cstr_to_string(ByVal s As String) As IntPtr
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

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_exception_occurred() As IntPtr
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_current_exception() As IntPtr
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_exception_clear()
        End Sub


        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_typename_str(ByVal val As IntPtr) As IntPtr
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_typeof_str(ByVal v As IntPtr) As IntPtr
        End Function


        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_new_module(ByVal name As IntPtr) As IntPtr
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_set_module_nospecialize(ByVal self As IntPtr, ByVal [on] As Integer)
        End Sub

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_set_module_optlevel(ByVal self As IntPtr, ByVal lvl As Integer)
        End Sub

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_get_module_optlevel(ByVal m As IntPtr) As Integer
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_set_module_compile(ByVal self As IntPtr, ByVal value As Integer)
        End Sub

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_get_module_compile(ByVal m As IntPtr) As Integer
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_set_module_infer(ByVal self As IntPtr, ByVal value As Integer)
        End Sub

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_get_module_infer(ByVal m As IntPtr) As Integer
        End Function


        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_get_binding(ByVal m As IntPtr, ByVal var As IntPtr) As IntPtr
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_get_binding_or_error(ByVal m As IntPtr, ByVal var As IntPtr) As IntPtr
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_module_globalref(ByVal m As IntPtr, ByVal var As IntPtr) As IntPtr
        End Function


        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_get_binding_wr(ByVal m As IntPtr, ByVal var As IntPtr, ByVal [error] As Integer) As IntPtr
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_get_binding_for_method_def(ByVal m As IntPtr, ByVal var As IntPtr) As IntPtr
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_boundp(ByVal m As IntPtr, ByVal var As IntPtr) As Integer
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_defines_or_exports_p(ByVal m As IntPtr, ByVal var As IntPtr) As Integer
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_binding_resolved_p(ByVal m As IntPtr, ByVal var As IntPtr) As Integer
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_set_global(ByVal m As IntPtr, ByVal var As IntPtr, ByVal val As IntPtr)
        End Sub

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_set_const(ByVal m As IntPtr, ByVal var As IntPtr, ByVal val As IntPtr)
        End Sub

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_checked_assignment(ByVal b As IntPtr, ByVal rhs As IntPtr)
        End Sub

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_declare_constant(ByVal b As IntPtr)
        End Sub

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_module_using(ByVal [to] As IntPtr, ByVal from As IntPtr)
        End Sub

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_module_use(ByVal [to] As IntPtr, ByVal from As IntPtr, ByVal s As IntPtr)
        End Sub

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_module_use_as(ByVal [to] As IntPtr, ByVal from As IntPtr, ByVal s As IntPtr, ByVal asname As IntPtr)
        End Sub

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_module_import(ByVal [to] As IntPtr, ByVal from As IntPtr, ByVal s As IntPtr)
        End Sub

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_module_import_as(ByVal [to] As IntPtr, ByVal from As IntPtr, ByVal s As IntPtr, ByVal asname As IntPtr)
        End Sub

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_module_export(ByVal from As IntPtr, ByVal s As IntPtr)
        End Sub

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_is_imported(ByVal m As IntPtr, ByVal s As IntPtr) As Integer
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_module_exports_p(ByVal m As IntPtr, ByVal var As IntPtr) As Integer
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_add_standard_imports(ByVal m As IntPtr)
        End Sub


        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_eqtable_put(ByVal h As IntPtr, ByVal key As IntPtr, ByVal val As IntPtr, ByVal inserted As IntPtr) As IntPtr
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_eqtable_get(ByVal h As IntPtr, ByVal key As IntPtr, ByVal deflt As IntPtr) As IntPtr
        End Function



        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_errno() As Integer
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_set_errno(ByVal e As Integer)
        End Sub

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_stat(ByVal path As String, ByVal statbuf As String) As Integer
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_cpu_threads() As Integer
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_getpagesize() As Long
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_getallocationgranularity() As Long
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_is_debugbuild() As Integer
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_get_UNAME() As IntPtr
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_get_ARCH() As IntPtr
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_get_libllvm() As IntPtr
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_environ(ByVal i As Integer) As IntPtr
        End Function


        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_error(ByVal str As String)
        End Sub


        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_too_few_args(ByVal fname As String, ByVal min As Integer)
        End Sub

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_too_many_args(ByVal fname As String, ByVal max As Integer)
        End Sub

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_type_error(ByVal fname As String, ByVal expected As IntPtr, ByVal got As IntPtr)
        End Sub

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_type_error_rt(ByVal fname As String, ByVal context As String, ByVal ty As IntPtr, ByVal got As IntPtr)
        End Sub

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_undefined_var_error(ByVal var As IntPtr)
        End Sub

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_atomic_error(ByVal str As String)
        End Sub

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_bounds_error(ByVal v As IntPtr, ByVal t As IntPtr)
        End Sub

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_eof_error()
        End Sub


        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_get_libdir() As IntPtr
        End Function



        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_init_with_image(ByVal julia_bindir As String, ByVal image_relative_path As String)
        End Sub

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_get_default_sysimg_path() As IntPtr
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_is_initialized() As Integer
        End Function


        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_exit(ByVal status As Integer)
        End Sub


        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_pathname_for_handle(ByVal handle As IntPtr) As IntPtr
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_deserialize_verify_header(ByVal s As IntPtr) As Integer
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_preload_sysimg_so(ByVal fname As String)
        End Sub

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_set_sysimg_so(ByVal handle As IntPtr)
        End Sub

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_create_system_image(ByVal p As IntPtr) As IntPtr
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_save_system_image(ByVal fname As String)
        End Sub

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_restore_system_image(ByVal fname As String)
        End Sub

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_is_operator(ByVal sym As String) As Integer
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_is_unary_operator(ByVal sym As String) As Integer
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_is_unary_and_binary_operator(ByVal sym As String) As Integer
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_is_syntactic_operator(ByVal sym As String) As Integer
        End Function

        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_operator_precedence(ByVal sym As String) As Integer
        End Function


        <DllImport("libjulia.dll", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_yield()
        End Sub
    End Class
End Namespace