Imports System.Data.OleDb



Public Class frmStockDetails1
    Dim rdr As OleDbDataReader = Nothing
    Dim dtable As DataTable
    Dim con As OleDbConnection = Nothing
    Dim adp As OleDbDataAdapter
    Dim ds As DataSet
    Dim cmd As OleDbCommand = Nothing
    Dim dt As New DataTable
    Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "C:\Users\Elohist\source\repos\SalesAndInventoryManagement\SalesAndInventoryManagement\InventoryDB.accdb;"

    Private Sub frmStockDetails1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillCategory()
        fillProduct()
        fillWeight()
    End Sub
    Sub fillProduct()

        Try

            Dim CN As New OleDbConnection(cs)

            CN.Open()
            adp = New OleDbDataAdapter()
            adp.SelectCommand = New OleDbCommand("SELECT distinct  (ProductName) FROM stock", CN)
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
    Sub fillWeight()

        Try

            Dim CN As New OleDbConnection(cs)

            CN.Open()
            adp = New OleDbDataAdapter()
            adp.SelectCommand = New OleDbCommand("SELECT distinct  (Weight) FROM stock", CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbWeight.Items.Clear()

            For Each drow As DataRow In dtable.Rows
                cmbWeight.Items.Add(drow(0).ToString())
                'DocName.SelectedIndex = -1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillCategory()

        Try

            Dim CN As New OleDbConnection(cs)

            CN.Open()
            adp = New OleDbDataAdapter()
            adp.SelectCommand = New OleDbCommand("SELECT distinct  (Category) FROM stock", CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbCategory.Items.Clear()

            For Each drow As DataRow In dtable.Rows
                cmbCategory.Items.Add(drow(0).ToString())
                'DocName.SelectedIndex = -1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        cmbProductName.Text = ""
        txtProduct.Text = ""
        DataGridView2.DataSource = Nothing
    End Sub

    Private Sub TabControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.Click
        cmbProductName.Text = ""
        txtProduct.Text = ""
        DataGridView2.DataSource = Nothing
        cmbCategory.Text = ""
        DataGridView3.DataSource = Nothing
        cmbWeight.Text = ""
        DataGridView4.DataSource = Nothing
    End Sub

    Private Sub cmbProductName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProductName.SelectedIndexChanged
        Try


            con = New OleDbConnection(cs)

            con.Open()
            cmd = New OleDbCommand("SELECT (StockID)as [Stock ID],(StockDate)as [Entry Date],(ProductCode) as [Product Code],(ProductName) as [Product Name],(Category) as [Category],(Weight) as [Weight/Qty],(Cartons) as [Cartons],(Packets) as [Packets],(TotalPackets) as [Total Packets] from Stock where Productname = '" & cmbProductName.Text & "'order by ProductName", con)

            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "Stock")

            DataGridView2.DataSource = myDataSet.Tables("Stock").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtProduct_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProduct.TextChanged
        Try


            con = New OleDbConnection(cs)

            con.Open()
            cmd = New OleDbCommand("SELECT (StockID)as [Stock ID],(StockDate)as [Entry Date],(ProductCode) as [Product Code],(ProductName) as [Product Name],(Category) as [Category],(Weight) as [Weight/Qty],(Cartons) as [Cartons],(Packets) as [Packets],(TotalPackets) as [Total Packets] from Stock where Productname like '" & txtProduct.Text & "%' order by ProductName", con)


            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "Stock")

            DataGridView2.DataSource = myDataSet.Tables("Stock").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView2_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView2.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView2.SelectedRows(0)
            Me.Hide()
            frmStock.Show()
            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();
            frmStock.txtStockID.Text = dr.Cells(0).Value.ToString()
            frmStock.dtpStockDate.Text = dr.Cells(1).Value.ToString()
            frmStock.txtProductCode.Text = dr.Cells(2).Value.ToString()
            frmStock.txtProductName.Text = dr.Cells(3).Value.ToString()
            frmStock.txtCategory.Text = dr.Cells(4).Value.ToString()
            frmStock.txtWeight.Text = dr.Cells(5).Value.ToString()
            frmStock.txtCartons.Text = dr.Cells(6).Value.ToString()
            frmStock.txtPackets.Text = dr.Cells(7).Value.ToString()
            frmStock.txtTotalPackets.Text = dr.Cells(8).Value.ToString()
            frmStock.Update_Record.Enabled = True
            frmStock.Delete.Enabled = True
            frmStock.Save.Enabled = False
            frmStock.txtCartons.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCategory.SelectedIndexChanged
        Try


            con = New OleDbConnection(cs)

            con.Open()
            cmd = New OleDbCommand("SELECT (StockID)as [Stock ID],(StockDate)as [Entry Date],(ProductCode) as [Product Code],(ProductName) as [Product Name],(Category) as [Category],(Weight) as [Weight/Qty],(Cartons) as [Cartons],(Packets) as [Packets],(TotalPackets) as [Total Packets] from Stock where category = '" & cmbCategory.Text & "'order by Category", con)

            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "Stock")

            DataGridView3.DataSource = myDataSet.Tables("Stock").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        cmbCategory.Text = ""
        DataGridView3.DataSource = Nothing
    End Sub

    Private Sub DataGridView3_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView3.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView3.SelectedRows(0)
            Me.Hide()
            frmStock.Show()
            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();
            frmStock.txtStockID.Text = dr.Cells(0).Value.ToString()
            frmStock.dtpStockDate.Text = dr.Cells(1).Value.ToString()
            frmStock.txtProductCode.Text = dr.Cells(2).Value.ToString()
            frmStock.txtProductName.Text = dr.Cells(3).Value.ToString()
            frmStock.txtCategory.Text = dr.Cells(4).Value.ToString()
            frmStock.txtWeight.Text = dr.Cells(5).Value.ToString()
            frmStock.txtCartons.Text = dr.Cells(6).Value.ToString()
            frmStock.txtPackets.Text = dr.Cells(7).Value.ToString()
            frmStock.txtTotalPackets.Text = dr.Cells(8).Value.ToString()
            frmStock.Update_Record.Enabled = True
            frmStock.Delete.Enabled = True
            frmStock.Save.Enabled = False
            frmStock.txtCartons.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbWeight_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbWeight.SelectedIndexChanged
        Try


            con = New OleDbConnection(cs)

            con.Open()
            cmd = New OleDbCommand("SELECT (StockID)as [Stock ID],(StockDate)as [Entry Date],(ProductCode) as [Product Code],(ProductName) as [Product Name],(Category) as [Category],(Weight) as [Weight/Qty],(Cartons) as [Cartons],(Packets) as [Packets],(TotalPackets) as [Total Packets] from Stock where Weight = '" & cmbWeight.Text & "'order by weight", con)

            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "Stock")

            DataGridView4.DataSource = myDataSet.Tables("Stock").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        cmbWeight.Text = ""
        DataGridView4.DataSource = Nothing
    End Sub

    Private Sub DataGridView4_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView4.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView4.SelectedRows(0)
            Me.Hide()
            frmStock.Show()
            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();
            frmStock.txtStockID.Text = dr.Cells(0).Value.ToString()
            frmStock.dtpStockDate.Text = dr.Cells(1).Value.ToString()
            frmStock.txtProductCode.Text = dr.Cells(2).Value.ToString()
            frmStock.txtProductName.Text = dr.Cells(3).Value.ToString()
            frmStock.txtCategory.Text = dr.Cells(4).Value.ToString()
            frmStock.txtWeight.Text = dr.Cells(5).Value.ToString()
            frmStock.txtCartons.Text = dr.Cells(6).Value.ToString()
            frmStock.txtPackets.Text = dr.Cells(7).Value.ToString()
            frmStock.txtTotalPackets.Text = dr.Cells(8).Value.ToString()
            frmStock.Update_Record.Enabled = True
            frmStock.Delete.Enabled = True
            frmStock.Save.Enabled = False
            frmStock.txtCartons.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try


            con = New OleDbConnection(cs)

            con.Open()
            cmd = New OleDbCommand("SELECT (StockID)as [Stock ID],(StockDate)as [Entry Date],(ProductCode) as [Product Code],(ProductName) as [Product Name],(Category) as [Category],(Weight) as [Weight/Qty],(Cartons) as [Cartons],(Packets) as [Packets],(TotalPackets) as [Total Packets] from Stock where Cartons = 0 and TotalPackets=0 order by ProductName", con)


            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "Stock")

            DataGridView1.DataSource = myDataSet.Tables("Stock").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DataGridView1.DataSource = Nothing
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            Me.Hide()
            frmStock.Show()
            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();
            frmStock.txtStockID.Text = dr.Cells(0).Value.ToString()
            frmStock.dtpStockDate.Text = dr.Cells(1).Value.ToString()
            frmStock.txtProductCode.Text = dr.Cells(2).Value.ToString()
            frmStock.txtProductName.Text = dr.Cells(3).Value.ToString()
            frmStock.txtCategory.Text = dr.Cells(4).Value.ToString()
            frmStock.txtWeight.Text = dr.Cells(5).Value.ToString()
            frmStock.txtCartons.Text = dr.Cells(6).Value.ToString()
            frmStock.txtPackets.Text = dr.Cells(7).Value.ToString()
            frmStock.txtTotalPackets.Text = dr.Cells(8).Value.ToString()
            frmStock.Update_Record.Enabled = True
            frmStock.Delete.Enabled = True
            frmStock.Save.Enabled = False
            frmStock.txtCartons.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



End Class