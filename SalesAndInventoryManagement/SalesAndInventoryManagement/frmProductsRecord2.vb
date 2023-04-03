Imports System.Data.OleDb
Public Class frmProductsRecord2
    Dim rdr As OleDbDataReader = Nothing
    Dim dtable As DataTable
    Dim con As OleDbConnection = Nothing
    Dim adp As OleDbDataAdapter
    Dim ds As DataSet
    Dim cmd As OleDbCommand = Nothing
    Dim dt As New DataTable
    Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "C:\Users\Elohist\source\repos\SalesAndInventoryManagement\SalesAndInventoryManagement\InventoryDB.accdb;"

    Private Sub frmProductsRecord2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillCategory()
        fillProduct()
        fillWeight()
    End Sub

    Sub fillCategory()

        Try

            Dim CN As New OleDbConnection(cs)

            CN.Open()
            adp = New OleDbDataAdapter()
            adp.SelectCommand = New OleDbCommand("SELECT distinct  (Category) FROM Product", CN)
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


    Sub fillProduct()

        Try

            Dim CN As New OleDbConnection(cs)

            CN.Open()
            adp = New OleDbDataAdapter()
            adp.SelectCommand = New OleDbCommand("SELECT distinct  (ProductName) FROM Product", CN)
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
            adp.SelectCommand = New OleDbCommand("SELECT distinct  (Weight) FROM product", CN)
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try

            con = New OleDbConnection(cs)

            con.Open()
            cmd = New OleDbCommand("SELECT (ProductCode) as [Product Code],(ProductName) as [Product Name],(Category) as [Category],(Weight) as [Weight Per Qty],(Price) as [Price] from Product order by ProductName", con)


            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "Product")

            DataGridView1.DataSource = myDataSet.Tables("Product").DefaultView


            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            Me.Hide()
            frmProduct.Show()
            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();
            frmProduct.txtProductCode.Text = dr.Cells(0).Value.ToString()
            frmProduct.txtProductName.Text = dr.Cells(1).Value.ToString()
            frmProduct.cmbCategory.Text = dr.Cells(2).Value.ToString()
            frmProduct.cmbWeight.Text = dr.Cells(3).Value.ToString()
            frmProduct.txtPrice.Text = dr.Cells(4).Value.ToString()
            frmProduct.Update_Record.Enabled = True
            frmProduct.Delete.Enabled = True
            frmProduct.Save.Enabled = False
            frmProduct.cmbWeight.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        DataGridView1.DataSource = Nothing
    End Sub

    Private Sub cmbProductName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProductName.SelectedIndexChanged
        Try

            con = New OleDbConnection(cs)

            con.Open()
            cmd = New OleDbCommand("SELECT (ProductCode) as [Product Code],(ProductName) as [Product Name],(Category) as [Category],(Weight) as [Weight Per Qty],(Price) as [Price] from Product where ProductName= '" & cmbProductName.Text & "'order by Productname", con)


            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "Product")

            DataGridView2.DataSource = myDataSet.Tables("Product").DefaultView


            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtProduct_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProduct.TextChanged
        Try

            con = New OleDbConnection(cs)

            con.Open()
            cmd = New OleDbCommand("SELECT (ProductCode) as [Product Code],(ProductName) as [Product Name],(Category) as [Category],(Weight)as [Weight Per Qty],(Price) as [Price] from Product where ProductName like '" & txtProduct.Text & "%' order by ProductName", con)


            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "Product")

            DataGridView2.DataSource = myDataSet.Tables("Product").DefaultView


            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        DataGridView2.DataSource = Nothing
        cmbProductName.Text = ""
        txtProduct.Text = ""
    End Sub

    Private Sub DataGridView2_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView2.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView2.SelectedRows(0)
            Me.Hide()
            frmProduct.Show()
            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();
            frmProduct.txtProductCode.Text = dr.Cells(0).Value.ToString()
            frmProduct.txtProductName.Text = dr.Cells(1).Value.ToString()
            frmProduct.cmbCategory.Text = dr.Cells(2).Value.ToString()
            frmProduct.cmbWeight.Text = dr.Cells(3).Value.ToString()
            frmProduct.txtPrice.Text = dr.Cells(4).Value.ToString()
            frmProduct.Update_Record.Enabled = True
            frmProduct.Delete.Enabled = True
            frmProduct.Save.Enabled = False
            frmProduct.cmbWeight.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbWeight_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbWeight.SelectedIndexChanged
        Try

            con = New OleDbConnection(cs)

            con.Open()
            cmd = New OleDbCommand("SELECT (ProductCode) as [Product Code],(ProductName) as [Product Name],(Category) as [Category],(Weight) as [Weight Per Qty],(Price) as [Price] from Product where Weight = '" & cmbWeight.Text & "' order by ProductName", con)


            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "Product")

            DataGridView3.DataSource = myDataSet.Tables("Product").DefaultView


            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        DataGridView2.DataSource = Nothing
        cmbWeight.Text = ""

    End Sub

    Private Sub DataGridView3_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView3.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView3.SelectedRows(0)
            Me.Hide()
            frmProduct.Show()
            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();
            frmProduct.txtProductCode.Text = dr.Cells(0).Value.ToString()
            frmProduct.txtProductName.Text = dr.Cells(1).Value.ToString()
            frmProduct.cmbCategory.Text = dr.Cells(2).Value.ToString()
            frmProduct.cmbWeight.Text = dr.Cells(3).Value.ToString()
            frmProduct.txtPrice.Text = dr.Cells(4).Value.ToString()
            frmProduct.Update_Record.Enabled = True
            frmProduct.Delete.Enabled = True
            frmProduct.Save.Enabled = False
            frmProduct.cmbWeight.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCategory.SelectedIndexChanged
        Try

            con = New OleDbConnection(cs)

            con.Open()
            cmd = New OleDbCommand("SELECT (ProductCode)as [Product Code],(ProductName) as [Product Name],(Category) as [Category],(Weight) as [Weight Per Qty],(Price) as [Price] from Product where Category = '" & cmbCategory.Text & "' order by ProductName", con)


            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "Product")

            DataGridView4.DataSource = myDataSet.Tables("Product").DefaultView


            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView4_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView4.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView4.SelectedRows(0)
            Me.Hide()
            frmProduct.Show()
            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();
            frmProduct.txtProductCode.Text = dr.Cells(0).Value.ToString()
            frmProduct.txtProductName.Text = dr.Cells(1).Value.ToString()
            frmProduct.cmbCategory.Text = dr.Cells(2).Value.ToString()
            frmProduct.cmbWeight.Text = dr.Cells(3).Value.ToString()
            frmProduct.txtPrice.Text = dr.Cells(4).Value.ToString()
            frmProduct.Update_Record.Enabled = True
            frmProduct.Delete.Enabled = True
            frmProduct.Save.Enabled = False
            frmProduct.cmbWeight.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        DataGridView4.DataSource = Nothing
        cmbCategory.Text = ""
    End Sub

    Private Sub TabControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.Click
        DataGridView4.DataSource = Nothing
        cmbCategory.Text = ""
        cmbWeight.Text = ""
        DataGridView3.DataSource = Nothing
        cmbProductName.Text = ""
        txtProduct.Text = ""
        DataGridView2.DataSource = Nothing
        DataGridView1.DataSource = Nothing
    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub
End Class