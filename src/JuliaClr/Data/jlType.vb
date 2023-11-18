Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Scripting.Runtime
Imports SMRUCC.Julia.Native

''' <summary>
''' A single data type instance
''' </summary>
Public Class jlType

    ''' <summary>
    ''' the type name in julia runtime
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Name As String
    ''' <summary>
    ''' julia native type
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Native As IntPtr
    ''' <summary>
    ''' clr managed type
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Clr As Type
    Public ReadOnly Property IsArray As Boolean
    ''' <summary>
    ''' get array element type
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property ElementType As jlType

    Friend Sub New(julia As String, native As IntPtr, clr As Type)
        Me.Name = julia
        Me.Native = native
        Me.Clr = clr
    End Sub

    Friend Sub New(array As IntPtr, eltype As jlType)
        Me.Native = array
        Me.Name = $"Array{{{eltype}}}"
        Me.Clr = GetType(System.Array)
        Me.ElementType = eltype
        Me.IsArray = True
    End Sub

    Public Function GetKind() As JuliaTypeKinds
        If JuliaNative.Type.IsPrimitive(Native) Then
            Return JuliaTypeKinds.Primitive
        ElseIf IsArray Then
            Return JuliaTypeKinds.Array
        Else
            Return JuliaTypeKinds.NA
        End If
    End Function

    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Function GetTypeCode() As TypeCode
        Return Clr.PrimitiveTypeCode
    End Function

    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Overloads Shared Function [GetType](x As IntPtr) As jlType
        Return JuliaType.GetType(x)
    End Function

    Public Overrides Function ToString() As String
        Return $"[{Native.ToInt64.ToHexString}] {Name}@{Clr.FullName}"
    End Function

End Class
