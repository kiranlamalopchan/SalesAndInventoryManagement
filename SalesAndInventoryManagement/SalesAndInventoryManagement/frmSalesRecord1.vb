Imports System.Data.OleDb

Public Class frmSalesRecord1
    Dim rdr As OleDbDataReader = Nothing
    Dim dtable As DataTable
    Dim con As OleDbConnection = Nothing
    Dim adp As OleDbDataAdapter
    Dim ds As DataSet
    Dim cmd As OleDbCommand = Nothing
    Dim dt As New DataTable
    Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "C:\Users\Elohist\source\repos\SalesAndInventoryManagement\SalesAndInventoryManagement\InventoryDB.accdb;"
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DataGridView1.DataSource = Nothing
        dtpInvoiceDateFrom.Text = Today
        dtpInvoiceDateTo.Text = Today
        GroupBox3.Visible = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            GroupBox3.Visible = True
            con = New OleDbConnection(cs)

            con.Open()
            cmd = New OleDbCommand("SELECT (invoiceNo) as [Invoice No],(BillingDate) as [Invoice Date],(CustomerNo) as [Distributor ID],(CustomerName) as [Distributor Name],(GrandTotal) as [Grand Total],(TotalPayment) as [Total Payment],(PaymentDue) as [Payment Due] from billinfo where BillingDate between #" & dtpInvoiceDateFrom.Value & "# And #" & dtpInvoiceDateTo.Value & "# order by BillingDate", con)


            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "BillInfo")

            DataGridView1.DataSource = myDataSet.Tables("Billinfo").DefaultView
            Dim sum As Int64 = 0
            Dim sum1 As Int64 = 0
            Dim sum2 As Int64 = 0


            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                sum = sum + r.Cells(4).Value
                sum1 = sum1 + r.Cells(5).Value
                sum2 = sum2 + r.Cells(6).Value
            Next
            TextBox1.Text = sum
            TextBox2.Text = sum1
            TextBox3.Text = sum2

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub




    Sub fillCustomerName()

        Try

            Dim CN As New OleDbConnection(cs)

            CN.Open()
            adp = New OleDbDataAdapter()
            adp.SelectCommand = New OleDbCommand("SELECT distinct  (CustomerName) FROM Billinfo", CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbCustomerName.Items.Clear()

            For Each drow As DataRow In dtable.Rows
                cmbCustomerName.Items.Add(drow(0).ToString())
                'DocName.SelectedIndex = -1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillInvoiceNo()

        Try

            Dim CN As New OleDbConnection(cs)

            CN.Open()
            adp = New OleDbDataAdapter()
            adp.SelectCommand = New OleDbCommand("SELECT distinct  (invoiceno) FROM Billinfo", CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbInvoiceNo.Items.Clear()

            For Each drow As DataRow In dtable.Rows
                cmbInvoiceNo.Items.Add(drow(0).ToString())
                'DocName.SelectedIndex = -1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub frmSalesRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        fillInvoiceNo()
        fillCustomerName()
    End Sub



   

   

  



    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        DataGridView3.DataSource = Nothing
        cmbCustomerName.Text = ""
        GroupBox4.Visible = False
    End Sub



    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        DataGridView4.DataSource = Nothing
        cmbInvoiceNo.Text = ""
        GroupBox5.Visible = False
    End Sub

    Private Sub TabControl1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.Click
        DataGridView4.DataSource = Nothing
        cmbInvoiceNo.Text = ""
        GroupBox5.Visible = False
        DataGridView3.DataSource = Nothing
        cmbCustomerName.Text = ""
        GroupBox4.Visible = False
        DateTimePicker1.Text = Today
        DateTimePicker2.Text = Today
        DataGridView2.DataSource = Nothing
        GroupBox10.Visible = False
        DataGridView1.DataSource = Nothing
        dtpInvoiceDateFrom.Text = Today
        dtpInvoiceDateTo.Text = Today
        GroupBox3.Visible = False
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            Me.Hide()
            frmSales.Show()
            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();
            frmSales.txtInvoiceNo.Text = dr.Cells(0).Value.ToString()
            frmSales.txtTotal.Text = dr.Cells(4).Value.ToString()
            frmSales.txtTotalPayment.Text = dr.Cells(5).Value.ToString()
            frmSales.txtPaymentDue.Text = dr.Cells(6).Value.ToString()
            frmSales.btnUpdate.Enabled = True
            frmSales.Delete.Enabled = True
            frmSales.btnPrint.Enabled = True
            frmSales.Save.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub DataGridView3_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView3.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView3.SelectedRows(0)
            Me.Hide()
            frmSales.Show()
            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();
            frmSales.txtInvoiceNo.Text = dr.Cells(0).Value.ToString()
            frmSales.txtTotal.Text = dr.Cells(4).Value.ToString()
            frmSales.txtTotalPayment.Text = dr.Cells(5).Value.ToString()
            frmSales.txtPaymentDue.Text = dr.Cells(6).Value.ToString()
            frmSales.btnUpdate.Enabled = True
            frmSales.Delete.Enabled = True
            frmSales.btnPrint.Enabled = True
            frmSales.Save.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView4_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView4.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView4.SelectedRows(0)
            Me.Hide()
            frmSales.Show()
            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();
            frmSales.txtInvoiceNo.Text = dr.Cells(0).Value.ToString()
            frmSales.txtTotal.Text = dr.Cells(4).Value.ToString()
            frmSales.txtTotalPayment.Text = dr.Cells(5).Value.ToString()
            frmSales.txtPaymentDue.Text = dr.Cells(6).Value.ToString()
            frmSales.btnUpdate.Enabled = True
            frmSales.Delete.Enabled = True
            frmSales.btnPrint.Enabled = True
            frmSales.Save.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub cmbCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomerName.SelectedIndexChanged
        Try

            GroupBox4.Visible = True
            con = New OleDbConnection(cs)

            con.Open()
            cmd = New OleDbCommand("SELECT (invoiceNo) as [Invoice No],(BillingDate) as [Invoice Date],(CustomerNo) as [Distributor ID],(CustomerName) as [Distributor Name],(GrandTotal) as [Grand Total],(TotalPayment) as [Total Payment],(PaymentDue) as [Payment Due] from billinfo where customername= '" & cmbCustomerName.Text & "' order by BillingDate", con)


            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "BillInfo")

            DataGridView3.DataSource = myDataSet.Tables("Billinfo").DefaultView
            Dim sum As Int64 = 0
            Dim sum1 As Int64 = 0
            Dim sum2 As Int64 = 0


            For Each r As DataGridViewRow In Me.DataGridView3.Rows
                sum = sum + r.Cells(4).Value
                sum1 = sum1 + r.Cells(5).Value
                sum2 = sum2 + r.Cells(6).Value
            Next
            TextBox6.Text = sum
            TextBox5.Text = sum1
            TextBox4.Text = sum2

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbInvoiceNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbInvoiceNo.SelectedIndexChanged
        Try

            GroupBox5.Visible = True
            con = New OleDbConnection(cs)

            con.Open()
            cmd = New OleDbCommand(" select (invoiceNo) as [Invoice No],(BillingDate) as [Invoice Date],(CustomerNo) as [Distributor ID],(CustomerName) as [Distributor Name],(GrandTotal) as [Grand Total],(TotalPayment) as [Total Payment],(PaymentDue) as [Payment Due] from billinfo where invoiceno = '" & cmbInvoiceNo.Text & "' order by BillingDate", con)


            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "BillInfo")

            DataGridView4.DataSource = myDataSet.Tables("Billinfo").DefaultView
            Dim sum As Int64 = 0
            Dim sum1 As Int64 = 0
            Dim sum2 As Int64 = 0


            For Each r As DataGridViewRow In Me.DataGridView4.Rows
                sum = sum + r.Cells(4).Value
                sum1 = sum1 + r.Cells(5).Value
                sum2 = sum2 + r.Cells(6).Value
            Next
            TextBox9.Text = sum
            TextBox8.Text = sum1
            TextBox7.Text = sum2


            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try

            GroupBox10.Visible = True
            con = New OleDbConnection(cs)

            con.Open()
            cmd = New OleDbCommand("SELECT (invoiceNo) as [Invoice No],(BillingDate) as [Invoice Date],(CustomerNo) as [Distributor ID],(CustomerName) as [Distributor Name],(GrandTotal) as [Grand Total],(TotalPayment) as [Total Payment],(PaymentDue) as [Payment Due] from billinfo where BillingDate between #" & DateTimePicker2.Value & "# And #" & DateTimePicker1.Value & "# and PaymentDue > 0 order by BillingDate", con)

            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "BillInfo")

            DataGridView2.DataSource = myDataSet.Tables("Billinfo").DefaultView
            Dim sum As Int64 = 0
            Dim sum1 As Int64 = 0
            Dim sum2 As Int64 = 0


            For Each r As DataGridViewRow In Me.DataGridView2.Rows
                sum = sum + r.Cells(4).Value
                sum1 = sum1 + r.Cells(5).Value
                sum2 = sum2 + r.Cells(6).Value
            Next
            TextBox12.Text = sum
            TextBox11.Text = sum1
            TextBox10.Text = sum2

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

   

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        DateTimePicker1.Text = Today
        DateTimePicker2.Text = Today
        DataGridView2.DataSource = Nothing
        GroupBox10.Visible = False
    End Sub

    Private Sub DataGridView2_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView2.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView2.SelectedRows(0)
            Me.Hide()
            frmSales.Show()
            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();
            frmSales.txtInvoiceNo.Text = dr.Cells(0).Value.ToString()
            frmSales.txtTotal.Text = dr.Cells(4).Value.ToString()
            frmSales.txtTotalPayment.Text = dr.Cells(5).Value.ToString()
            frmSales.txtPaymentDue.Text = dr.Cells(6).Value.ToString()
            frmSales.btnUpdate.Enabled = True
            frmSales.Delete.Enabled = True
            frmSales.btnPrint.Enabled = True
            frmSales.Save.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    
End Class