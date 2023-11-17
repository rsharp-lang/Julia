Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports SMRUCC.Julia.Native

''' <summary>
''' access to the julia native runtime
''' </summary>
<Package(".interop")>
Public Module Interop

    Sub New()

    End Sub

    ''' <summary>
    ''' try to start the julia environment
    ''' </summary>
    ''' <param name="libjulia"></param>
    ''' <returns></returns>
    ''' 
    <ExportAPI("start_jl")>
    Public Function start(libjulia As String) As Object
        Call JuliaNative.LoadDll(fileName:=libjulia)
        Return Nothing
    End Function

    <ExportAPI("jl_gc")>
    Public Sub gc()
        Call JuliaNative.julia_gc_collect()
    End Sub

    <ExportAPI("jl_exit")>
    Public Sub close(Optional code As Integer = 0)
        Call JuliaNative.AtExitHook(code)
    End Sub

End Module
