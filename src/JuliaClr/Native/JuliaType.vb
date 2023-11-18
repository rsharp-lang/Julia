Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports SMRUCC.Julia.Native.Platform.clr

Namespace Native

    Public Class JuliaType

        ReadOnly index As New Dictionary(Of Type, IntPtr)
        ReadOnly pointerTo As New Dictionary(Of IntPtr, Type)

        ''' <summary>
        ''' map julia type name to clr type
        ''' </summary>
        Shared ReadOnly typeof_str As New Dictionary(Of String, Type)
        Shared ReadOnly type_julia_name As New Dictionary(Of Type, String)
        Shared ReadOnly type_cache As New Dictionary(Of String, jlType)

        ''' <summary>
        ''' initialize the julia type system required of load of the handles:
        ''' 
        ''' + <see cref="JuliaNative.jl_float64_type"/>
        ''' + <see cref="JuliaNative.jl_int64_type"/>
        ''' </summary>
        Sub New()
            index = TypeForwardAttribute.LoadTypeForwards(pointerTo)

            For Each map In typeof_str
                type_cache(map.Key) = New jlType(map.Key, index(map.Value), map.Value)
            Next
        End Sub

        Shared Sub New()
            typeof_str("Float64") = GetType(Double)
            typeof_str("Float32") = GetType(Single)
            typeof_str("Float16") = GetType(Half)

            typeof_str("Int64") = GetType(Int64)
            typeof_str("Int32") = GetType(Int32)
            typeof_str("Int16") = GetType(Int16)
            typeof_str("Int8") = GetType(SByte)

            typeof_str("UInt64") = GetType(UInt64)
            typeof_str("UInt32") = GetType(UInt32)
            typeof_str("UInt16") = GetType(UInt16)
            typeof_str("UInt8") = GetType(Byte)

            typeof_str("Bool") = GetType(Boolean)

            For Each map In typeof_str
                type_julia_name(map.Value) = map.Key
            Next
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
                ' get primitive type directly from cache
                Return type_cache.ComputeIfAbsent(
                    key:=chars,
                    lazyValue:=AddressOf julia_native_primitive
                )
            ElseIf chars = "Array" Then
                ' could not be cached?
                Return julia_measure_array_type(x)
            Else
                ' needs to build composed type
                Throw New NotImplementedException
            End If
        End Function

        Private Shared Function julia_measure_array_type(x As IntPtr) As jlType
            Dim eltype = JuliaNative.julia_array_eltype(x)

            If JuliaNative.Type.pointerTo.ContainsKey(eltype) Then
                Dim clr As Type = JuliaNative.Type.pointerTo(eltype)
                Dim julia_name As String = type_julia_name(clr)
                Dim jl_eltype As jlType = type_cache(julia_name)

                Return New jlType(x, jl_eltype)
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