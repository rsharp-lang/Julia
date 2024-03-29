﻿Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Text
Imports Microsoft.VisualBasic.Emit.Marshal.MarshalExtensions
Imports SMRUCC.Julia.Data
Imports SMRUCC.Julia.Native
Imports SMRUCC.Julia.Native.jl_cdecl
Imports size_t = System.UIntPtr

''' <summary>
''' n dimension tensor
''' </summary>
''' <typeparam name="T"></typeparam>
Public Class jlArray(Of T) : Inherits SafeHandle
    Implements IArray

    ReadOnly struc As jl_array_t

    Public ReadOnly Property Ndims As Integer Implements IArray.Ndims
        Get
            Return struc.flags.ndims
        End Get
    End Property

    Public ReadOnly Property Nrows As Integer Implements IArray.Nrows
        Get
            Return CInt(struc.nrows)
        End Get
    End Property

    Public ReadOnly Property Ncols As Integer Implements IArray.Ncols
        Get
            Return CInt(struc.ncols)
        End Get
    End Property

    Public ReadOnly Property Length As Integer Implements IArray.Length
        Get
            Return CInt(struc.length)
        End Get
    End Property

    Public Overrides ReadOnly Property IsInvalid As Boolean
        Get
            Return handle = IntPtr.Zero
        End Get
    End Property

    Private Sub New()
        MyBase.New(IntPtr.Zero, True)
        handle = IntPtr.Zero
    End Sub

    Public Sub New(handle As IntPtr)
        MyBase.New(handle, True)
        SetHandle(handle)
        struc = Marshal.PtrToStructure(Of jl_array_t)(handle)
    End Sub

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

    Public Shared Function Create1D(n As Integer) As jlArray(Of T)
        Dim elementType = JuliaNative.Type.GetType(Of T)
        Dim arrartype = JuliaNative.julia_apply_array_type(elementType, 1)
        Dim x = JuliaNative.julia_alloc_array_1d(arrartype, CType(n, size_t))

        Return New jlArray(Of T)(x)
    End Function

    Public Shared Function Create2D(nr As Integer, nc As Integer) As jlArray(Of T)
        Dim elementType = JuliaNative.Type.GetType(Of T)
        Dim arrartype = JuliaNative.julia_apply_array_type(elementType, 2)
        Dim x = JuliaNative.julia_alloc_array_2d(arrartype, CType(nr, size_t), CType(nc, size_t))

        Return New jlArray(Of T)(x)
    End Function

    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Function GetSpan() As T()
        Return struc.data.MarshalAs(Of T)(struc.length).RawBuffer
    End Function

    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Private Function IArray_GetSpan() As Array Implements IArray.GetSpan
        Return struc.data.MarshalAs(Of T)(struc.length).RawBuffer
    End Function

    Public Shared Widening Operator CType(ptr As IntPtr) As jlArray(Of T)
        Return New jlArray(Of T)(ptr)
    End Operator

    Public Shared Widening Operator CType(value As jlArray(Of T)) As IntPtr
        Return value.GetHandle()
    End Operator

    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder()
        Dim rs = Me.GetSpan()
        Dim ncols = Me.Ncols

        If Ndims = 1 Then
            sb.Append($"{Length}-element ")
            ncols = 1
        Else
            sb.Append($"{Nrows}×{Me.Ncols} ")
        End If

        sb.AppendLine($"Array{{{GetType(T).Name},{Ndims}}}:")

        For i = 0 To Nrows - 1
            For j = 0 To ncols - 1
                sb.Append(" " & rs(i * ncols + j).ToString())
            Next

            sb.AppendLine()
        Next

        Return sb.ToString()
    End Function
End Class

