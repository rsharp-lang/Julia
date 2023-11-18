Namespace Native

    ''' <summary>
    ''' jl_unbox_float64
    ''' </summary>
    ''' <param name="v"></param>
    ''' <returns></returns>
    Public Delegate Function julia_unbox_float64(v As IntPtr) As Double

    ''' <summary>
    ''' jl_box_float64
    ''' </summary>
    ''' <param name="x"></param>
    ''' <returns></returns>
    Public Delegate Function julia_box_float64(x As Double) As IntPtr

    ''' <summary>
    ''' jl_unbox_int64
    ''' </summary>
    ''' <param name="v"></param>
    ''' <returns></returns>
    Public Delegate Function julia_unbox_int64(v As IntPtr) As Long

    ''' <summary>
    ''' jl_box_int64
    ''' </summary>
    ''' <param name="x"></param>
    ''' <returns></returns>
    Public Delegate Function julia_box_int64(x As Long) As IntPtr

End Namespace