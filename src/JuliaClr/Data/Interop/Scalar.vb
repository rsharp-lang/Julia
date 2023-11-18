Namespace Data

    Public Module Scalar

        ''' <summary>
        ''' get scalar value from julia native to clr runtime
        ''' </summary>
        ''' <param name="jl_out"></param>
        ''' <returns></returns>
        Public Function GetValue(jl_out As IntPtr, type As jlType) As Object
            If type.GetKind = Native.JuliaTypeKinds.Primitive Then
                Return GetPrimitiveValue(jl_out, type)
            End If

            Throw New NotImplementedException
        End Function

        Public Function GetPrimitiveValue(jl_out As IntPtr, type As jlType) As Object
            Select Case type.GetTypeCode
                Case TypeCode.Boolean : Return New jlValue(Of Boolean)(jl_out)
                Case TypeCode.Double : Return New jlValue(Of Double)(jl_out).GetFloat64
                Case TypeCode.Int64 : Return New jlValue(Of Int64)(jl_out).GetInt64
                Case Else
                    Throw New NotImplementedException
            End Select
        End Function

    End Module
End Namespace