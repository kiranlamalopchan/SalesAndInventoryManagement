﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStock
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Delete = New System.Windows.Forms.Button()
        Me.txtCategory = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Update_Record = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtStockID = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Save = New System.Windows.Forms.Button()
        Me.NewRecord = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpStockDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPackets = New System.Windows.Forms.TextBox()
        Me.txtWeight = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtTotalPackets = New System.Windows.Forms.TextBox()
        Me.txtCartons = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtProductName = New System.Windows.Forms.TextBox()
        Me.txtProductCode = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.LightGray
        Me.Label11.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(14, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 22)
        Me.Label11.TabIndex = 57
        Me.Label11.Text = "Stock Entry"
        '
        'Delete
        '
        Me.Delete.Enabled = False
        Me.Delete.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Delete.Location = New System.Drawing.Point(16, 133)
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New System.Drawing.Size(99, 29)
        Me.Delete.TabIndex = 3
        Me.Delete.Text = "&Delete"
        Me.Delete.UseVisualStyleBackColor = True
        '
        'txtCategory
        '
        Me.txtCategory.Location = New System.Drawing.Point(165, 145)
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.ReadOnly = True
        Me.txtCategory.Size = New System.Drawing.Size(331, 24)
        Me.txtCategory.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(32, 145)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 17)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Category"
        '
        'Update_Record
        '
        Me.Update_Record.Enabled = False
        Me.Update_Record.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Update_Record.Location = New System.Drawing.Point(16, 98)
        Me.Update_Record.Name = "Update_Record"
        Me.Update_Record.Size = New System.Drawing.Size(99, 29)
        Me.Update_Record.TabIndex = 2
        Me.Update_Record.Text = "&Update"
        Me.Update_Record.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(374, 34)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(29, 25)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "<"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtStockID
        '
        Me.txtStockID.Location = New System.Drawing.Point(165, 35)
        Me.txtStockID.Name = "txtStockID"
        Me.txtStockID.ReadOnly = True
        Me.txtStockID.Size = New System.Drawing.Size(189, 24)
        Me.txtStockID.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Fuchsia
        Me.GroupBox2.Controls.Add(Me.Delete)
        Me.GroupBox2.Controls.Add(Me.Update_Record)
        Me.GroupBox2.Controls.Add(Me.Save)
        Me.GroupBox2.Controls.Add(Me.NewRecord)
        Me.GroupBox2.Location = New System.Drawing.Point(1157, 48)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(134, 178)
        Me.GroupBox2.TabIndex = 56
        Me.GroupBox2.TabStop = False
        '
        'Save
        '
        Me.Save.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Save.Location = New System.Drawing.Point(16, 63)
        Me.Save.Name = "Save"
        Me.Save.Size = New System.Drawing.Size(99, 29)
        Me.Save.TabIndex = 1
        Me.Save.Text = "&Save"
        Me.Save.UseVisualStyleBackColor = True
        '
        'NewRecord
        '
        Me.NewRecord.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewRecord.Location = New System.Drawing.Point(16, 28)
        Me.NewRecord.Name = "NewRecord"
        Me.NewRecord.Size = New System.Drawing.Size(99, 29)
        Me.NewRecord.TabIndex = 0
        Me.NewRecord.Text = "&New"
        Me.NewRecord.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(32, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 17)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Stock ID"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.LightGray
        Me.Label9.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(586, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(116, 22)
        Me.Label9.TabIndex = 58
        Me.Label9.Text = "Current Stock"
        '
        'dtpStockDate
        '
        Me.dtpStockDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpStockDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStockDate.Location = New System.Drawing.Point(374, 182)
        Me.dtpStockDate.Name = "dtpStockDate"
        Me.dtpStockDate.Size = New System.Drawing.Size(120, 24)
        Me.dtpStockDate.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(299, 184)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 17)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Date"
        '
        'txtPackets
        '
        Me.txtPackets.Location = New System.Drawing.Point(165, 259)
        Me.txtPackets.Name = "txtPackets"
        Me.txtPackets.Size = New System.Drawing.Size(91, 24)
        Me.txtPackets.TabIndex = 7
        '
        'txtWeight
        '
        Me.txtWeight.Location = New System.Drawing.Point(165, 181)
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.ReadOnly = True
        Me.txtWeight.Size = New System.Drawing.Size(91, 24)
        Me.txtWeight.TabIndex = 4
        '
        'DataGridView1
        '
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle34.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle34
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle35.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle35.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle35
        Me.DataGridView1.Location = New System.Drawing.Point(542, 54)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle36.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle36
        Me.DataGridView1.Size = New System.Drawing.Size(609, 469)
        Me.DataGridView1.TabIndex = 55
        '
        'txtTotalPackets
        '
        Me.txtTotalPackets.Location = New System.Drawing.Point(165, 297)
        Me.txtTotalPackets.Name = "txtTotalPackets"
        Me.txtTotalPackets.ReadOnly = True
        Me.txtTotalPackets.Size = New System.Drawing.Size(91, 24)
        Me.txtTotalPackets.TabIndex = 8
        '
        'txtCartons
        '
        Me.txtCartons.Location = New System.Drawing.Point(165, 220)
        Me.txtCartons.Name = "txtCartons"
        Me.txtCartons.Size = New System.Drawing.Size(91, 24)
        Me.txtCartons.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 259)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 17)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Packets (Per Carton)"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(374, 72)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(29, 25)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "<"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.MediumOrchid
        Me.GroupBox1.Controls.Add(Me.txtCategory)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.txtStockID)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.dtpStockDate)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtPackets)
        Me.GroupBox1.Controls.Add(Me.txtWeight)
        Me.GroupBox1.Controls.Add(Me.txtTotalPackets)
        Me.GroupBox1.Controls.Add(Me.txtCartons)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.txtProductName)
        Me.GroupBox1.Controls.Add(Me.txtProductCode)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(14, 55)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(516, 346)
        Me.GroupBox1.TabIndex = 54
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Stock Details"
        '
        'txtProductName
        '
        Me.txtProductName.Location = New System.Drawing.Point(165, 109)
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.ReadOnly = True
        Me.txtProductName.Size = New System.Drawing.Size(331, 24)
        Me.txtProductName.TabIndex = 2
        '
        'txtProductCode
        '
        Me.txtProductCode.Location = New System.Drawing.Point(165, 73)
        Me.txtProductCode.Name = "txtProductCode"
        Me.txtProductCode.ReadOnly = True
        Me.txtProductCode.Size = New System.Drawing.Size(189, 24)
        Me.txtProductCode.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(32, 300)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 17)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Total Packets"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(32, 220)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 17)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Cartons"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 184)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Weight (Per Qty)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Product Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Product Code"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(1131, 527)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(5, 5)
        Me.Button3.TabIndex = 59
        Me.Button3.Text = "&c"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'frmStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1305, 540)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button3)
        Me.Name = "frmStock"
        Me.Text = "frmStock"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Delete As System.Windows.Forms.Button
    Friend WithEvents txtCategory As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Update_Record As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtStockID As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Save As System.Windows.Forms.Button
    Friend WithEvents NewRecord As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpStockDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPackets As System.Windows.Forms.TextBox
    Friend WithEvents txtWeight As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtTotalPackets As System.Windows.Forms.TextBox
    Friend WithEvents txtCartons As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtProductName As System.Windows.Forms.TextBox
    Friend WithEvents txtProductCode As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
