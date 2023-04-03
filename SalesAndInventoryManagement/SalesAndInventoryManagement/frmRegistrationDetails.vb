
Imports System.Data.OleDb
Imports System.Data
Public Class frmRegistrationDetails


    Private Const ConnectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "C:\Users\Elohist\source\repos\SalesAndInventoryManagement\SalesAndInventoryManagement\InventoryDB.accdb;"
    Private Sub frmRegistrationDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = GetData()

    End Sub
    Private ReadOnly Property Connection() As OleDbConnection
        Get
            Dim ConnectionToFetch As New OleDbConnection(ConnectionString)
            ConnectionToFetch.Open()
            Return ConnectionToFetch


        End Get
    End Property
    Public Function GetData() As DataView
        Dim SelectQry = " SELECT (UserName) as [User Name],(User_Password) as[User Password],(Name) as [Full Name],(ContactNo) as[Mobile No] FROM Registration"
        Dim SampleSource As New DataSet
        Dim TableView As DataView
        Try
            Dim SampleDataAdapter = New OleDbDataAdapter()
            Dim SampleCommand = New OleDbCommand()
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
End Class