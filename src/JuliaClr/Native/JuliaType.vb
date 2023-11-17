Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports SMRUCC.Julia.Native.Platform.clr

Namespace Native

    Public Class JuliaType

        ReadOnly index As New Dictionary(Of Type, IntPtr)

        ''' <summary>
        ''' initialize the julia type system required of load of the handles:
        ''' 
        ''' + <see cref="JuliaNative.jl_float64_type"/>
        ''' + <see cref="JuliaNative.jl_int64_type"/>
        ''' </summary>
        Sub New()
            index = TypeForwardAttribute.LoadTypeForwards
        End Sub

        Public Overloads Function [GetType](Of T)() As IntPtr
            If index.ContainsKey(GetType(T)) Then
                Return index(GetType(T))
            Else
                Throw err(GetType(T))
            End If
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
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
End Namespace