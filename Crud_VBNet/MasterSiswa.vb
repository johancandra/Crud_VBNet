Public Class MasterSiswa
    Dim db As New DBConnect
    Dim siswa As DataTable
    Dim sql As String
    Private Sub Kosong()
        txtKode.Text = ""
        txtNama.Text = ""
        txtKelas.Text = ""
        txtAlamat.Text = ""
        txtNama.Focus()
    End Sub
    Private Sub TampilData()
        siswa = db.ExecuteQuery("SELECT * FROM tbl_siswa")
        datagridview.DataSource = siswa
        datagridview.ReadOnly = True
    End Sub
    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Try
            sql = ""
            sql = "INSERT INTO tbl_siswa(nama,kelas,alamat) VALUES('" & txtNama.Text & "','" & txtKelas.Text & "','" & txtAlamat.Text & "')"
            db.ExecuteNonQuery(sql)
            Call Kosong()
            Call TampilData()
        Catch ex As Exception
            MessageBox.Show("db Penyimpanan Gagal !, Karena " & ex.Message)
        End Try
    End Sub

    Private Sub MasterSiswa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call TampilData()
    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        Try
            sql = ""
            sql = "UPDATE tbl_siswa Set nama='" & txtNama.Text & "',kelas='" & txtKelas.Text & "',alamat='" & txtAlamat.Text & "' WHERE kode='" & txtKode.Text & "'"
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
            sql = "DELETE FROM tbl_siswa WHERE kode ='" & txtKode.Text & "'"
            db.ExecuteNonQuery(sql)
            Call Kosong()
            Call TampilData()
        Else
            Call Kosong()
        End If
    End Sub
    Private Sub datagridview_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles datagridview.CellDoubleClick
        txtKode.Text = datagridview.Item(0, datagridview.CurrentRow.Index).Value
        txtNama.Text = datagridview.Item(1, datagridview.CurrentRow.Index).Value
        txtKelas.Text = datagridview.Item(2, datagridview.CurrentRow.Index).Value
        txtAlamat.Text = datagridview.Item(3, datagridview.CurrentRow.Index).Value
    End Sub
End Class