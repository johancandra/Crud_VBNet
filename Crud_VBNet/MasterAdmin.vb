Public Class MasterAdmin
    Dim db As New DBConnect
    Dim admin As DataTable
    Dim sql As String
    Private Sub Kosong()
        txtKode.Text = ""
        txtUser.Text = ""
        txtPassword.Text = ""
        txtUser.Focus()
    End Sub
    Private Sub TampilData()
        admin = db.ExecuteQuery("SELECT * FROM tbl_admin")
        datagridview.DataSource = admin
        datagridview.ReadOnly = True
    End Sub
    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Try
            sql = ""
            sql = "INSERT INTO tbl_admin(user,password) VALUES('" & txtUser.Text & "','" & txtPassword.Text & "')"
            db.ExecuteNonQuery(sql)
            Call Kosong()
            Call TampilData()
        Catch ex As Exception
            MessageBox.Show("db Penyimpanan Gagal !, Karena " & ex.Message)
        End Try
    End Sub

    Private Sub Masteradmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call TampilData()
    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        Try
            sql = ""
            sql = "UPDATE tbl_admin Set user='" & txtUser.Text & "',password='" & txtPassword.Text & "' WHERE kode='" & txtKode.Text & "'"
            db.ExecuteNonQuery(sql)
            Call Kosong()
            Call TampilData()
        Catch ex As Exception
            MessageBox.Show("Update Gagal !, Karena " & ex.Message)
        End Try
    End Sub

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        If MessageBox.Show("Yakin Data Ini Akan dihapus?", "Konfirmasi...?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            sql = ""
            sql = "DELETE FROM tbl_admin WHERE kode ='" & txtKode.Text & "'"
            db.ExecuteNonQuery(sql)
            Call Kosong()
            Call TampilData()
        Else
            Call Kosong()
        End If
    End Sub
    Private Sub datagridview_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView.CellDoubleClick
        txtKode.Text = datagridview.Item(0, datagridview.CurrentRow.Index).Value
        txtUser.Text = datagridview.Item(1, datagridview.CurrentRow.Index).Value
        txtPassword.Text = datagridview.Item(2, datagridview.CurrentRow.Index).Value
    End Sub
End Class