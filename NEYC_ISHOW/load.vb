Public Class loadvb

    Private Sub TextBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Click
        If ComboBox1.SelectedIndex = 0 Then
            OpenFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory()
            OpenFileDialog1.ShowDialog()
        ElseIf ComboBox1.SelectedIndex = 1 Then
            OpenFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory()
            OpenFileDialog1.ShowDialog()
        ElseIf ComboBox1.SelectedIndex = 2 Then
            SaveFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory()
            SaveFileDialog1.ShowDialog()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Shell = ComboBox1.SelectedIndex()
        File = TextBox1.Text
        If Shell = 0 Then
            diy.Show()
            Me.Close()
        ElseIf Shell = 1 Then
            ShowVB.Show()
        ElseIf Shell = 2 Then
            ini.WriteINI("main", "c_jm_count", "0", File)
            diy.Show()
            Me.Close()
        Else
            MessageBox.Show("Error", "iShow 1.0", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        TextBox1.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub SaveFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        TextBox1.Text = SaveFileDialog1.FileName
    End Sub
End Class