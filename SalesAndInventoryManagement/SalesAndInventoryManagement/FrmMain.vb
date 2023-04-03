Imports System.Data.OleDb
Imports System.IO

Public Class FrmMain
    Dim sSql As String
    Dim rdr As OleDbDataReader = Nothing
    Dim con As OleDbConnection = Nothing
    Dim cmd As OleDbCommand = Nothing


    Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToolStripStatusLabel4.Text = Now
        ' ToolStripStatusLabel2.Text = Form1.UserName.Text
        Me.Refresh()
        Button1.PerformClick()
        Timer2.Start()
        Timer2.Interval = 1000



    End Sub
    Private Const ConnectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "C:\Users\Elohist\source\repos\SalesAndInventoryManagement\SalesAndInventoryManagement\InventoryDB.accdb;"
    Private ReadOnly Property Connection() As OleDbConnection
        Get
            Dim connectionToFetch As New OleDbConnection(ConnectionString)
            connectionToFetch.Open()
            Return connectionToFetch
        End Get
    End Property

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DataGridView1.DataSource = GetData()
    End Sub
    Public Function GetData() As DataView
        Dim SelectQry = "SELECT(StockID) as [Stock ID],(ProductCode) as [Product Code],(ProductName) as [Product Name],(Weight) as [Weight],sum(Cartons) as [Cartons],Packets,Sum(TotalPackets) as [Total Packets] FROM Stock where Cartons > 0 and TotalPackets > 0   group by StockID, ProductCode,ProductName,Weight,Packets order by ProductName "
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

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Start()
        ToolStripStatusLabel4.Text = Now

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Button1.PerformClick()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        Me.Hide()
        Form1.Show()
        Form1.UserName.Text = ""
        Form1.Password.Text = ""
        Form1.UserName.Focus()
        Form1.ProgressBar1.Visible = False

    End Sub

    Private Sub RegistrationToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrationToolStripMenuItem1.Click
        Me.Hide()
        frmRegistration.Show()

    End Sub

    Private Sub RegistrationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrationToolStripMenuItem.Click
        frmRegistration.Show()
    End Sub

    Private Sub FrmMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim result As Integer = MsgBox("Do you want to Close the Application..?", MsgBoxStyle.YesNo)
        If result = DialogResult.No Then
        ElseIf result = DialogResult.Yes Then
            Timer1.Stop()
            Form1.Show()
            Me.Hide()

        End If
    End Sub

    Private Sub DistributorToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DistributorToolStripMenuItem1.Click
        Me.Hide()
        frmDistributor.Show()

    End Sub

    Private Sub DistributorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DistributorToolStripMenuItem.Click
        Me.Hide()
        frmDistributor.Show()
    End Sub

    Private Sub VendorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VendorToolStripMenuItem.Click
        Me.Hide()
        frmVendor.Show()

    End Sub

    Private Sub ProfileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProfileToolStripMenuItem.Click
        Me.Hide()
        frmVendor.Show()
    End Sub

    Private Sub ProductToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductToolStripMenuItem.Click
        Me.Hide()
        frmProduct.Show()

    End Sub

    Private Sub StockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockToolStripMenuItem.Click
        Me.Hide()
        frmStock.Show()
    End Sub

    Private Sub OrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrderToolStripMenuItem.Click
        Me.Hide()
        frmOrder.Show()
    End Sub

    Private Sub InvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvoiceToolStripMenuItem.Click
        Me.Hide()
        frmSales.Show()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class