Imports System.Runtime.InteropServices

Namespace Native.jl_cdecl

    <StructLayout(LayoutKind.Sequential)> Public Structure jl_array_flags_t

        Public aggr_byte As UShort

        ''' <summary>
        ''' how - allocation style
        ''' 0 = data Is inlined, Or a foreign pointer we don't manage
        ''' 1 = julia-allocated buffer that needs to be marked
        ''' 2 = malloc-allocated pointer this array object manages
        ''' 3 = has a pointer to the object that owns the data
        ''' </summary>
        ''' <returns></returns>
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
                Return aggr_byte >> 11 And &H1
            End Get
        End Property

        ''' <summary>
        ''' representation is pointer array
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property ptarray As UShort
            Get
                Return aggr_byte >> 12 And &H1
            End Get
        End Property

        ''' <summary>
        ''' representation has embedded pointers
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property hasptr As UShort
            Get
                Return aggr_byte >> 13 And &H1
            End Get
        End Property

        ''' <summary>
        ''' data is shared by multiple Arrays
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property isshared As UShort
            Get
                Return aggr_byte >> 14 And &H1
            End Get
        End Property

        ''' <summary>
        ''' data allocated with memalign
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property isaligned As UShort
            Get
                Return aggr_byte >> 15 And &H1
            End Get
        End Property

    End Structure

End Namespace