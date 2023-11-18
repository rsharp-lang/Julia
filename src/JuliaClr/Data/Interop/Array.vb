Namespace Data

    Public Module Array

        ''' <summary>
        ''' get value from julia native to clr runtime
        ''' </summary>
        ''' <param name="jl_out"></param>
        ''' <param name="type"></param>
        ''' <returns></returns>
        Public Function GetValue(jl_out As IntPtr, type As jlType) As Object
            If Not type.IsArray Then
                Throw New InvalidProgramException($"data type '{type}' is not a array type!")
            End If

            Throw New NotImplementedException
        End Function
    End Module
End Namespace