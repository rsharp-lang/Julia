Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports SMRUCC.Julia.Native.Platform.clr

Namespace Native

    Public Class JuliaType

        ReadOnly index As New Dictionary(Of Type, IntPtr)

        ''' <summary>
        ''' map julia type name to clr type
        ''' </summary>
        Shared ReadOnly typeof_str As New Dictionary(Of String, Type)

        ''' <summary>
        ''' initialize the julia type system required of load of the handles:
        ''' 
        ''' + <see cref="JuliaNative.jl_float64_type"/>
        ''' + <see cref="JuliaNative.jl_int64_type"/>
        ''' </summary>
        Sub New()
            index = TypeForwardAttribute.LoadTypeForwards
        End Sub

        Shared Sub New()
            typeof_str("Float64") = GetType(Double)
            typeof_str("Float32") = GetType(Single)
            typeof_str("Float16") = GetType(Half)
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

        Public Overloads Shared Function [GetType](x As IntPtr) As jlType
            ' get type name
            Dim typeof_str = JuliaNative.julia_typeof_str(x)
            Dim chars As String = Marshal.PtrToStringAnsi(typeof_str)

            If JuliaType.typeof_str.ContainsKey(chars) Then
                Static type_cache As New Dictionary(Of String, jlType)

                Return type_cache.ComputeIfAbsent(
                    key:=chars,
                    lazyValue:=AddressOf julia_native_primitive
                )
            Else
                Throw New NotImplementedException
            End If
        End Function

        Private Shared Function julia_native_primitive(julia_name As String) As jlType
            Dim clr As Type = JuliaType.typeof_str(julia_name)
            Dim native As IntPtr = JuliaNative.Type.GetType(clr)

            Return New jlType(julia_name, native, clr)
        End Function
    End Class
End Namespace