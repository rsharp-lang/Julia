Imports System.Runtime.InteropServices
Imports size_t = System.UIntPtr

Namespace Native.jl_cdecl

    <StructLayout(LayoutKind.Sequential)> Public Structure jl_array_t
        Public data As IntPtr
        Public length As size_t
        Public flags As jl_array_flags_t
        ''' <summary>
        ''' element size including alignment (dim 1 memory stride)
        ''' </summary>
        Public elsize As UShort
        ''' <summary>
        ''' for 1-d only. does not need to get big.
        ''' </summary>
        Public offset As UInteger
        Public nrows As size_t
        'public size_t maxsize;// 1d
        Public ncols As size_t ' Nd
    End Structure
End Namespace