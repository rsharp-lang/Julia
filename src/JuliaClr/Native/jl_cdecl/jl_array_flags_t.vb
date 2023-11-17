Imports System.Runtime.InteropServices

Namespace Native.jl_cdecl

    <StructLayout(LayoutKind.Sequential)> Public Structure jl_array_flags_t

        Public aggr_byte As UShort

        Public ReadOnly Property how As UShort
            Get
                Return aggr_byte And &H3
            End Get
        End Property

        Public ReadOnly Property ndims As UShort
            Get
                Return aggr_byte >> 2 And &H3FF
            End Get
        End Property

        Public ReadOnly Property pooled As UShort
            Get
                Return aggr_byte >> 12 And &H1
            End Get
        End Property

        Public ReadOnly Property ptarray As UShort
            Get
                Return aggr_byte >> 13 And &H1
            End Get
        End Property

        Public ReadOnly Property isshared As UShort
            Get
                Return aggr_byte >> 14 And &H1
            End Get
        End Property

        Public ReadOnly Property isaligned As UShort
            Get
                Return aggr_byte >> 15 And &H1
            End Get
        End Property

    End Structure

End Namespace