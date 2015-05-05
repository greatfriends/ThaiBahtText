' ---- By Suthep Sangvirotjanaphat
' ---- Since 1996

Public Class ThaiBahtTextUtil

  ' ---- Internal use only.
  Private Shared s1 As String    ' ---- ส่วนที่เกินหลักล้านขึ้นไป  (ล้าน)
  Private Shared s2 As String    ' ---- ส่วนจำนวนเต็ม              (บาท)
  Private Shared s3 As String    ' ---- ส่วนสตางค์                 (สตางค์)
  Private Shared suffix() As String = {"", "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน"}
  Private Shared numSpeak() As String = _
      {"", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า"}

  Public Shared Function ThaiBahtText(ByVal m As Decimal) As String
    Dim result As String

    If (m = 0) Then Return "ศูนย์บาทถ้วน"

    splitCurr(m)            ' now 'm' split to 3 parts in 's1' & 's2' & 's3'

    result = ""
    If (Len(s1) > 0) Then result = result & Speak(s1) & "ล้าน"
    If (Len(s2) > 0) Then result = result & Speak(s2) & "บาท"
    If (Len(s3) > 0) Then
      result = result & speakStang(s3) & "สตางค์"
    Else
      result = result & "ถ้วน"
    End If

    Return (result)
  End Function

  Private Shared Function Speak(ByVal s As String) As String
    Dim i, L As Integer
    Dim c As Integer
    Dim result As String

    If (s = "") Then Return ""

    result = ""

    L = Len(s)

    For i = 1 To L
      If (Mid$(s, i, 1) = "-") Then
        result = result & "ติดลบ"
      Else
        c = CInt(Mid$(s, i, 1))
        If ((i = L) And (c = 1)) Then
          If (L = 1) Then Speak = "หนึ่ง" : Exit Function
          If (L > 1) And (Mid$(s, L - 1, 1) = "0") Then
            result = result & "หนึ่ง"
          Else
            result = result & "เอ็ด"
          End If
        ElseIf ((i = L - 1) And (c = 2)) Then
          result = result & "ยี่สิบ"
        ElseIf ((i = L - 1) And (c = 1)) Then
          result = result & "สิบ"
        Else
          If (c <> 0) Then
            result = result & numSpeak(c) & suffix(L - i + 1)
          End If
        End If
      End If
    Next

    Return (result)
  End Function

  Private Shared Function speakStang(ByVal s As String) As String
    Dim i, L As Integer
    Dim c As Integer
    Dim result As String

    L = Len(s)
    If (L = 0) Then Return ""
    If (L = 1) Then s = s & "0" : L = 2
    If (L > 2) Then s = Left$(s, 2) : L = 2

    result = ""

    For i = 1 To 2
      c = CInt(Mid$(s, i, 1))

      If ((i = L) And (c = 1)) Then
        If (CInt(Mid$(s, 1, 1)) = 0) Then
          result = result & "หนึ่ง"
          Exit For
        End If
        result = result & "เอ็ด"
      ElseIf ((i = L - 1) And (c = 2)) Then
        result = result & "ยี่สิบ"
      ElseIf ((i = L - 1) And (c = 1)) Then
        result = result & "สิบ"
      Else
        If (c <> 0) Then
          result = result & numSpeak(c) & suffix(2 - i + 1)
        End If
      End If
    Next

    Return (result)
  End Function

  Private Shared Sub splitCurr(ByVal m As Double)
    Dim s As String
    Dim L, position As Integer

    s = CStr(m)
    position = InStr(1, s, ".")
    If (position <> 0) Then
      'this currency have a point
      s1 = Mid$(s, 1, position - 1)
      s3 = Mid$(s, position + 1, 2)
      If s3 = "00" Then
        s3 = ""
      End If
    Else
      s1 = s
      s3 = ""
    End If

    L = Len(s1)
    If (L > 6) Then
      s2 = Mid$(s1, L - 5, 99)
      s1 = Mid$(s1, 1, L - 6)
    Else
      s2 = s1
      s1 = ""
    End If

    If (Not IsNumeric(s1)) Then s1 = ""
    If (Not IsNumeric(s2)) Then s2 = ""
    If (Val(s1) = 0) Then s1 = ""
    If (Val(s2) = 0) Then s2 = ""
  End Sub

End Class