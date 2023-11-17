Imports System.Reflection
Imports System.Runtime.InteropServices

Namespace Native.Platform.clr

    <AttributeUsage(AttributeTargets.Field, AllowMultiple:=False, Inherited:=False)>
    Public Class TypeForwardAttribute : Inherits Attribute

        Public ReadOnly Property clr As Type

        Sub New(clr_type As Type)
            Me.clr = clr_type
        End Sub

        Public Overrides Function ToString() As String
            Return $"@{clr.FullName}"
        End Function

        Public Shared Function LoadTypeForwards() As Dictionary(Of Type, IntPtr)
            Dim native As Type = GetType(JuliaNative)
            Dim fields = native.GetFields()
            Dim forwards As (forward As TypeForwardAttribute, d As FieldInfo)() = fields _
                .Where(Function(d) d.IsStatic) _
                .Select(Function(d)
                            Return (d.GetCustomAttribute(Of TypeForwardAttribute), d)
                        End Function) _
                .Where(Function(t) t.Item1 IsNot Nothing) _
                .ToArray
            Dim index As New Dictionary(Of Type, IntPtr)
            Dim native_ptr As IntPtr

            For Each map In forwards
                native_ptr = map.d.GetValue(Nothing)
                native_ptr = Marshal.ReadIntPtr(native_ptr)
                index(map.forward.clr) = native_ptr
            Next

            Return index
        End Function
    End Class
End Namespace