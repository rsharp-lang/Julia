Imports System.Runtime.InteropServices
Imports System.Text
Imports JuliaSharp.Native

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

    Public Function GetInt64() As Long
        Return JuliaNative.UnboxInt64(handle)
    End Function

    Public Function GetFloat64() As Double
        Return JuliaNative.UnboxFloat64(handle)
    End Function

    Public Function [Get]() As T
        Select Case GetType(T).Name
            Case "Double"
                Return CType(Convert.ChangeType(GetFloat64(), GetType(T)), T)
            Case "Int64"
                Return CType(Convert.ChangeType(GetInt64(), GetType(T)), T)
            Case Else
                Throw New ArgumentException("仅支持基本数据类型")
        End Select
    End Function

    Private Shared Function Box(value As Long) As jlValue(Of T)
        Dim p = JuliaNative.BoxInt64(value)
        Return New jlValue(Of T)(p)
    End Function

    Private Shared Function Box(value As Double) As jlValue(Of T)
        Dim p = JuliaNative.BoxFloat64(value)
        Return New jlValue(Of T)(p)
    End Function

    Public Shared Function Create(value As T) As jlValue(Of T)
        Dim obj As Object = value

        Select Case value.GetType
            Case GetType(Double)
                Return JuliaSharp.jlValue(Of T).Box(CDbl(obj))
            Case GetType(Long)
                Return JuliaSharp.jlValue(Of T).Box(CLng(obj))
            Case Else
                Throw New System.ArgumentException("仅支持基本数据类型")
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
