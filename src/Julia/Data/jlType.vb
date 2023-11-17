Imports System.Runtime.InteropServices
Imports JuliaSharp.Native

Public Class jlType

    ReadOnly index As New Dictionary(Of Type, IntPtr)() From {
        {GetType(Double), Marshal.ReadIntPtr(JuliaNative.Float64Type)},
        {GetType(Long), Marshal.ReadIntPtr(JuliaNative.Int64Type)}
    }

    ''' <summary>
    ''' initialize the julia type system required of load of the handles:
    ''' 
    ''' + <see cref="JuliaNative.Float64Type"/>
    ''' + <see cref="JuliaNative.Int64Type"/>
    ''' </summary>
    Sub New()
    End Sub

    Public Overloads Function [GetType](Of T)() As IntPtr
        If index.ContainsKey(GetType(T)) Then
            Return index(GetType(T))
        Else
            Throw err(GetType(T))
        End If
    End Function

    Private Shared Function err(t As Type) As Exception
        Return New InvalidComObjectException(t.FullName)
    End Function

    ''' <summary>
    ''' translate .net clr type to julia type
    ''' </summary>
    ''' <param name="t"></param>
    ''' <returns></returns>
    Public Overloads Function [GetType](t As Type) As IntPtr
        If index.ContainsKey(t) Then
            Return index(t)
        Else
            Throw err(t)
        End If
    End Function

End Class
