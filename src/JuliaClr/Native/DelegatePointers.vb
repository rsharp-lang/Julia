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
    Public Delegate Sub JuliaInitDelegate()

    ''' <summary>
    ''' jl_atexit_hook
    ''' </summary>
    ''' <param name="status"></param>
    Public Delegate Sub JuliaAtExitHookDelegate(status As Integer)

    ''' <summary>
    ''' jl_eval_string
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    Public Delegate Function JuliaEvalStringDelegate(<MarshalAs(UnmanagedType.LPStr)> str As String) As IntPtr

    ''' <summary>
    ''' jl_unbox_float64
    ''' </summary>
    ''' <param name="v"></param>
    ''' <returns></returns>
    Public Delegate Function JuliaUnboxFloat64Delegate(v As IntPtr) As Double

    ''' <summary>
    ''' jl_box_float64
    ''' </summary>
    ''' <param name="x"></param>
    ''' <returns></returns>
    Public Delegate Function JuliaBoxFloat64Delegate(x As Double) As IntPtr

    ''' <summary>
    ''' jl_unbox_int64
    ''' </summary>
    ''' <param name="v"></param>
    ''' <returns></returns>
    Public Delegate Function JuliaUnboxInt64Delegate(v As IntPtr) As Long

    ''' <summary>
    ''' jl_box_int64
    ''' </summary>
    ''' <param name="x"></param>
    ''' <returns></returns>
    Public Delegate Function JuliaBoxInt64Delegate(x As Long) As IntPtr

    ''' <summary>
    ''' jl_get_global
    ''' </summary>
    ''' <param name="m"></param>
    ''' <param name="var"></param>
    ''' <returns></returns>
    Public Delegate Function JuliaGetGlobalDelegate(m As IntPtr, var As IntPtr) As IntPtr

    ''' <summary>
    ''' jl_symbol
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    Public Delegate Function JuliaSymbolDelegate(<MarshalAs(UnmanagedType.LPStr)> str As String) As IntPtr

    ''' <summary>
    ''' jl_call1
    ''' </summary>
    ''' <param name="f"></param>
    ''' <param name="a"></param>
    ''' <returns></returns>
    Public Delegate Function JuliaCall1Delegate(f As IntPtr, a As IntPtr) As IntPtr

    ''' <summary>
    ''' jl_apply_array_type
    ''' </summary>
    ''' <param name="type"></param>
    ''' <param name="[dim]"></param>
    ''' <returns></returns>
    Public Delegate Function JuliaApplyArrayTypeDelegate(type As IntPtr, [dim] As ULong) As IntPtr

    ''' <summary>
    ''' jl_alloc_array_1d
    ''' </summary>
    ''' <param name="atype"></param>
    ''' <param name="nr"></param>
    ''' <returns></returns>
    Public Delegate Function JuliaAllocArray1DDelegate(atype As IntPtr, nr As size_t) As IntPtr

    ''' <summary>
    ''' jl_alloc_array_2d
    ''' </summary>
    ''' <param name="atype"></param>
    ''' <param name="nr"></param>
    ''' <param name="nc"></param>
    ''' <returns></returns>
    Public Delegate Function JuliaAllocArray2DDelegate(atype As IntPtr, nr As size_t, nc As size_t) As IntPtr

End Namespace
