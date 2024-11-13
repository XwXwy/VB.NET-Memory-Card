<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Label1 = New Label()
        ListBox1 = New ListBox()
        Panel1 = New Panel()
        IncorrectTimesLabel = New Label()
        CorrectTimesLabel = New Label()
        CardContentLabel = New Label()
        AddCardButton = New Button()
        DeleteCardButton = New Button()
        AnswerButton = New Button()
        MemorizedButton = New Button()
        CorrectButton = New Button()
        IncorrectButton = New Button()
        CardBindingSource = New BindingSource(components)
        CardBindingSource1 = New BindingSource(components)
        ComboBox1 = New ComboBox()
        ReviewButton = New Button()
        Panel1.SuspendLayout()
        CType(CardBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(CardBindingSource1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft YaHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Label1.Location = New Point(484, 26)
        Label1.Name = "Label1"
        Label1.Size = New Size(272, 46)
        Label1.TabIndex = 0
        Label1.Text = "抽认卡学习助手"
        ' 
        ' ListBox1
        ' 
        ListBox1.FormattingEnabled = True
        ListBox1.ItemHeight = 24
        ListBox1.Location = New Point(31, 75)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(251, 532)
        ListBox1.TabIndex = 2
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.GradientInactiveCaption
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(IncorrectTimesLabel)
        Panel1.Controls.Add(CorrectTimesLabel)
        Panel1.Controls.Add(CardContentLabel)
        Panel1.Location = New Point(484, 145)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(272, 351)
        Panel1.TabIndex = 4
        ' 
        ' IncorrectTimesLabel
        ' 
        IncorrectTimesLabel.AutoSize = True
        IncorrectTimesLabel.Location = New Point(133, -1)
        IncorrectTimesLabel.Name = "IncorrectTimesLabel"
        IncorrectTimesLabel.Size = New Size(138, 24)
        IncorrectTimesLabel.TabIndex = 2
        IncorrectTimesLabel.Text = "IncorrectCount"
        IncorrectTimesLabel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' CorrectTimesLabel
        ' 
        CorrectTimesLabel.AutoSize = True
        CorrectTimesLabel.Location = New Point(-1, -1)
        CorrectTimesLabel.Name = "CorrectTimesLabel"
        CorrectTimesLabel.Size = New Size(125, 24)
        CorrectTimesLabel.TabIndex = 1
        CorrectTimesLabel.Text = "CorrectCount"
        CorrectTimesLabel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' CardContentLabel
        ' 
        CardContentLabel.Font = New Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        CardContentLabel.Location = New Point(18, 90)
        CardContentLabel.Name = "CardContentLabel"
        CardContentLabel.Size = New Size(234, 165)
        CardContentLabel.TabIndex = 0
        CardContentLabel.Text = "Label3"
        CardContentLabel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' AddCardButton
        ' 
        AddCardButton.Location = New Point(31, 622)
        AddCardButton.Name = "AddCardButton"
        AddCardButton.Size = New Size(112, 34)
        AddCardButton.TabIndex = 5
        AddCardButton.Text = "添加卡片"
        AddCardButton.UseVisualStyleBackColor = True
        ' 
        ' DeleteCardButton
        ' 
        DeleteCardButton.Location = New Point(170, 622)
        DeleteCardButton.Name = "DeleteCardButton"
        DeleteCardButton.Size = New Size(112, 34)
        DeleteCardButton.TabIndex = 6
        DeleteCardButton.Text = "删除卡片"
        DeleteCardButton.UseVisualStyleBackColor = True
        ' 
        ' AnswerButton
        ' 
        AnswerButton.Location = New Point(558, 534)
        AnswerButton.Name = "AnswerButton"
        AnswerButton.Size = New Size(112, 34)
        AnswerButton.TabIndex = 7
        AnswerButton.Text = "作答"
        AnswerButton.UseVisualStyleBackColor = True
        ' 
        ' MemorizedButton
        ' 
        MemorizedButton.Location = New Point(699, 600)
        MemorizedButton.Name = "MemorizedButton"
        MemorizedButton.Size = New Size(112, 34)
        MemorizedButton.TabIndex = 8
        MemorizedButton.Text = "已熟记"
        MemorizedButton.UseVisualStyleBackColor = True
        MemorizedButton.Visible = False
        ' 
        ' CorrectButton
        ' 
        CorrectButton.Location = New Point(417, 600)
        CorrectButton.Name = "CorrectButton"
        CorrectButton.Size = New Size(112, 34)
        CorrectButton.TabIndex = 8
        CorrectButton.Text = "答对"
        CorrectButton.UseVisualStyleBackColor = True
        CorrectButton.Visible = False
        ' 
        ' IncorrectButton
        ' 
        IncorrectButton.Location = New Point(558, 600)
        IncorrectButton.Name = "IncorrectButton"
        IncorrectButton.Size = New Size(112, 34)
        IncorrectButton.TabIndex = 9
        IncorrectButton.Text = "答错"
        IncorrectButton.UseVisualStyleBackColor = True
        IncorrectButton.Visible = False
        ' 
        ' CardBindingSource
        ' 
        CardBindingSource.DataSource = GetType(Card)
        ' 
        ' CardBindingSource1
        ' 
        CardBindingSource1.DataSource = GetType(Card)
        ' 
        ' ComboBox1
        ' 
        ComboBox1.DisplayMember = "Status"
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"全部卡片", "已熟记", "本轮已复习", "本轮未复习"})
        ComboBox1.Location = New Point(31, 12)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(182, 32)
        ComboBox1.TabIndex = 10
        ComboBox1.ValueMember = "Status"
        ' 
        ' ReviewButton
        ' 
        ReviewButton.Location = New Point(31, 662)
        ReviewButton.Name = "ReviewButton"
        ReviewButton.Size = New Size(251, 34)
        ReviewButton.TabIndex = 11
        ReviewButton.Text = "新一轮复习"
        ReviewButton.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(11F, 24F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(967, 721)
        Controls.Add(ReviewButton)
        Controls.Add(ComboBox1)
        Controls.Add(IncorrectButton)
        Controls.Add(CorrectButton)
        Controls.Add(MemorizedButton)
        Controls.Add(AnswerButton)
        Controls.Add(DeleteCardButton)
        Controls.Add(AddCardButton)
        Controls.Add(Panel1)
        Controls.Add(ListBox1)
        Controls.Add(Label1)
        Name = "Form1"
        Text = "Form1"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(CardBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(CardBindingSource1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents CardContentLabel As Label
    Friend WithEvents AddCardButton As Button
    Friend WithEvents DeleteCardButton As Button
    Friend WithEvents AnswerButton As Button
    Friend WithEvents MemorizedButton As Button
    Friend WithEvents CorrectButton As Button
    Friend WithEvents IncorrectButton As Button
    Friend WithEvents CardBindingSource As BindingSource
    Friend WithEvents CardBindingSource1 As BindingSource
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ReviewButton As Button
    Friend WithEvents CorrectTimesLabel As Label
    Friend WithEvents IncorrectTimesLabel As Label

End Class
