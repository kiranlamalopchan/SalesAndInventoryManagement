Imports System.Data.OleDb
Public Class frmCustomersRecord3

    Dim rdr As OleDbDataReader = Nothing
    Dim dtable As DataTable
    Dim con As OleDbConnection = Nothing
    Dim adp As OleDbDataAdapter
    Dim ds As DataSet
    Dim cmd As OleDbCommand = Nothing
    Dim dt As New DataTable


    Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "C:\Users\Elohist\source\repos\SalesAndInventoryManagement\SalesAndInventoryManagement\InventoryDB.accdb;"
    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private ReadOnly Property Connection() As OleDbConnection
        Get
            Dim ConnectionToFetch As New OleDbConnection(cs)
            ConnectionToFetch.Open()
            Return ConnectionToFetch
        End Get
    End Property

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DataGridView1.DataSource = GetData()

    End Sub
    Public Function GetData() As DataView

        Dim SelectQry = "SELECT (customerNo) as [Distributor ID],(B_name) as [B_Name],(b_address) as [B_Address],(b_landmark) as [B_LandMark],(b_city) as [B_City],(b_state) as [B_State],(b_zipcode) as [B_Zip/Post Code],(s_name) as [S_Name],(s_address) as [S_Address],(s_landmark) as [S_LandMark],(s_city) as [S_City],(s_state) as [S_State],(s_zipcode) as [S_Zip/Post Code],(Phone) as [Phone],(email)as [Email],(mobileno) as [Mobile No],(faxno) as [Fax No],(notes)as [Notes] from Customer order by CustomerNo"


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

    Private Sub frmCustomersRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillName()

    End Sub

    Sub fillName()

        Try
            Dim CN As New OleDbConnection(cs)

            CN.Open()
            adp = New OleDbDataAdapter()
            adp.SelectCommand = New OleDbCommand("SELECT distinct  (B_Name) FROM Customer", CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            txtName.Items.Clear()

            For Each drow As DataRow In dtable.Rows
                txtName.Items.Add(drow(0).ToString())
                'DocName.SelectedIndex = -1
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DataGridView1.DataSource = Nothing
    End Sub

    Private Sub TabControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.Click
        DataGridView1.DataSource = Nothing
        txtName.Text = ""
        txtCustomer.Text = ""
        DataGridView2.DataSource = Nothing
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            Me.Hide()
            frmDistributor.Show()

            frmDistributor.txtCustomerNo.Text = dr.Cells(0).Value.ToString()
            frmDistributor.B_name.Text = dr.Cells(1).Value.ToString()

            frmDistributor.B_Address.Text = dr.Cells(2).Value.ToString()
            frmDistributor.B_City.Text = dr.Cells(4).Value.ToString()
            frmDistributor.B_Landmark.Text = dr.Cells(3).Value.ToString()
            frmDistributor.B_State.Text = dr.Cells(5).Value.ToString()
            frmDistributor.B_ZipCode.Text = dr.Cells(6).Value.ToString()
            frmDistributor.S_name.Text = dr.Cells(7).Value.ToString()

            frmDistributor.S_Address.Text = dr.Cells(8).Value.ToString()
            frmDistributor.S_City.Text = dr.Cells(10).Value.ToString()
            frmDistributor.S_Landmark.Text = dr.Cells(9).Value.ToString()
            frmDistributor.S_State.Text = dr.Cells(11).Value.ToString()
            frmDistributor.S_ZipCode.Text = dr.Cells(12).Value.ToString()
            frmDistributor.txtPhone.Text = dr.Cells(13).Value.ToString()
            frmDistributor.txtEmail.Text = dr.Cells(14).Value.ToString()
            frmDistributor.txtMobileNo.Text = dr.Cells(15).Value.ToString()
            frmDistributor.txtFaxNo.Text = dr.Cells(16).Value.ToString()
            frmDistributor.txtNotes.Text = dr.Cells(17).Value.ToString()
            frmDistributor.Update_Record.Enabled = True
            frmDistributor.Delete.Enabled = True
            frmDistributor.Save.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        txtName.Text = ""
        txtCustomer.Text = ""
        DataGridView2.DataSource = Nothing
    End Sub

    
    Private Sub DataGridView2_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView2.RowHeaderMouseClick

        Try


            Dim dr As DataGridViewRow = DataGridView2.SelectedRows(0)
            Me.Hide()
            frmDistributor.Show()

            frmDistributor.txtCustomerNo.Text = dr.Cells(0).Value.ToString()
            frmDistributor.B_name.Text = dr.Cells(1).Value.ToString()

            frmDistributor.B_Address.Text = dr.Cells(2).Value.ToString()
            frmDistributor.B_City.Text = dr.Cells(4).Value.ToString()
            frmDistributor.B_Landmark.Text = dr.Cells(3).Value.ToString()
            frmDistributor.B_State.Text = dr.Cells(5).Value.ToString()
            frmDistributor.B_ZipCode.Text = dr.Cells(6).Value.ToString()
            frmDistributor.S_name.Text = dr.Cells(7).Value.ToString()

            frmDistributor.S_Address.Text = dr.Cells(8).Value.ToString()
            frmDistributor.S_City.Text = dr.Cells(10).Value.ToString()
            frmDistributor.S_Landmark.Text = dr.Cells(9).Value.ToString()
            frmDistributor.S_State.Text = dr.Cells(11).Value.ToString()
            frmDistributor.S_ZipCode.Text = dr.Cells(12).Value.ToString()
            frmDistributor.txtPhone.Text = dr.Cells(13).Value.ToString()
            frmDistributor.txtEmail.Text = dr.Cells(14).Value.ToString()
            frmDistributor.txtMobileNo.Text = dr.Cells(15).Value.ToString()
            frmDistributor.txtFaxNo.Text = dr.Cells(16).Value.ToString()
            frmDistributor.txtNotes.Text = dr.Cells(17).Value.ToString()

            frmDistributor.Update_Record.Enabled = True
            frmDistributor.Delete.Enabled = True
            frmDistributor.Save.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        

    End Sub

    Private Sub txtCustomer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomer.TextChanged
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT (customerNo) as [Distributor ID],(B_name) as [B_Name],(b_address) as [B_Address],(b_landmark) as [B_LandMark],(b_city) as [B_City],(b_state) as [B_State],(b_zipcode) as [B_Zip/Post Code],(s_name) as [S_Name],(s_address) as [S_Address],(s_landmark) as [S_LandMark],(s_city) as [S_City],(s_state) as [S_State],(s_zipcode) as [S_Zip/Post Code],(Phone) as [Phone],(email)as [Email],(mobileno) as [Mobile No],(faxno) as [Fax No],(notes)as [Notes] from Customer where B_Name like '" & txtCustomer.Text & "%'  order by CustomerNo", con)




            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "Customer")

            DataGridView2.DataSource = myDataSet.Tables("Customer").DefaultView



            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.SelectedIndexChanged
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT (customerNo) as [Distributor ID],(B_name) as [B_Name],(b_address) as [B_Address],(b_landmark) as [B_LandMark],(b_city) as [B_City],(b_state) as [B_State],(b_zipcode) as [B_Zip/Post Code],(s_name) as [S_Name],(s_address) as [S_Address],(s_landmark) as [S_LandMark],(s_city) as [S_City],(s_state) as [S_State],(s_zipcode) as [S_Zip/Post Code],(Phone) as [Phone],(email)as [Email],(mobileno) as [Mobile No],(faxno) as [Fax No],(notes)as [Notes] from Customer where B_Name = '" & txtName.Text & "' order by CustomerNo", con)




            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "Customer")

            DataGridView2.DataSource = myDataSet.Tables("Customer").DefaultView



            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class