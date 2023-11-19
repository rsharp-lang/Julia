Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports SMRUCC.Julia
Imports SMRUCC.Julia.Data
Imports SMRUCC.Julia.Native
Imports SMRUCC.Rsharp.Interpreter
Imports SMRUCC.Rsharp.Runtime
Imports SMRUCC.Rsharp.Runtime.Internal.Object
Imports SMRUCC.Rsharp.Runtime.Interop
Imports SMRUCC.Rsharp.Runtime.Vectorization

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
        Call JuliaNative.julia_atexit_hook(code)
    End Sub

    <ExportAPI("jl_eval_string")>
    Public Function jl_eval_string(<RRawVectorArgument> expr As Object, Optional env As Environment = Nothing) As Object
        Dim s_exprs As String() = CLRVector.asCharacter(expr)
        Dim jl_out As Object

        If s_exprs.IsNullOrEmpty Then
            Return Nothing
        ElseIf s_exprs.Length = 1 Then
            Return eval_string_single(s_exprs(0), env)
        End If

        Dim eval As New list With {.slots = New Dictionary(Of String, Object)}
        Dim i As i32 = 1

        For Each s As String In s_exprs
            jl_out = eval_string_single(s, env)

            If Program.isException(jl_out) Then
                Return jl_out
            End If

            eval.add($"#{++i}", jl_out)
        Next

        Return eval
    End Function

    Private Function eval_string_single(s As String, env As Environment) As Object
        Dim jl_out As IntPtr = JuliaNative.julia_eval_string(s)
        Dim type As jlType = jlType.GetType(jl_out)

        Select Case type.GetKind
            Case JuliaTypeKinds.Primitive
                ' primitive scalar value
                Return Scalar.GetPrimitiveValue(jl_out, type)
            Case JuliaTypeKinds.Array
                Return ArrayHelper.GetValue(jl_out, type)
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
End Module
