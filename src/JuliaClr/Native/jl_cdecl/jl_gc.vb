
Imports System.Runtime.InteropServices

Namespace Native.jl_cdecl

    Partial Class Cdecl

#Region "Controlling the Garbage Collector"

        ' There are some functions to control the GC. In normal use cases, these should not be necessary.

        ''' <summary>
        ''' Force a GC run
        ''' </summary>
        <DllImport(JuliaNative.LibraryName, EntryPoint:="jl_gc_collect", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_gc_collect()
        End Sub

        ''' <summary>
        ''' Enable/Disable the GC, return previous state as int
        ''' </summary>
        ''' <param name="on">
        ''' + 0: Disable the GC, return previous state as int
        ''' + 1: Enable the GC, return previous state as int
        ''' </param>
        ''' <returns></returns>
        ''' 
        <DllImport(JuliaNative.LibraryName, EntryPoint:="jl_gc_enable", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_gc_enable([on] As Integer) As Integer
        End Function

        ''' <summary>
        ''' Return current state as int
        ''' </summary>
        ''' <returns></returns>
        ''' 
        <DllImport(JuliaNative.LibraryName, EntryPoint:="jl_gc_is_enabled", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_gc_is_enabled() As Integer
        End Function
#End Region
    End Class
End Namespace