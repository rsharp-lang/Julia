
Imports System.Runtime.InteropServices

Namespace Native.jl_cdecl

    Partial Class Cdecl

#Region "data unbox"
        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_unbox_float64(t As IntPtr) As Double
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_unbox_float32(t As IntPtr) As Single
        End Function

        <DllImport(JuliaNative.LibraryName, EntryPoint:="jl_unbox_int64", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Function Jl_unbox_int64(v As IntPtr) As Long
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_unbox_int32(t As IntPtr) As Integer
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_unbox_int16(t As IntPtr) As Short
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_unbox_int8(t As IntPtr) As SByte
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_unbox_bool(t As IntPtr) As Boolean
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_unbox_uint64(t As IntPtr) As ULong
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_unbox_uint32(t As IntPtr) As UInteger
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_unbox_uint16(t As IntPtr) As UShort
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_unbox_uint8(t As IntPtr) As Byte
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_unbox_voidpointer(v As IntPtr) As IntPtr
        End Function
#End Region

#Region "boxing"
        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_box_float64(t As Double) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_box_float32(t As Single) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, EntryPoint:="jl_box_int64", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Function Jl_box_int64(x As Long) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_box_int32(t As Integer) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_box_int16(t As Short) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_box_int8(t As SByte) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_box_bool(t As Boolean) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_box_uint64(t As ULong) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_box_uint32(t As UInteger) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_box_uint16(t As UShort) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_box_uint8(t As Byte) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_box_voidpointer(x As IntPtr) As IntPtr
        End Function
#End Region

        ''' <summary>
        ''' JL_DLLEXPORT const char *jl_string_ptr(jl_value_t *s);
        ''' </summary>
        ''' <param name="s"></param>
        ''' <returns></returns>
        ''' 
        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_string_ptr(s As IntPtr) As IntPtr
        End Function
    End Class
End Namespace