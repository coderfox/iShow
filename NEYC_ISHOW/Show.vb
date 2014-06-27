Public Class ShowVB
    Dim ini As New ini
    Dim CurrectID As Integer
    Dim link1 As String
    Dim link2 As String
    Public Function REPL(ByVal text As String)
        Return text.Replace("\n", vbCr)
    End Function
    Private Sub Fresh(ByVal Id As Integer)
        CurrectID = Id
        Label1.Text = Id
        Label3.Text = NEYC_ISHOW.ini.GetINI(Id, "name", "E#2", File)
        Label2.Text = "请观看  " & NEYC_ISHOW.ini.GetINI(Id, "style", "E#2", File)
        Label4.Text = REPL(NEYC_ISHOW.ini.GetINI(Id, "info", "E#2", File))
        Label5.Text = NEYC_ISHOW.ini.GetINI("main", "name", "E#2", File)
        link1 = NEYC_ISHOW.ini.GetINI(Id, "link1", "", File)
        link1 = NEYC_ISHOW.ini.GetINI(Id, "link2", "", File)
        Try
            If NEYC_ISHOW.ini.GetINI(Id, "picture", ".\background.bmp", File) <> "" Then
                Me.BackgroundImage = System.Drawing.Bitmap.FromFile(NEYC_ISHOW.ini.GetINI(Id, "picture", ".\background.bmp", File))
            Else
                Me.BackgroundImage = System.Drawing.Bitmap.FromFile(".\background.bmp")
            End If
        Catch ex As Exception
            Label6.Text = ex.Message
        End Try
        Try
            PictureBox1.Image = System.Drawing.Bitmap.FromFile(NEYC_ISHOW.ini.GetINI("main", "logo", ".\logo.bmp", File))
        Catch ex As Exception
            Label7.Text = ex.Message
        End Try
        AxWindowsMediaPlayer1.URL = NEYC_ISHOW.ini.GetINI(Id, "music", "", File)
        AxWindowsMediaPlayer2.URL = NEYC_ISHOW.ini.GetINI(Id, "video", "", File)
    End Sub
    Private Sub FreshButton()
        Dim c_jm_count As Integer
        c_jm_count = NEYC_ISHOW.ini.GetINI("main", "c_jm_count", "1", File)
        If CurrectID = c_jm_count Then
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = False
            Button4.Enabled = False
            Dim TextID As Integer
            Try
                TextID = CInt(TextBox1.Text)
            Catch
                TextID = 1
            End Try
            If TextID < c_jm_count Then
                Button5.Enabled = True
            Else
                Button5.Enabled = False
            End If
            If link1 = "" Then
                Button11.Enabled = False
            Else
                Button11.Enabled = True
            End If
            If link2 = "" Then
                Button12.Enabled = False
            Else
                Button12.Enabled = True
            End If
        ElseIf CurrectID < c_jm_count Then
            If CurrectID = 1 Then
                Button1.Enabled = False
                Button2.Enabled = False
                Button3.Enabled = True
                Button4.Enabled = True
                Dim TextID As Integer
                Try
                    TextID = CInt(TextBox1.Text)
                Catch
                    TextID = 1
                End Try
                If TextID < c_jm_count Then
                    Button5.Enabled = True
                Else
                    Button5.Enabled = False
                End If
            Else
                Button1.Enabled = True
                Button2.Enabled = True
                Button3.Enabled = True
                Button4.Enabled = True
                Dim TextID As Integer
                Try
                    TextID = CInt(TextBox1.Text)
                Catch
                    TextID = 1
                End Try

                If TextID < c_jm_count Then
                    Button5.Enabled = True
                Else
                    Button5.Enabled = False
                End If
            End If
            If link1 = "" Then
                Button11.Enabled = False
            Else
                Button11.Enabled = True
            End If
            If link2 = "" Then
                Button12.Enabled = False
            Else
                Button12.Enabled = True
            End If
        End If
    End Sub
    Private Sub Show_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Fresh(1)
        FreshButton()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Fresh(Label1.Text + 1)
        FreshButton()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Fresh(Label1.Text - 1)
        FreshButton()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Fresh(1)
        FreshButton()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Fresh(NEYC_ISHOW.ini.GetINI("main", "c_jm_count", 1, File))
        FreshButton()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Fresh(TextBox1.Text)
        FreshButton()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        AxWindowsMediaPlayer1.Visible = True
        FreshButton()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        AxWindowsMediaPlayer1.Visible = False
        FreshButton()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        AxWindowsMediaPlayer2.Visible = True
        FreshButton()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        AxWindowsMediaPlayer2.Visible = False
        FreshButton()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        loadvb.Show()
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        FreshButton()
    End Sub

    Private Sub Button10_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button10.MouseHover
        GroupBox1.Visible = True
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Process.Start(link1)
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Process.Start(link2)
    End Sub

    Private Sub GroupBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox1.MouseUp
        GroupBox1.Visible = False
    End Sub
End Class