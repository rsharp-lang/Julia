Imports System.Runtime.InteropServices
Imports SMRUCC.Julia.Native

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
                Case TypeCode.Boolean : Return JuliaNative.julia_unbox_bool(jl_out)
                Case TypeCode.Double : Return JuliaNative.julia_unbox_float64(jl_out)
                Case TypeCode.Int64 : Return JuliaNative.julia_unbox_int64(jl_out)
                Case TypeCode.Byte : Return JuliaNative.julia_unbox_uint8(jl_out)
                Case TypeCode.Empty : Return Nothing
                Case TypeCode.Int16 : Return JuliaNative.julia_unbox_int16(jl_out)
                Case TypeCode.Int32 : Return JuliaNative.julia_unbox_int32(jl_out)
                Case TypeCode.SByte : Return JuliaNative.julia_unbox_int8(jl_out)
                Case TypeCode.Single : Return JuliaNative.julia_unbox_float32(jl_out)
                Case TypeCode.String : Return Marshal.PtrToStringAuto(jl_out)
                Case TypeCode.UInt16 : Return JuliaNative.julia_unbox_uint16(jl_out)
                Case TypeCode.UInt32 : Return JuliaNative.julia_unbox_uint32(jl_out)
                Case TypeCode.UInt64 : Return JuliaNative.julia_unbox_uint64(jl_out)

                Case Else
                    Throw New NotImplementedException
            End Select
        End Function

    End Module
End Namespace