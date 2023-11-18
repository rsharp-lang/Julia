Imports System.Runtime.InteropServices
Imports SMRUCC.Julia
Imports SMRUCC.Julia.Native

Module Program
    Sub Main(args As String())

        JuliaNative.LoadDll("C:\Users\Administrator\AppData\Local\Programs\Julia-1.9.4\bin\libjulia.dll")

        JuliaNative.julia_eval_string("println(123)")

        Dim val_p = JuliaNative.julia_eval_string("sqrt(2.0)")
        Dim typeof_str = JuliaNative.julia_typeof_str(val_p)
        ' Dim chars As jlArray(Of Char) = typeof_str
        Dim chars = Marshal.PtrToStringAnsi(typeof_str)


        Dim type As jlType = Native.JuliaType.GetType(val_p)
        Dim type2 As jlType = Native.JuliaType.GetType(JuliaNative.julia_eval_string("1"))
        Dim type3 As jlType = Native.JuliaType.GetType(JuliaNative.julia_eval_string("0x1234567"))
        Dim type4 As jlType = Native.JuliaType.GetType(JuliaNative.julia_eval_string("true"))
        Dim type5 As jlType = Native.JuliaType.GetType(JuliaNative.julia_eval_string("rand(1,3)"))

        Dim r As jlValue(Of Double) = JuliaNative.julia_eval_string("sqrt(2.0)")
        Dim d As Double = r
        Console.WriteLine($"{d}")

        Dim s2 As jlValue(Of Long) = 2
        Dim s3 As Long = s2
        Console.WriteLine($"{s3}")

        ' Dim da = jlArray(Of Double).Create1D(10)
        ' Console.WriteLine(da)

        Dim db As jlArray(Of Double) = JuliaNative.julia_eval_string("rand(1,3)")
        Console.WriteLine(db)

        Dim dc As jlArray(Of Double) = JuliaNative.julia_eval_string("rand(10,4)")
        Console.WriteLine(dc)

        Dim dd As jlArray(Of Double) = JuliaNative.julia_eval_string("rand(3,1)")
        Console.WriteLine(dd)

        Dim de As jlArray(Of Long) = JuliaNative.julia_eval_string("ones(Int64, 2, 2)")
        Console.WriteLine(de)

        JuliaNative.julia_atexit_hook(0)

        Pause()
    End Sub
End Module
