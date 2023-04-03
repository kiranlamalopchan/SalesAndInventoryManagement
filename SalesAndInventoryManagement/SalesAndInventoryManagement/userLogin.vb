
Imports System.Data
Imports System.Data.OleDb
Public Class userLogin

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Len(Trim(TextBox1.Text)) = 0 Then
            MessageBox.Show("Please enter user name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            Exit Sub


        End If
        If Len(Trim(TextBox2.Text)) = 0 Then
            MessageBox.Show("Please enter Password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Exit Sub
        End If

        If Len(Trim(TextBox2.Text)) = 0 Then
            MessageBox.Show("Please enter Password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Exit Sub
        End If

        Try
            Dim myConnection As OleDbConnection
            myConnection = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "C:\Users\Elohist\source\repos\SalesAndInventoryManagement\SalesAndInventoryManagement\InventoryDB.accdb;")
            Dim myCommand As OleDbCommand
            myCommand = New OleDbCommand("SELECT Username,User_Password FROM Registration WHERE Username=@UserName AND User_Password=@Password", myConnection)
            Dim uName As New OleDbParameter("@UserName", SqlDbType.VarChar)
            Dim uPassword As New OleDbParameter("@Password", SqlDbType.VarChar)
            uName.Value = TextBox1.Text
            uPassword.Value = TextBox2.Text
            myCommand.Parameters.Add(uName)
            myCommand.Parameters.Add(uPassword)
            myCommand.Connection.Open()
            Dim myReader As OleDbDataReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
            Dim Login As Object = 0
            If myReader.HasRows Then
                myReader.Read()
                Login = myReader(Login)
            End If
            If Login = Nothing Then
                MsgBox("Login is failed...Try again!", MsgBoxStyle.Critical, "login Denied")
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox1.Focus()
            Else
                ProgressBar1.Visible = True
                ProgressBar1.Maximum = 5000
                ProgressBar1.Minimum = 0
                ProgressBar1.Value = 4
                ProgressBar1.Step = 1
                For i = 0 To 5000
                    ProgressBar1.PerformStep()
                Next
                FrmMain.ToolStripStatusLabel2.Text = TextBox1.Text
                Me.Hide()
                FrmMain.Show()

            End If
            myCommand.Dispose()
            myConnection.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
End Class