Imports Newtonsoft.Json

Public Class Card
    Public Property FrontContent As String
    Public Property BackContent As String
    Public Property Status As String ' 用来保存卡片的状态

    Public Property CorrectCount As Integer
    Public Property IncorrectCount As Integer

    ' 构造函数
    Public Sub New(frontContent As String, backContent As String)
        Me.FrontContent = frontContent
        Me.BackContent = backContent
        Me.Status = "本轮未复习"
        Me.CorrectCount = 0
        Me.IncorrectCount = 0
    End Sub

    ' 显示卡片的正面内容
    Public Overrides Function ToString() As String
        Return FrontContent
    End Function
End Class
