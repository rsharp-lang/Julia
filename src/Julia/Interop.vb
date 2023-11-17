Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports SMRUCC.Julia.Native

<Package("interop")>
Public Module Interop

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

End Module
