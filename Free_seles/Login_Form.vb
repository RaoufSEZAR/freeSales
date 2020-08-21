Public Class Login_Form
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Load_dt_Loginn(TextBox1.Text, TextBox2.Text)
        If dt_Login.Rows.Count > 0 Then

            user_id = dt_Login.Rows(0).Item(0)
            If dt_Login.Rows(0).Item(1) = True Then
                Main_Form1.TEMELERToolStripMenuItem.Enabled = True
            Else
                Main_Form1.TEMELERToolStripMenuItem.Enabled = False

            End If


            If dt_Login.Rows(0).Item(2) = True Then
                Main_Form1.SatislarMiktariToolStripMenuItem.Enabled = True

            Else
                Main_Form1.SatislarMiktariToolStripMenuItem.Enabled = False
            End If

            If dt_Login.Rows(0).Item(3) = True Then
                Main_Form1.KONTROLToolStripMenuItem.Enabled = True
            Else
                Main_Form1.KONTROLToolStripMenuItem.Enabled = False
            End If

            Main_Form1.Show()
            Close()


        Else
            MsgBox("Bilgileriniz Bir Yanlis Vardir")
        End If







    End Sub

End Class