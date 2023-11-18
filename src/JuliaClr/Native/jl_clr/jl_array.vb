Imports size_t = System.UIntPtr

Namespace Native

    ''' <summary>
    ''' jl_apply_array_type
    ''' </summary>
    ''' <param name="type"></param>
    ''' <param name="[dim]"></param>
    ''' <returns></returns>
    Public Delegate Function julia_apply_array_type(type As IntPtr, [dim] As ULong) As IntPtr

    ''' <summary>
    ''' jl_alloc_array_1d
    ''' </summary>
    ''' <param name="atype"></param>
    ''' <param name="nr"></param>
    ''' <returns></returns>
    Public Delegate Function julia_alloc_array_1d(atype As IntPtr, nr As size_t) As IntPtr

    ''' <summary>
    ''' jl_alloc_array_2d
    ''' </summary>
    ''' <param name="atype"></param>
    ''' <param name="nr"></param>
    ''' <param name="nc"></param>
    ''' <returns></returns>
    Public Delegate Function julia_alloc_array_2d(atype As IntPtr, nr As size_t, nc As size_t) As IntPtr
End Namespace