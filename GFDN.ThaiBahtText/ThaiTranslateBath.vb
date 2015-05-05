Imports Extension = System.Runtime.CompilerServices.ExtensionAttribute

Public Module Extensions
    <Extension>
    Public Function Bath(Input As Integer) As String
        If Input = 0 Then Return OVal
        If Input < 0 Then Input *= -1
        Return Thai.Translate(Input)
    End Function

    <Extension>
    Public Function Bath(Input As UInteger) As String
        If Input = 0 Then Return OVal
        Return Thai.Translate(Input)
    End Function

    <Extension>
    Public Function Bath(Input As Long) As String
        If Input = 0 Then Return OVal
        If Input < 0 Then Input *= -1
        Return Thai.Translate(Input)
    End Function

    <Extension>
    Public Function Bath(Input As ULong) As String
        If Input = 0 Then Return OVal
        Return Thai.Translate(Input)
    End Function

    <Extension>
    Public Function Bath(Input As Single) As String
        If Input = 0 Then Return OVal
        If Input < 0 Then Input *= -1
        Return Thai.Translate(Input)
    End Function

    <Extension>
    Public Function Bath(Input As Double) As String
        If Input = 0 Then Return OVal
        If Input < 0 Then Input *= -1
        Return Thai.Translate(Input)
    End Function

    <Extension>
    Public Function Bath(Input As Decimal) As String
        If Input = 0 Then Return OVal
        If Input < 0 Then Input *= -1
        Return Thai.Translate(Input)
    End Function
End Module

Public Module Thai
    Friend Const OVal As String = "ศูนย์บาทถ้วน"

    Private Scale() As String = {"ล้าน", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน"}
    Private Figures() As String = {"", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า"}

    Friend Function Translate(Input As String) As String
        Dim Data = Input.Split(".")
        Dim Text = Data(0)

        With New Text.StringBuilder
            .Append(Decompose(Text))
            .Append("บาท")
            If Val(Text(Text.Length - 1)) = 0 And Data.Length = 1 Then .Append("ถ้วน")
            If Data.Length > 1 Then
                .Append(" ")
                Text = Data(1)
                If Text.Length > 2 Then Text = Text.Remove(2)
                If Text.Length = 1 Then Text += "0"
                .Append(Decompose(Text))
                .Append("สตางค์")
            End If

            Return .ToString
        End With
    End Function

    Private Function Decompose(Base As String) As String
        Dim Length = Base.Length - 1
        Dim Count = Length
        Dim Value, Position As Integer

        With New Text.StringBuilder
            For i = 0 To Count
                Value = Val(Base(i))
                Position = Count Mod 6

                Select Case True
                    Case Value = 0 'And Position > 0
                        Exit Select
                    Case Value = 1 And Position = 1
                        .Append(Scale(1))
                    Case Value = 2 And Position = 1
                        .Append("ยี่สิบ")
                    Case Value = 1 And Position = 0 And Length > 0
                        .Append("เอ็ด")
                    Case Position = 0 And Count = 0
                        .Append(Figures(Value))
                    Case Else
                        .Append(Figures(Value))
                        .Append(Scale(Position))
                End Select

                Count -= 1
            Next

            Return .ToString
        End With
    End Function

End Module
