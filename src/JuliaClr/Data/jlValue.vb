Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports SMRUCC.Julia.Data
Imports SMRUCC.Julia.Native

''' <summary>
''' any scalar value
''' </summary>
''' <typeparam name="T"></typeparam>
Public Class jlValue(Of T As IConvertible) : Inherits SafeHandle

    Private Sub New()
        MyBase.New(IntPtr.Zero, True)
        handle = IntPtr.Zero
    End Sub

    Public Sub New(handle As IntPtr)
        MyBase.New(handle, True)
        SetHandle(handle)
    End Sub

    Public Overrides ReadOnly Property IsInvalid As Boolean
        Get
            Return handle = IntPtr.Zero
        End Get
    End Property

    Protected Overrides Function ReleaseHandle() As Boolean
        Return True
    End Function

    Public Function GetHandle() As IntPtr
        If IsInvalid Then
            Throw New Exception("The handle is invalid.")
        Else
            Dim bSuccess = False
            DangerousAddRef(bSuccess)
            Return handle
        End If
    End Function

    Public Sub ReturnHandle(h As IntPtr)
        If h = handle AndAlso Not IsInvalid Then
            DangerousRelease()
        End If
    End Sub

    <MethodImpl(MethodImplOptions.AggressiveInlining)> Public Function GetInt64() As Long
        Return JuliaNative.julia_unbox_int64(handle)
    End Function

    <MethodImpl(MethodImplOptions.AggressiveInlining)> Public Function GetFloat64() As Double
        Return JuliaNative.julia_unbox_float64(handle)
    End Function

    <MethodImpl(MethodImplOptions.AggressiveInlining)> Public Function GetFloat32() As Single
        Return JuliaNative.julia_unbox_float32(handle)
    End Function

    <MethodImpl(MethodImplOptions.AggressiveInlining)> Public Function GetInt32() As Half
        Return JuliaNative.julia_unbox_int32(handle)
    End Function

    <MethodImpl(MethodImplOptions.AggressiveInlining)> Public Function GetInt16() As Short
        Return JuliaNative.julia_unbox_int16(handle)
    End Function

    <MethodImpl(MethodImplOptions.AggressiveInlining)> Public Function GetBoolean() As Boolean
        Return JuliaNative.julia_unbox_bool(handle)
    End Function

    <MethodImpl(MethodImplOptions.AggressiveInlining)> Public Function GetUInt64() As UInt64
        Return JuliaNative.julia_unbox_uint64(handle)
    End Function

    <MethodImpl(MethodImplOptions.AggressiveInlining)> Public Function GetUInt32() As UInt32
        Return JuliaNative.julia_unbox_uint32(handle)
    End Function

    <MethodImpl(MethodImplOptions.AggressiveInlining)> Public Function GetUInt16() As UInt16
        Return JuliaNative.julia_unbox_uint16(handle)
    End Function

    <MethodImpl(MethodImplOptions.AggressiveInlining)> Public Function GetInt8() As SByte
        Return JuliaNative.julia_unbox_int8(handle)
    End Function

    <MethodImpl(MethodImplOptions.AggressiveInlining)> Public Function GetUInt8() As Byte
        Return JuliaNative.julia_unbox_uint8(handle)
    End Function

    <MethodImpl(MethodImplOptions.AggressiveInlining)> Public Function GetString() As String
        Return Scalar.getValueString(handle)
    End Function

    ''' <summary>
    ''' get scalar value
    ''' </summary>
    ''' <returns></returns>
    Public Function [Get]() As T
        Select Case GetType(T)
            Case GetType(Double) : Return CObj(GetFloat64())
            Case GetType(Int64) : Return CObj(GetInt64())
            Case GetType(Int32) : Return CObj(GetInt32())
            Case GetType(Int16) : Return CObj(GetInt16())
            Case GetType(Single) : Return CObj(GetFloat32())
            Case GetType(UInt16) : Return CObj(GetUInt16())
            Case GetType(UInt32) : Return CObj(GetUInt32())
            Case GetType(UInt64) : Return CObj(GetUInt64())
            Case GetType(Boolean) : Return CObj(GetBoolean())
            Case GetType(Byte) : Return CObj(GetUInt8())
            Case GetType(SByte) : Return CObj(GetInt8())
            Case GetType(String) : Return CObj(GetString())

            Case Else
                Throw New ArgumentException("primitive data type only!")
        End Select
    End Function

    Private Shared Function Box(value As Long) As jlValue(Of T)
        Return New jlValue(Of T)(JuliaNative.julia_box_int64(value))
    End Function

    Private Shared Function Box(value As Double) As jlValue(Of T)
        Return New jlValue(Of T)(JuliaNative.julia_box_float64(value))
    End Function

    Public Shared Function Create(value As T) As jlValue(Of T)
        Dim obj As Object = value

        Select Case GetType(T)
            Case GetType(Double) : Return jlValue(Of T).Box(CDbl(obj))
            Case GetType(Long) : Return jlValue(Of T).Box(CLng(obj))

            Case Else
                Throw New ArgumentException("supports the primitive data type only!")
        End Select
    End Function

    Public Shared Widening Operator CType(ptr As IntPtr) As jlValue(Of T)
        Return New jlValue(Of T)(ptr)
    End Operator

    Public Shared Widening Operator CType(value As jlValue(Of T)) As IntPtr
        Return value.GetHandle()
    End Operator

    Public Shared Widening Operator CType(value As jlValue(Of T)) As T
        Return value.Get()
    End Operator

    Public Shared Widening Operator CType(value As T) As jlValue(Of T)
        Return Create(value)
    End Operator
End Class
