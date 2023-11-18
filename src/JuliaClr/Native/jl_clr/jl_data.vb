Imports System.Runtime.InteropServices

Namespace Native

    ''' <summary>
    ''' jl_box_int64
    ''' </summary>
    ''' <param name="x"></param>
    ''' <returns></returns>
    Public Delegate Function julia_box_int64(x As Long) As IntPtr

    ''' <summary>
    ''' jl_box_float64
    ''' </summary>
    ''' <param name="x"></param>
    ''' <returns></returns>
    Public Delegate Function julia_box_float64(x As Double) As IntPtr

    ''' <summary>
    ''' jl_unbox_float64
    ''' </summary>
    ''' <param name="v"></param>
    ''' <returns></returns>
    Public Delegate Function julia_unbox_float64(v As IntPtr) As Double

    ''' <summary>
    ''' jl_unbox_int64
    ''' </summary>
    ''' <param name="v"></param>
    ''' <returns></returns>
    Public Delegate Function julia_unbox_int64(v As IntPtr) As Long

    Public Delegate Function julia_unbox_float32(t As IntPtr) As Single
    Public Delegate Function julia_unbox_int32(t As IntPtr) As Integer
    Public Delegate Function julia_unbox_int16(t As IntPtr) As Short
    Public Delegate Function julia_unbox_int8(t As IntPtr) As SByte
    Public Delegate Function julia_unbox_bool(t As IntPtr) As Boolean
    Public Delegate Function julia_unbox_uint64(t As IntPtr) As ULong
    Public Delegate Function julia_unbox_uint32(t As IntPtr) As UInteger
    Public Delegate Function julia_unbox_uint16(t As IntPtr) As UShort
    Public Delegate Function julia_unbox_uint8(t As IntPtr) As Byte
    Public Delegate Function julia_unbox_voidpointer(v As IntPtr) As IntPtr

End Namespace