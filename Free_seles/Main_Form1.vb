Public Class Main_Form1
    Public Sub Close_All()
        Items_Form.Close()
        Customer_Form.Close()
        Sale_Form.Close()


    End Sub

    Private Sub SatislarMiktariToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SatislarMiktariToolStripMenuItem.Click
        'Sales.Show()

    End Sub

    Private Sub UrunlerSatislarToplamiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UrunlerSatislarToplamiToolStripMenuItem.Click

        item_sales.Show()

    End Sub

    Private Sub UrunlerSatislariToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UrunlerSatislariToolStripMenuItem.Click
        Sales.Show()
    End Sub

    Private Sub GOREVLILERGIRILMEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GOREVLILERGIRILMEToolStripMenuItem.Click
        Emp_Form.Show()


    End Sub

    Private Sub TurulerSayfasiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TurulerSayfasiToolStripMenuItem.Click
        Close_All()
        Items_Form.MdiParent = Me
        Items_Form.Show()

    End Sub

    Private Sub MusterilerinSayfasiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MusterilerinSayfasiToolStripMenuItem.Click
        Close_All()
        Customer_Form.MdiParent = Me
        Customer_Form.Show()
    End Sub

    Private Sub SatislarSayfasiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SatislarSayfasiToolStripMenuItem.Click
        Close_All()
        Sale_Form.MdiParent = Me
        Sale_Form.Show()
    End Sub

    Private Sub YONETIMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YONETIMToolStripMenuItem.Click
        Roles_Form.Show()

    End Sub

    Private Sub MUDURToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MUDURToolStripMenuItem.Click
        User_Form.Show()
        User_Form.Show()

    End Sub

    Private Sub TEMELERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TEMELERToolStripMenuItem.Click

    End Sub

    Private Sub KONTROLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KONTROLToolStripMenuItem.Click

    End Sub

    Private Sub Main_Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
