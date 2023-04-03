Imports System.Data.OleDb
Public Class frmVendorRecords
    Dim rdr As OleDbDataReader = Nothing
    Dim con As OleDbConnection = Nothing
    Dim cmd As OleDbCommand = Nothing
    Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "C:\Users\Elohist\source\repos\SalesAndInventoryManagement\SalesAndInventoryManagement\InventoryDB.accdb;"

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DataGridView1.DataSource = GetData()
    End Sub
    Private ReadOnly Property Connection() As OleDbConnection
        Get
            Dim ConnectionToFetch As New OleDbConnection(cs)
            ConnectionToFetch.Open()
            Return ConnectionToFetch
        End Get
    End Property

    Public Function GetData() As DataView
        Dim SelectQry = "SELECT (vendorID)as [Vendor ID],(name) as [Name],(address) as [Address],(landmark) as [Landmark],(city) as [City],(state) as [State],(zipcode) as [Zip/Post Code],(Phone) as [Phone],(email) as [Email],(mobileno) as [Mobile No],(faxno) as [Fax No],(notes) as [Notes] from vendor order by vendorid"


        Dim SampleSource As New DataSet
        Dim TableView As DataView
        Try
            Dim SampleCommand As New OleDbCommand()
            Dim SampleDataAdapter = New OleDbDataAdapter()
            SampleCommand.CommandText = SelectQry
            SampleCommand.Connection = Connection
            SampleDataAdapter.SelectCommand = SampleCommand
            SampleDataAdapter.Fill(SampleSource)
            TableView = SampleSource.Tables(0).DefaultView
        Catch ex As Exception
            Throw ex
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return TableView
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DataGridView1.DataSource = Nothing
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            Me.Hide()
            frmVendor.Show()

            frmVendor.txtVendorID.Text = dr.Cells(0).Value.ToString()
            frmVendor.txtName.Text = dr.Cells(1).Value.ToString()

            frmVendor.txtAddress.Text = dr.Cells(2).Value.ToString()
            frmVendor.txtCity.Text = dr.Cells(4).Value.ToString()
            frmVendor.txtLandmark.Text = dr.Cells(3).Value.ToString()
            frmVendor.cmbState.Text = dr.Cells(5).Value.ToString()
            frmVendor.txtZipCode.Text = dr.Cells(6).Value.ToString()
            frmVendor.txtPhone.Text = dr.Cells(7).Value.ToString()
            frmVendor.txtEmail.Text = dr.Cells(8).Value.ToString()
            frmVendor.txtMobileNo.Text = dr.Cells(9).Value.ToString()
            frmVendor.txtFaxNo.Text = dr.Cells(10).Value.ToString()
            frmVendor.txtNotes.Text = dr.Cells(11).Value.ToString()
            frmVendor.Update_Record.Enabled = True
            frmVendor.Delete.Enabled = True
            frmVendor.Save.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class