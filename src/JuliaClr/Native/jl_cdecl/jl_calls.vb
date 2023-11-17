Imports System.Runtime.InteropServices

Namespace Native.jl_cdecl

    Partial Class Cdecl

        <DllImport(JuliaNative.LibraryName, EntryPoint:="jl_call1", CallingConvention:=CallingConvention.Cdecl)>
        Friend Shared Function Jl_call1(f As IntPtr, a As IntPtr) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_call0(f As IntPtr) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_call2(f As IntPtr, arg1 As IntPtr, arg2 As IntPtr) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_call3(f As IntPtr, arg1 As IntPtr, arg2 As IntPtr, arg3 As IntPtr) As IntPtr
        End Function
    End Class
End Namespace