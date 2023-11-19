Imports SMRUCC.Julia.Native

Namespace Data

    Public Interface IArray

        ReadOnly Property Ndims As Integer
        ReadOnly Property Nrows As Integer
        ReadOnly Property Ncols As Integer
        ReadOnly Property Length As Integer

        Function GetSpan() As Array

    End Interface

    Public Module ArrayHelper

        ''' <summary>
        ''' get value from julia native to clr runtime
        ''' </summary>
        ''' <param name="jl_out"></param>
        ''' <param name="type"></param>
        ''' <returns></returns>
        Public Function GetValue(jl_out As System.IntPtr, type As jlType) As Object
            If Not type.IsArray Then
                Throw New InvalidProgramException($"data type '{type}' is not a array type!")
            End If

            Dim meta As IArray
            Dim data As Array

            Select Case type.ElementType.GetKind
                Case JuliaTypeKinds.Primitive
                    meta = CreateArray(jl_out, eltype:=type.ElementType)
                    data = meta.GetSpan
                Case Else
                    Throw New NotImplementedException
            End Select

            Throw New NotImplementedException
        End Function

        Private Function CreateArray(jl_out As System.IntPtr, eltype As jlType) As IArray
            Select Case eltype.GetTypeCode
                Case TypeCode.Boolean : Return New jlArray(Of Boolean)(jl_out)
                Case TypeCode.Byte : Return New jlArray(Of Byte)(jl_out)
                Case TypeCode.Char : Return New jlArray(Of Char)(jl_out)
                Case TypeCode.Double : Return New jlArray(Of Double)(jl_out)
                Case TypeCode.Int16 : Return New jlArray(Of Int16)(jl_out)
                Case TypeCode.Int32 : Return New jlArray(Of Int32)(jl_out)
                Case TypeCode.Int64 : Return New jlArray(Of Int64)(jl_out)
                Case TypeCode.SByte : Return New jlArray(Of SByte)(jl_out)
                Case TypeCode.Single : Return New jlArray(Of Single)(jl_out)
                Case TypeCode.String : Return New jlArray(Of String)(jl_out)
                Case TypeCode.UInt16 : Return New jlArray(Of UInt16)(jl_out)
                Case TypeCode.UInt32 : Return New jlArray(Of UInt32)(jl_out)
                Case TypeCode.UInt64 : Return New jlArray(Of UInt64)(jl_out)

                Case Else
                    Throw New NotImplementedException
            End Select
        End Function
    End Module
End Namespace