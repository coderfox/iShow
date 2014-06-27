Public Class diy
    Dim ini As New ini
    Dim from As String
    Sub Fresh()
        Dim c_jm_count As Integer = ini.GetINI("main", "c_jm_count", 0, File)
        ListBox1.Items.Clear()
        ListBox1.Items.Add("主模块")
        For i As Integer = 1 To c_jm_count Step 1
            If ini.GetINI(i, "name", "", File) = "" Then
                MessageBox.Show("错误：没有有效的数据或为空文件", "演出报幕系统")
                ini.WriteINI("1", "name", "节目1", File)
            Else
                ListBox1.Items.Add(ini.GetINI(i, "name", "", File))
            End If
        Next
    End Sub
    Public Function REPL(ByVal text As String)
        Return text.Replace("\n", vbCr)
    End Function
    Private Sub diy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = Label1.Text & File
        Dim c_jm_count As Integer = ini.GetINI("main", "c_jm_count", 0, File)
        If c_jm_count = 0 Then
            MessageBox.Show("错误：没有有效的数据或为空文件", "演出报幕系统")
            ini.WriteINI("main", "c_jm_count", "1", File)
            ini.WriteINI("1", "name", "节目1", File)
            c_jm_count = 1
        End If
        ListBox1.Items.Add("主模块")
        For i As Integer = 1 To c_jm_count Step 1
            If ini.GetINI(i, "name", "", File) = "" Then
                MessageBox.Show("错误：没有有效的数据或为空文件", "演出报幕系统")
                ini.WriteINI("1", "name", "节目1", File)
            Else
                ListBox1.Items.Add(ini.GetINI(i, "name", "", File))
            End If
        Next
        OpenFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex = 0 Then
            Panel2.Show()
            TextBox7.Text = ini.GetINI("main", "name", TextBox7.Text, File)
            TextBox8.Text = ini.GetINI("main", "logo", TextBox8.Text, File)
        Else
            TextBox1.Text = ini.GetINI(ListBox1.SelectedIndex, "name", TextBox1.Text, File)
            TextBox2.Text = ini.GetINI(ListBox1.SelectedIndex, "style", TextBox2.Text, File)
            TextBox3.Text = ini.GetINI(ListBox1.SelectedIndex, "music", TextBox3.Text, File)
            TextBox4.Text = ini.GetINI(ListBox1.SelectedIndex, "video", TextBox4.Text, File)
            TextBox5.Text = ini.GetINI(ListBox1.SelectedIndex, "picture", TextBox5.Text, File)
            TextBox6.Text = ini.GetINI(ListBox1.SelectedIndex, "info", TextBox6.Text, File)
            TextBox9.Text = ini.GetINI(ListBox1.SelectedIndex, "link1", TextBox9.Text, File)
            TextBox10.Text = ini.GetINI(ListBox1.SelectedIndex, "link2", TextBox10.Text, File)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Panel2.Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        ini.WriteINI("main", "name", TextBox7.Text, File)
        ini.WriteINI("main", "logo", TextBox8.Text, File)
    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        ini.WriteINI(ListBox1.SelectedIndex, "name", TextBox1.Text, File)
        ini.WriteINI(ListBox1.SelectedIndex, "style", TextBox2.Text, File)
        ini.WriteINI(ListBox1.SelectedIndex, "music", TextBox3.Text, File)
        ini.WriteINI(ListBox1.SelectedIndex, "video", TextBox4.Text, File)
        ini.WriteINI(ListBox1.SelectedIndex, "picture", TextBox5.Text, File)
        ini.WriteINI(ListBox1.SelectedIndex, "info", TextBox6.Text, File)
        ini.WriteINI(ListBox1.SelectedIndex, "link1", TextBox9.Text, File)
        ini.WriteINI(ListBox1.SelectedIndex, "link2", TextBox10.Text, File)
        Fresh()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ini.WriteINI(ini.GetINI("main", "c_jm_count", 0, File) + 1, "name", "节目", File)
        ini.WriteINI("main", "c_jm_count", ini.GetINI("main", "c_jm_count", 0, File) + 1, File)
        ListBox1.Items.Add(ini.GetINI(ini.GetINI("main", "c_jm_count", 0, File), "name", "节目", File))
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim ireturn = MessageBox.Show("当前版本只支持删去最后一项！", "iShow", MessageBoxButtons.YesNo)
        If ireturn = Windows.Forms.DialogResult.Yes Then
            ListBox1.Items.RemoveAt(ini.GetINI("main", "c_jm_count", 1, File))
            ini.WriteINI("main", "c_jm_count", ini.GetINI("main", "c_jm_count", 1, File) - 1, File)
        Else
            MessageBox.Show("没有执行操作！", "iShow")
        End If
    End Sub

    Private Sub TextBox3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.Click
        from = "music"
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub TextBox4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.Click
        from = "video"
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub TextBox5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox5.Click
        from = "pic"
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub TextBox8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox8.Click
        from = "logo"
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Select from
            Case "music"
                TextBox3.Text = OpenFileDialog1.FileName
            Case "video"
                TextBox4.Text = OpenFileDialog1.FileName
            Case "pic"
                TextBox5.Text = OpenFileDialog1.FileName
            Case "logo"
                TextBox8.Text = OpenFileDialog1.FileName
        End Select
    End Sub

    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged
        TextBox8.Text = TextBox8.Text.Replace(AppDomain.CurrentDomain.BaseDirectory, ".\")
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        TextBox3.Text = TextBox3.Text.Replace(AppDomain.CurrentDomain.BaseDirectory, ".\")
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        TextBox4.Text = TextBox4.Text.Replace(AppDomain.CurrentDomain.BaseDirectory, ".\")
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged
        TextBox5.Text = TextBox5.Text.Replace(AppDomain.CurrentDomain.BaseDirectory, ".\")
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        ShowVB.Show()
        Me.Hide()
    End Sub
End Class