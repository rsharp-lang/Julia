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

    Friend Sub New(julia As String, native As IntPtr, clr As Type)
        Me.Name = julia
        Me.Native = native
        Me.Clr = clr
    End Sub

    Public Overrides Function ToString() As String
        Return $"[{Native.ToString}] {Name}@{Clr.FullName}"
    End Function

End Class
