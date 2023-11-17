Imports System
Imports JuliaSharp
Imports JuliaSharp.Native

Module Program
    Sub Main(args As String())

        JuliaNative.LoadDll("C:\Users\Administrator\AppData\Local\Programs\Julia-1.9.4\bin\libjulia.dll")

        JuliaNative.InitThreading()
        JuliaNative.EvalString("println(123)")

        Dim r As JuliaValue(Of Double) = JuliaNative.EvalString("sqrt(2.0)")
        Dim d As Double = r
        Console.WriteLine($"{d}")

        Dim s2 As JuliaValue(Of Long) = 2
        Dim s3 As Long = s2
        Console.WriteLine($"{s3}")

        'Dim da = JuliaArray(Of Double).Create1D(10)
        'Console.WriteLine(da)

        Dim db As JuliaArray(Of Double) = JuliaNative.EvalString("rand(1,3)")
        Console.WriteLine(db)

        Dim dc As JuliaArray(Of Double) = JuliaNative.EvalString("rand(10,4)")
        Console.WriteLine(dc)

        Dim dd As JuliaArray(Of Double) = JuliaNative.EvalString("rand(3,1)")
        Console.WriteLine(dd)

        Dim de As JuliaArray(Of Long) = JuliaNative.EvalString("ones(Int64, 2, 2)")
        Console.WriteLine(de)

        JuliaNative.AtExitHook(0)

        Pause()
    End Sub
End Module
