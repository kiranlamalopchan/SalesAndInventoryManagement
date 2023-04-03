
Imports System.Data.OleDb
Public Class frmOrderRecord1
    Dim rdr As OleDbDataReader = Nothing
    Dim dtable As DataTable
    Dim con As OleDbConnection = Nothing
    Dim adp As OleDbDataAdapter
    Dim ds As DataSet
    Dim cmd As OleDbCommand = Nothing
    Dim dt As New DataTable

    Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "C:\Users\Elohist\source\repos\SalesAndInventoryManagement\SalesAndInventoryManagement\InventoryDB.accdb;"


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            con = New OleDbConnection(cs)

            con.Open()
            cmd = New OleDbCommand("SELECT (OrderInfo.OrderNo)as [Order No],(OrderDate)as [Order Date],(OrderStatus) as [Order Status],(CustomerNo) as [Distributor ID],(CustomerName) as [Distributor Name],(ProductCode) as [Product Code],(ProductName) as [Product Name],(Weight) as [Weight],(Price) as [Price],(Cartons) as [Cartons],(TotalPackets) as [Total Packets],(OrderedProduct.TotalAmount) as [Total Amount] from orderinfo,orderedproduct where orderinfo.orderno=orderedproduct.orderno and OrderDate between #" & dtpOrderDateFrom.Value & "# And #" & dtpOrderDateTo.Value & "# order by orderinfo.OrderNo,OrderDate", con)



            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "OrderInfo")
            myDA.Fill(myDataSet, "OrderedProduct")
            DataGridView1.DataSource = myDataSet.Tables("OrderInfo").DefaultView
            DataGridView1.DataSource = myDataSet.Tables("OrderedProduct").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DataGridView1.DataSource = Nothing
        dtpOrderDateFrom.Text = Today
        dtpOrderDateTo.Text = Today
    End Sub

    



    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        DataGridView2.DataSource = Nothing
        cmbOrderNo.Text = ""
    End Sub

   

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Try

            con = New OleDbConnection(cs)

            con.Open()
            cmd = New OleDbCommand("SELECT (OrderInfo.OrderNo)as [Order No],(OrderDate)as [Order Date],(OrderStatus) as [Order Status],(CustomerNo) as [Distributor ID],(CustomerName) as [Distributor Name],(ProductCode) as [Product Code],(ProductName) as [Product Name],(Weight) as [Weight],(Price) as [Price],(Cartons) as [Cartons],(TotalPackets) as [Total Packets],(OrderedProduct.TotalAmount) as [Total Amount] from orderinfo,orderedproduct where orderinfo.orderno=orderedproduct.orderno and orderstatus = '" & cmbStatus.Text & "' order by orderinfo.OrderNo,OrderDate", con)

            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "OrderInfo")
            myDA.Fill(myDataSet, "OrderedProduct")
            DataGridView3.DataSource = myDataSet.Tables("OrderInfo").DefaultView
            DataGridView3.DataSource = myDataSet.Tables("OrderedProduct").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        DataGridView3.DataSource = Nothing
        cmbStatus.Text = ""
    End Sub

   

  

   

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        txtCustomer.Text = ""
        DataGridView6.DataSource = Nothing
        cmbCustomerName.Text = ""
    End Sub




    Sub fillProductName()

        Try

            Dim CN As New OleDbConnection(cs)

            CN.Open()
            adp = New OleDbDataAdapter()
            adp.SelectCommand = New OleDbCommand("SELECT distinct  (ProductName) FROM orderedProduct", CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbProductName.Items.Clear()

            For Each drow As DataRow In dtable.Rows
                cmbProductName.Items.Add(drow(0).ToString())
                'DocName.SelectedIndex = -1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillCustomerName()

        Try

            Dim CN As New OleDbConnection(cs)

            CN.Open()
            adp = New OleDbDataAdapter()
            adp.SelectCommand = New OleDbCommand("SELECT distinct  (CustomerName) FROM orderinfo", CN)
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
    Sub fillorderNo()

        Try

            Dim CN As New OleDbConnection(cs)

            CN.Open()
            adp = New OleDbDataAdapter()
            adp.SelectCommand = New OleDbCommand("SELECT distinct  (orderno) FROM orderinfo", CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbOrderNo.Items.Clear()

            For Each drow As DataRow In dtable.Rows
                cmbOrderNo.Items.Add(drow(0).ToString())
                'DocName.SelectedIndex = -1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub frmOrderRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillCustomerName()
        fillorderNo()
        fillProductName()
    End Sub

    Private Sub TabControl1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.Click
        DataGridView1.DataSource = Nothing
        dtpOrderDateFrom.Text = Today
        dtpOrderDateTo.Text = Today
        DataGridView6.DataSource = Nothing
        cmbCustomerName.Text = ""
        txtCustomer.Text = ""
        DataGridView3.DataSource = Nothing
        cmbStatus.Text = ""
        DataGridView2.DataSource = Nothing
        cmbOrderNo.Text = ""
        cmbProductName.Text = ""
        txtProduct.Text = ""
        DataGridView5.DataSource = Nothing
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        cmbProductName.Text = ""
        txtProduct.Text = ""
        DataGridView5.DataSource = Nothing
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            Me.Hide()
            frmOrder.Show()
            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();
            frmOrder.txtOrderNo.Text = dr.Cells(0).Value.ToString()
            frmOrder.dtpOrderDate.Text = dr.Cells(1).Value.ToString()
            frmOrder.cmbOrderStatus.Text = dr.Cells(2).Value.ToString()
            frmOrder.txtCustomerNo.Text = dr.Cells(3).Value.ToString()
            frmOrder.txtCustomerName.Text = dr.Cells(4).Value.ToString()
            frmOrder.Delete.Enabled = True
            frmOrder.btnUpdate.Enabled = True
            frmOrder.Save.Enabled = False
            frmOrder.cmbOrderStatus.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView2_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView2.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView2.SelectedRows(0)
            Me.Hide()
            frmOrder.Show()
            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();
            frmOrder.txtOrderNo.Text = dr.Cells(0).Value.ToString()
            frmOrder.dtpOrderDate.Text = dr.Cells(1).Value.ToString()
            frmOrder.cmbOrderStatus.Text = dr.Cells(2).Value.ToString()
            frmOrder.txtCustomerNo.Text = dr.Cells(3).Value.ToString()
            frmOrder.txtCustomerName.Text = dr.Cells(4).Value.ToString()
            frmOrder.Delete.Enabled = True
            frmOrder.btnUpdate.Enabled = True
            frmOrder.Save.Enabled = False
            frmOrder.cmbOrderStatus.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView3_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView3.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView3.SelectedRows(0)
            Me.Hide()
            frmOrder.Show()
            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();
            frmOrder.txtOrderNo.Text = dr.Cells(0).Value.ToString()
            frmOrder.dtpOrderDate.Text = dr.Cells(1).Value.ToString()
            frmOrder.cmbOrderStatus.Text = dr.Cells(2).Value.ToString()
            frmOrder.txtCustomerNo.Text = dr.Cells(3).Value.ToString()
            frmOrder.txtCustomerName.Text = dr.Cells(4).Value.ToString()
            frmOrder.Delete.Enabled = True
            frmOrder.btnUpdate.Enabled = True
            frmOrder.Save.Enabled = False
            frmOrder.cmbOrderStatus.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView5_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView5.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView5.SelectedRows(0)
            Me.Hide()
            frmOrder.Show()
            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();
            frmOrder.txtOrderNo.Text = dr.Cells(0).Value.ToString()
            frmOrder.dtpOrderDate.Text = dr.Cells(1).Value.ToString()
            frmOrder.cmbOrderStatus.Text = dr.Cells(2).Value.ToString()
            frmOrder.txtCustomerNo.Text = dr.Cells(3).Value.ToString()
            frmOrder.txtCustomerName.Text = dr.Cells(4).Value.ToString()
            frmOrder.Delete.Enabled = True
            frmOrder.btnUpdate.Enabled = True
            frmOrder.Save.Enabled = False
            frmOrder.cmbOrderStatus.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView6_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView6.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView6.SelectedRows(0)
            Me.Hide()
            frmOrder.Show()
            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();
            frmOrder.txtOrderNo.Text = dr.Cells(0).Value.ToString()
            frmOrder.dtpOrderDate.Text = dr.Cells(1).Value.ToString()
            frmOrder.cmbOrderStatus.Text = dr.Cells(2).Value.ToString()
            frmOrder.txtCustomerNo.Text = dr.Cells(3).Value.ToString()
            frmOrder.txtCustomerName.Text = dr.Cells(4).Value.ToString()
            frmOrder.Delete.Enabled = True
            frmOrder.btnUpdate.Enabled = True
            frmOrder.Save.Enabled = False
            frmOrder.cmbOrderStatus.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub txtCustomer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomer.TextChanged
        Try

            con = New OleDbConnection(cs)

            con.Open()

            con = New OleDbConnection(cs)

            con.Open()
            cmd = New OleDbCommand("SELECT (OrderInfo.OrderNo)as [Order No],(OrderDate)as [Order Date],(OrderStatus) as [Order Status],(CustomerNo) as [Distributor ID],(CustomerName) as [Distributor Name],(ProductCode) as [Product Code],(ProductName) as [Product Name],(Weight) as [Weight],(Price) as [Price],(Cartons) as [Cartons],(TotalPackets) as [Total Packets],(OrderedProduct.TotalAmount) as [Total Amount] from orderinfo,orderedproduct where orderinfo.orderno=orderedproduct.orderno and CustomerName like '" & txtCustomer.Text & "%' order by orderinfo.OrderNo,OrderDate", con)

            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "OrderInfo")
            myDA.Fill(myDataSet, "OrderedProduct")
            DataGridView6.DataSource = myDataSet.Tables("OrderInfo").DefaultView
            DataGridView6.DataSource = myDataSet.Tables("OrderedProduct").DefaultView

            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProduct.TextChanged
        Try

            con = New OleDbConnection(cs)

            con.Open()
            cmd = New OleDbCommand("SELECT (OrderInfo.OrderNo)as [Order No],(OrderDate)as [Order Date],(OrderStatus) as [Order Status],(CustomerNo) as [Distributor ID],(CustomerName) as [Distributor Name],(ProductCode) as [Product Code],(ProductName) as [Product Name],(Weight) as [Weight],(Price) as [Price],(Cartons) as [Cartons],(TotalPackets) as [Total Packets],(OrderedProduct.TotalAmount) as [Total Amount] from orderinfo,orderedproduct where orderinfo.orderno=orderedproduct.orderno and ProductName like '" & txtProduct.Text & "%' order by orderinfo.OrderNo,OrderDate", con)

            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "OrderInfo")
            myDA.Fill(myDataSet, "OrderedProduct")
            DataGridView5.DataSource = myDataSet.Tables("OrderInfo").DefaultView
            DataGridView5.DataSource = myDataSet.Tables("OrderedProduct").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbProductName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProductName.SelectedIndexChanged
        Try

            con = New OleDbConnection(cs)

            con.Open()
            cmd = New OleDbCommand("SELECT (OrderInfo.OrderNo)as [Order No],(OrderDate)as [Order Date],(OrderStatus) as [Order Status],(CustomerNo) as [Distributor ID],(CustomerName) as [Distributor Name],(ProductCode) as [Product Code],(ProductName) as [Product Name],(Weight) as [Weight],(Price) as [Price],(Cartons) as [Cartons],(TotalPackets) as [Total Packets],(OrderedProduct.TotalAmount) as [Total Amount] from orderinfo,orderedproduct where orderinfo.orderno=orderedproduct.orderno and ProductName = '" & cmbProductName.Text & "' order by orderinfo.OrderNo,OrderDate", con)

            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "OrderInfo")
            myDA.Fill(myDataSet, "OrderedProduct")
            DataGridView5.DataSource = myDataSet.Tables("OrderInfo").DefaultView
            DataGridView5.DataSource = myDataSet.Tables("OrderedProduct").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomerName.SelectedIndexChanged
        Try

            con = New OleDbConnection(cs)

            con.Open()
            cmd = New OleDbCommand("SELECT (OrderInfo.OrderNo)as [Order No],(OrderDate)as [Order Date],(OrderStatus) as [Order Status],(CustomerNo) as [Distributor ID],(CustomerName) as [Distributor Name],(ProductCode) as [Product Code],(ProductName) as [Product Name],(Weight) as [Weight],(Price) as [Price],(Cartons) as [Cartons],(TotalPackets) as [Total Packets],(OrderedProduct.TotalAmount) as [Total Amount]  from orderinfo,orderedproduct where orderinfo.orderno=orderedproduct.orderno and CustomerName = '" & cmbCustomerName.Text & "' order by orderinfo.OrderNo,OrderDate", con)

            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "OrderInfo")
            myDA.Fill(myDataSet, "OrderedProduct")
            DataGridView6.DataSource = myDataSet.Tables("OrderInfo").DefaultView
            DataGridView6.DataSource = myDataSet.Tables("OrderedProduct").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbOrderNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOrderNo.SelectedIndexChanged
        Try

            con = New OleDbConnection(cs)

            con.Open()
            cmd = New OleDbCommand("SELECT (OrderInfo.OrderNo)as [Order No],(OrderDate)as [Order Date],(OrderStatus) as [Order Status],(CustomerNo) as [Distributor ID],(CustomerName) as [Distributor Name],(ProductCode) as [Product Code],(ProductName) as [Product Name],(Weight) as [Weight],(Price) as [Price],(Cartons) as [Cartons],(TotalPackets) as [Total Packets],(OrderedProduct.TotalAmount) as [Total Amount] from orderinfo,orderedproduct where orderinfo.orderno=orderedproduct.orderno and orderinfo.Orderno = '" & cmbOrderNo.Text & "' order by orderinfo.OrderNo,OrderDate", con)

            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "OrderInfo")
            myDA.Fill(myDataSet, "OrderedProduct")
            DataGridView2.DataSource = myDataSet.Tables("OrderInfo").DefaultView
            DataGridView2.DataSource = myDataSet.Tables("OrderedProduct").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



End Class