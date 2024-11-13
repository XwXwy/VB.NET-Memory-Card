Imports Newtonsoft.Json
Imports System.IO

Public Class Form1
    ' 定义卡片列表
    Private CardList As New List(Of Card)()
    Private ReviewedCards As New List(Of Card)() ' 本轮已复习的卡片
    Private UnreviewedCards As New List(Of Card)() ' 本轮未复习的卡片
    Private MemorizedCards As New List(Of Card)() ' 已熟记的卡片
    Private selectedCard As Card

    ' 存储文件路径
    Private Const FilePath As String = "cards.json"

    ' 窗口加载时读取卡片数据
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 读取卡片数据
        LoadCardsFromFile()

        ' 设置默认选择“全部卡片”
        ComboBox1.SelectedIndex = 0
    End Sub

    ' 保存卡片数据到文件
    Private Sub SaveCardsToFile()
        Try
            ' 将 CardList 序列化为 JSON 字符串
            Dim json As String = JsonConvert.SerializeObject(CardList, Formatting.Indented)

            ' 写入文件
            File.WriteAllText(FilePath, json)

            'MessageBox.Show("卡片数据已保存！", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("保存卡片数据时发生错误：" & ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadCardsFromFile()
        Try
            ' 如果文件存在，读取文件内容
            If File.Exists(FilePath) Then
                Dim json As String = File.ReadAllText(FilePath)

                ' 将 JSON 字符串反序列化为卡片列表
                CardList = JsonConvert.DeserializeObject(Of List(Of Card))(json)

                ' 初始化未复习卡片列表和已复习卡片列表
                UnreviewedCards = CardList.Where(Function(c) c.Status = "本轮未复习").ToList()
                ReviewedCards = CardList.Where(Function(c) c.Status = "本轮已复习").ToList()

                ' 更新 ListBox 显示卡片内容
                ListBox1.Items.Clear()
                For Each card As Card In CardList
                    ListBox1.Items.Add(card)
                Next

                ' 如果有未复习的卡片，显示第一张未复习卡片的正面
                If UnreviewedCards.Count > 0 Then
                    ListBox1.SelectedItem = UnreviewedCards(0) ' 选择未复习的第一张卡片
                    CardContentLabel.Text = CType(ListBox1.SelectedItem, Card).FrontContent ' 显示卡片正面
                Else
                    CardContentLabel.Text = "" ' 如果没有未复习的卡片，则清空卡片内容显示
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("加载卡片数据时发生错误：" & ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    ' 添加卡片按钮点击事件
    Private Sub AddCardButton_Click(sender As Object, e As EventArgs) Handles AddCardButton.Click
        ' 弹出输入框，获取正面和背面内容
        Dim frontContent As String = InputBox("请输入卡片的正面内容：", "添加卡片")
        Dim backContent As String = InputBox("请输入卡片的背面内容：", "添加卡片")

        ' 检查输入内容是否为空
        If String.IsNullOrWhiteSpace(frontContent) OrElse String.IsNullOrWhiteSpace(backContent) Then
            MessageBox.Show("正面和背面内容都不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' 创建新卡片并添加到列表中
        Dim newCard As New Card(frontContent, backContent)
        CardList.Add(newCard)

        ' 将卡片的正面内容显示在ListBox中
        ListBox1.Items.Add(newCard)

        ' 使ComboBox选择为“全部卡片”并更新ListBox显示
        ComboBox1.SelectedIndex = 0 ' 选择“全部卡片”
        ComboBox1_SelectedIndexChanged(sender, e) ' 更新ListBox显示所有卡片

        ' 保存卡片数据到文件
        SaveCardsToFile()
    End Sub


    ' 当选择列表中的卡片时显示其正面内容
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        selectedCard = TryCast(ListBox1.SelectedItem, Card)
        If selectedCard IsNot Nothing Then
            CardContentLabel.Text = selectedCard.FrontContent
        End If
    End Sub

    Private Sub AnswerButton_Click(sender As Object, e As EventArgs) Handles AnswerButton.Click
        ' 如果当前未选中任何卡片，则自动选择未复习列表中的第一张卡片
        'If ListBox1.SelectedItem Is Nothing AndAlso UnreviewedCards.Count > 0 Then
        '    ListBox1.SelectedItem = UnreviewedCards(0) ' 自动选择未复习列表的第一张卡片

        'End If

        '' 获取当前选中的卡片
        'selectedCard = TryCast(ListBox1.SelectedItem, Card)
        If CardContentLabel.Text Like "" Then

            selectedCard = Nothing
        End If

        ' 如果选中了卡片，显示卡片背面内容
        If selectedCard IsNot Nothing Then
            ' 隐藏“作答”按钮
            AnswerButton.Visible = False

            ' 显示“答对”、“答错”、“已熟记”按钮
            CorrectButton.Visible = True
            IncorrectButton.Visible = True
            MemorizedButton.Visible = True

            ' 显示卡片的背面内容
            CardContentLabel.Text = selectedCard.BackContent
        Else
            ' 如果没有选中卡片，提示用户
            MessageBox.Show("已全部复习完成，请开始新一轮复习！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    ' 删除选中卡片按钮点击事件
    Private Sub DeleteCardButton_Click(sender As Object, e As EventArgs) Handles DeleteCardButton.Click
        ' 检查是否选中了一个卡片
        If ListBox1.SelectedItem IsNot Nothing Then
            ' 弹出确认提示框，询问用户是否删除卡片
            Dim result As DialogResult = MessageBox.Show("确定要删除选中的卡片吗？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            ' 如果用户点击了“是”按钮，则删除卡片
            If result = DialogResult.Yes Then
                ' 获取选中的卡片
                selectedCard = TryCast(ListBox1.SelectedItem, Card)

                ' 从CardList中删除选中的卡片
                If selectedCard IsNot Nothing Then
                    CardList.Remove(selectedCard)
                End If

                ' 从ListBox中移除选中的卡片
                ListBox1.Items.Remove(ListBox1.SelectedItem)

                ' 清空卡片内容显示区域
                CardContentLabel.Text = ""

                ' 保存卡片数据到文件
                SaveCardsToFile()
            End If
        Else
            MessageBox.Show("请先选择一个卡片进行删除！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' 窗口关闭时保存卡片数据
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SaveCardsToFile()
    End Sub

    ' 下拉框选择卡片状态时更新 ListBox
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim selectedStatus As String = ComboBox1.SelectedItem.ToString()
        Dim filteredList As List(Of Card)

        Select Case selectedStatus
            Case "已熟记"
                filteredList = CardList.Where(Function(c) c.Status = "已熟记").ToList()
            Case "本轮已复习"
                filteredList = CardList.Where(Function(c) c.Status = "本轮已复习").ToList()
            Case "本轮未复习"
                filteredList = CardList.Where(Function(c) c.Status = "本轮未复习").ToList()
            Case Else
                filteredList = CardList
        End Select

        ' 更新 ListBox 显示
        ListBox1.Items.Clear()
        For Each card As Card In filteredList
            ListBox1.Items.Add(card)
        Next
    End Sub

    ' 新一轮复习按钮点击事件
    Private Sub ReviewButton_Click(sender As Object, e As EventArgs) Handles ReviewButton.Click
        ' 将本轮已复习的卡片状态更新为“本轮未复习”
        For Each card As Card In ReviewedCards
            card.Status = "本轮未复习"
        Next

        ' 清空本轮已复习列表
        ReviewedCards.Clear()

        ' 重新构建未复习卡片列表
        UnreviewedCards = CardList.Where(Function(c) c.Status = "本轮未复习").ToList()

        ' 更新 ListBox 显示所有卡片
        ComboBox1.SelectedIndex = 3 ' 切换到“本轮未复习”选项
        ComboBox1_SelectedIndexChanged(sender, e)

        ' 如果有未复习的卡片，选择并显示第一张未复习卡片的正面内容
        If UnreviewedCards.Count > 0 Then
            ListBox1.SelectedItem = UnreviewedCards(0) ' 选择未复习列表的第一张卡片
            CardContentLabel.Text = UnreviewedCards(0).FrontContent ' 显示卡片正面内容
            selectedCard = ListBox1.SelectedItem
            'CardContentLabel.Text = CType(ListBox1.SelectedItem, Card).FrontContent
        Else
            CardContentLabel.Text = "" ' 如果没有未复习的卡片，则清空显示
        End If
    End Sub


    ' 答对按钮点击事件
    Private Sub CorrectButton_Click(sender As Object, e As EventArgs) Handles CorrectButton.Click
        '' 获取当前选中的卡片
        'selectedCard = TryCast(ListBox1.SelectedItem, Card)

        ' 检查是否选中卡片且卡片状态是否为本轮已复习
        If selectedCard IsNot Nothing Then
            If selectedCard.Status Like "本轮已复习" Then
                ' 直接选择下一张未复习的卡片并显示内容
                If UnreviewedCards.Count > 0 Then
                    'ListBox1.SelectedItem = UnreviewedCards(0)
                    CardContentLabel.Text = UnreviewedCards(0).FrontContent
                    IncorrectTimesLabel.Visible = False
                    CorrectTimesLabel.Visible = False


                    selectedCard = UnreviewedCards(0)
                Else
                    CardContentLabel.Text = ""
                End If

                ' 切换按钮显示
                AnswerButton.Visible = True
                CorrectButton.Visible = False
                IncorrectButton.Visible = False
                MemorizedButton.Visible = False

                ' 提示用户答对了
                MessageBox.Show("恭喜答对！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)


            ElseIf selectedCard.Status Like "已熟记" Then

                If UnreviewedCards.Count > 0 Then
                    'ListBox1.SelectedItem = UnreviewedCards(0)
                    CardContentLabel.Text = UnreviewedCards(0).FrontContent
                    selectedCard = UnreviewedCards(0)
                Else
                    CardContentLabel.Text = ""
                End If

                ' 切换按钮显示
                AnswerButton.Visible = True
                CorrectButton.Visible = False
                IncorrectButton.Visible = False
                MemorizedButton.Visible = False

                ' 提示用户答对了
                MessageBox.Show("恭喜答对！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                ' 如果是未复习的卡片，更新状态为本轮已复习
                selectedCard.Status = "本轮已复习"
                ReviewedCards.Add(selectedCard) ' 添加到已复习列表
                UnreviewedCards.Remove(selectedCard) ' 从未复习列表中移除

                ' 保存卡片数据到文件
                SaveCardsToFile()

                ' 更新 ListBox 显示
                ComboBox1_SelectedIndexChanged(sender, e)

                ' 自动选择下一张未复习的卡片
                If UnreviewedCards.Count > 0 Then
                    'ListBox1.SelectedItem = UnreviewedCards(0)
                    CardContentLabel.Text = UnreviewedCards(0).FrontContent
                    selectedCard = UnreviewedCards(0)
                Else
                    CardContentLabel.Text = ""
                End If

                ' 切换按钮显示
                AnswerButton.Visible = True
                CorrectButton.Visible = False
                IncorrectButton.Visible = False
                MemorizedButton.Visible = False

                ' 提示用户答对了
                MessageBox.Show("恭喜答对！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub


    ' 答错按钮点击事件
    Private Sub IncorrectButton_Click(sender As Object, e As EventArgs) Handles IncorrectButton.Click
        ' 获取当前选中的卡片
        'selectedCard = TryCast(ListBox1.SelectedItem, Card)

        If selectedCard IsNot Nothing Then
            ' 如果当前卡片已在“本轮未复习”列表中，则正常执行操作
            If UnreviewedCards.Contains(selectedCard) Then
                ' 将该卡片移至未复习列表的末尾
                selectedCard.Status = "本轮未复习"
                UnreviewedCards.Remove(selectedCard)
                UnreviewedCards.Add(selectedCard)
            Else
                ' 如果卡片不在未复习列表，则添加该卡片到未复习列表的末尾
                selectedCard.Status = "本轮未复习"
                ReviewedCards.Remove(selectedCard)
                UnreviewedCards.Add(selectedCard)
            End If

            ' 从已复习列表中移除该卡片（如果存在）
            ReviewedCards.Remove(selectedCard)

            ' 保存卡片数据到文件
            SaveCardsToFile()

            ' 更新 ListBox 显示
            ComboBox1_SelectedIndexChanged(sender, e)

            ' 自动选择下一张未复习的卡片
            If UnreviewedCards.Count > 0 Then
                CardContentLabel.Text = UnreviewedCards(0).FrontContent
                selectedCard = UnreviewedCards(0)
            Else
                CardContentLabel.Text = ""
            End If

            ' 恢复“作答”按钮的可见性
            AnswerButton.Visible = True

            CorrectButton.Visible = False
            IncorrectButton.Visible = False
            MemorizedButton.Visible = False

            ' 提示用户答错了
            MessageBox.Show("很遗憾，答错了！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' 已熟记按钮点击事件
    Private Sub MemorizedButton_Click(sender As Object, e As EventArgs) Handles MemorizedButton.Click


        If selectedCard IsNot Nothing Then
            ' 更新卡片状态为已熟记
            selectedCard.Status = "已熟记"

            ' 将卡片添加到已熟记列表
            MemorizedCards.Add(selectedCard)

            ' 从未复习或已复习列表中移除该卡片
            If UnreviewedCards.Contains(selectedCard) Then
                UnreviewedCards.Remove(selectedCard)
            ElseIf ReviewedCards.Contains(selectedCard) Then
                ReviewedCards.Remove(selectedCard)
            End If

            ' 保存卡片数据到文件
            SaveCardsToFile()

            ' 更新 ListBox 显示
            ComboBox1_SelectedIndexChanged(sender, e)

            ' 自动选择下一张未复习的卡片
            If UnreviewedCards.Count > 0 Then
                CardContentLabel.Text = UnreviewedCards(0).FrontContent
                selectedCard = UnreviewedCards(0)
            Else
                CardContentLabel.Text = ""
            End If

            ' 恢复“作答”按钮的可见性
            AnswerButton.Visible = True
            CorrectButton.Visible = False
            IncorrectButton.Visible = False
            MemorizedButton.Visible = False

            ' 提示用户已熟记
            MessageBox.Show("已熟记该卡片！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


End Class
