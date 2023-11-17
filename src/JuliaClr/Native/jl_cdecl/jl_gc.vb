
Imports System.Runtime.InteropServices

Namespace Native.jl_cdecl

    Partial Class Cdecl

#Region "Controlling the Garbage Collector"

        ' There are some functions to control the GC. In normal use cases, these should not be necessary.

        ''' <summary>
        ''' Force a GC run
        ''' </summary>
        <DllImport(JuliaNative.LibraryName, EntryPoint:="jl_gc_collect", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function Jl_gc_collect() As UInteger
        End Function

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
        Public Shared Function Jl_gc_enable([on] As UInteger) As UInteger
        End Function

        ''' <summary>
        ''' Return current state as int
        ''' </summary>
        ''' <returns></returns>
        ''' 
        <DllImport(JuliaNative.LibraryName, EntryPoint:="jl_gc_is_enabled", CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function Jl_gc_is_enabled() As UInteger
        End Function

        Public Enum JLGCCollection
            JL_GC_AUTO = 0         ' use heuristics to determine the collection type
            JL_GC_FULL = 1         ' force a full collection
            JL_GC_INCREMENTAL = 2  ' force an incremental collection
        End Enum

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_gc_collect(c As JLGCCollection)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_gc_add_finalizer(v As IntPtr, f As IntPtr)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_gc_add_ptr_finalizer(ptls As IntPtr, v As IntPtr, f As IntPtr)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_finalize(o As IntPtr)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_gc_new_weakref(value As IntPtr) As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_gc_alloc_0w() As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_gc_alloc_1w() As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_gc_alloc_2w() As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_gc_alloc_3w() As IntPtr
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_gc_use(a As IntPtr)
        End Sub

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Sub jl_clear_malloc_data()
        End Sub
#End Region

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_subtype(a As IntPtr, b As IntPtr) As Integer
        End Function

        <DllImport(JuliaNative.LibraryName, CallingConvention:=CallingConvention.Cdecl)>
        Public Shared Function jl_isa(a As IntPtr, t As IntPtr) As Integer
        End Function

    End Class
End Namespace