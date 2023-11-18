Imports System.Runtime.InteropServices
Imports size_t = System.UIntPtr

Namespace Native

    ''' <summary>
    ''' jl_gc_collect()
    ''' </summary>
    Public Delegate Sub julia_gc_collect()

    Public Delegate Function julia_gc_enable([on] As UInteger) As UInteger

    ''' <summary>
    ''' jl_init__threading
    ''' </summary>
    Public Delegate Sub julia_init__threading()

    ''' <summary>
    ''' jl_atexit_hook
    ''' </summary>
    ''' <param name="status"></param>
    Public Delegate Sub julia_atexit_hook(status As Integer)

    ''' <summary>
    ''' jl_eval_string
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    Public Delegate Function julia_eval_string(<MarshalAs(UnmanagedType.LPStr)> str As String) As IntPtr

    ''' <summary>
    ''' jl_get_global
    ''' </summary>
    ''' <param name="m"></param>
    ''' <param name="var"></param>
    ''' <returns></returns>
    Public Delegate Function julia_get_global(m As IntPtr, var As IntPtr) As IntPtr

    ''' <summary>
    ''' jl_symbol
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    Public Delegate Function julia_symbol(<MarshalAs(UnmanagedType.LPStr)> str As String) As IntPtr

    ''' <summary>
    ''' jl_call1
    ''' </summary>
    ''' <param name="f"></param>
    ''' <param name="a"></param>
    ''' <returns></returns>
    Public Delegate Function julia_call1(f As IntPtr, a As IntPtr) As IntPtr



End Namespace
