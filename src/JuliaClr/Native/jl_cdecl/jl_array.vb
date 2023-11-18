Imports System.Runtime.InteropServices
Imports size_t = System.UIntPtr

Namespace Native.jl_cdecl

    Partial Class Cdecl

        <DllImport(JuliaNative.LibraryName, EntryPoint:="jl_apply_array_type", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Function Jl_apply_array_type(type As IntPtr, [dim] As ULong) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, EntryPoint:="jl_alloc_array_1d", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Function Jl_alloc_array_1d(atype As IntPtr, nr As size_t) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, EntryPoint:="jl_alloc_array_2d", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Function Jl_alloc_array_2d(atype As IntPtr, nr As size_t, nc As size_t) As IntPtr
        End Function

    End Class
End Namespace