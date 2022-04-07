﻿' R- Instat
' Copyright (C) 2015-2017
'
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License 
' along with this program.  If not, see <http://www.gnu.org/licenses/>.

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgCorrelation
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.rdoCompleteRowsOnly = New System.Windows.Forms.RadioButton()
        Me.rdoPairwise = New System.Windows.Forms.RadioButton()
        Me.lblMethod = New System.Windows.Forms.Label()
        Me.lblDisplayNas = New System.Windows.Forms.Label()
        Me.lblDecimalPlaces = New System.Windows.Forms.Label()
        Me.rdoTwoColumns = New System.Windows.Forms.RadioButton()
        Me.rdoMultipleColumns = New System.Windows.Forms.RadioButton()
        Me.grpMethod = New System.Windows.Forms.GroupBox()
        Me.rdoKendall = New System.Windows.Forms.RadioButton()
        Me.rdoPearson = New System.Windows.Forms.RadioButton()
        Me.rdoSpearman = New System.Windows.Forms.RadioButton()
        Me.grpMissing = New System.Windows.Forms.GroupBox()
        Me.cmdOptions = New System.Windows.Forms.Button()
        Me.grpDisplayOptions = New System.Windows.Forms.GroupBox()
        Me.lblConfInterval = New System.Windows.Forms.Label()
        Me.lblSecondColumn = New System.Windows.Forms.Label()
        Me.lblSelectedVariables = New System.Windows.Forms.Label()
        Me.lblFirstColumn = New System.Windows.Forms.Label()
        Me.ucrSaveFashion = New instat.ucrSave()
        Me.ucrChkDisplayOptions = New instat.ucrCheck()
        Me.ucrChkAbsolute = New instat.ucrCheck()
        Me.ucrInputRearrange = New instat.ucrInputComboBox()
        Me.ucrChkRearrange = New instat.ucrCheck()
        Me.ucrInputDisplayNas = New instat.ucrInputComboBox()
        Me.ucrChkLeadingZeros = New instat.ucrCheck()
        Me.ucrNudDecimalPlaces = New instat.ucrNud()
        Me.ucrPnlColumns = New instat.UcrPanel()
        Me.ucrPnlMethod = New instat.UcrPanel()
        Me.ucrPnlCompletePairwise = New instat.UcrPanel()
        Me.ucrSelectorCorrelation = New instat.ucrSelectorByDataFrameAddRemove()
        Me.ucrBase = New instat.ucrButtons()
        Me.ucrChkShave = New instat.ucrCheck()
        Me.ucrSaveDataFrame = New instat.ucrSave()
        Me.ucrSaveModel = New instat.ucrSave()
        Me.ucrReceiverMultipleColumns = New instat.ucrReceiverMultiple()
        Me.ucrReceiverSecondColumn = New instat.ucrReceiverSingle()
        Me.ucrReceiverFirstColumn = New instat.ucrReceiverSingle()
        Me.ucrNudConfidenceInterval = New instat.ucrNud()
        Me.grpMethod.SuspendLayout()
        Me.grpMissing.SuspendLayout()
        Me.grpDisplayOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'rdoCompleteRowsOnly
        '
        Me.rdoCompleteRowsOnly.AutoSize = True
        Me.rdoCompleteRowsOnly.Checked = True
        Me.rdoCompleteRowsOnly.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rdoCompleteRowsOnly.Location = New System.Drawing.Point(6, 17)
        Me.rdoCompleteRowsOnly.Name = "rdoCompleteRowsOnly"
        Me.rdoCompleteRowsOnly.Size = New System.Drawing.Size(116, 17)
        Me.rdoCompleteRowsOnly.TabIndex = 1
        Me.rdoCompleteRowsOnly.TabStop = True
        Me.rdoCompleteRowsOnly.Tag = "Complete_rows_only"
        Me.rdoCompleteRowsOnly.Text = "Complete rows only"
        Me.rdoCompleteRowsOnly.UseVisualStyleBackColor = True
        '
        'rdoPairwise
        '
        Me.rdoPairwise.AutoSize = True
        Me.rdoPairwise.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rdoPairwise.Location = New System.Drawing.Point(6, 43)
        Me.rdoPairwise.Name = "rdoPairwise"
        Me.rdoPairwise.Size = New System.Drawing.Size(64, 17)
        Me.rdoPairwise.TabIndex = 2
        Me.rdoPairwise.Tag = "Pairwise"
        Me.rdoPairwise.Text = "Pairwise"
        Me.rdoPairwise.UseVisualStyleBackColor = True
        '
        'lblMethod
        '
        Me.lblMethod.AutoSize = True
        Me.lblMethod.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMethod.Location = New System.Drawing.Point(125, 446)
        Me.lblMethod.Name = "lblMethod"
        Me.lblMethod.Size = New System.Drawing.Size(46, 13)
        Me.lblMethod.TabIndex = 61
        Me.lblMethod.Text = "Method:"
        '
        'lblDisplayNas
        '
        Me.lblDisplayNas.AutoSize = True
        Me.lblDisplayNas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDisplayNas.Location = New System.Drawing.Point(17, 393)
        Me.lblDisplayNas.Name = "lblDisplayNas"
        Me.lblDisplayNas.Size = New System.Drawing.Size(106, 13)
        Me.lblDisplayNas.TabIndex = 56
        Me.lblDisplayNas.Text = "Display On Diagonal:"
        '
        'lblDecimalPlaces
        '
        Me.lblDecimalPlaces.AutoSize = True
        Me.lblDecimalPlaces.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDecimalPlaces.Location = New System.Drawing.Point(17, 369)
        Me.lblDecimalPlaces.Name = "lblDecimalPlaces"
        Me.lblDecimalPlaces.Size = New System.Drawing.Size(83, 13)
        Me.lblDecimalPlaces.TabIndex = 53
        Me.lblDecimalPlaces.Text = "Decimal Places:"
        '
        'rdoTwoColumns
        '
        Me.rdoTwoColumns.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoTwoColumns.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoTwoColumns.FlatAppearance.BorderSize = 2
        Me.rdoTwoColumns.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoTwoColumns.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdoTwoColumns.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rdoTwoColumns.Location = New System.Drawing.Point(230, 7)
        Me.rdoTwoColumns.Name = "rdoTwoColumns"
        Me.rdoTwoColumns.Size = New System.Drawing.Size(127, 27)
        Me.rdoTwoColumns.TabIndex = 35
        Me.rdoTwoColumns.TabStop = True
        Me.rdoTwoColumns.Text = "Two Variables"
        Me.rdoTwoColumns.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoTwoColumns.UseVisualStyleBackColor = True
        '
        'rdoMultipleColumns
        '
        Me.rdoMultipleColumns.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoMultipleColumns.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoMultipleColumns.FlatAppearance.BorderSize = 2
        Me.rdoMultipleColumns.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoMultipleColumns.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdoMultipleColumns.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rdoMultipleColumns.Location = New System.Drawing.Point(100, 7)
        Me.rdoMultipleColumns.Name = "rdoMultipleColumns"
        Me.rdoMultipleColumns.Size = New System.Drawing.Size(132, 27)
        Me.rdoMultipleColumns.TabIndex = 36
        Me.rdoMultipleColumns.TabStop = True
        Me.rdoMultipleColumns.Text = "Multiple Variables"
        Me.rdoMultipleColumns.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoMultipleColumns.UseVisualStyleBackColor = True
        '
        'grpMethod
        '
        Me.grpMethod.Controls.Add(Me.rdoKendall)
        Me.grpMethod.Controls.Add(Me.rdoPearson)
        Me.grpMethod.Controls.Add(Me.rdoSpearman)
        Me.grpMethod.Controls.Add(Me.ucrPnlMethod)
        Me.grpMethod.Location = New System.Drawing.Point(9, 241)
        Me.grpMethod.Name = "grpMethod"
        Me.grpMethod.Size = New System.Drawing.Size(246, 45)
        Me.grpMethod.TabIndex = 44
        Me.grpMethod.TabStop = False
        Me.grpMethod.Tag = "Method"
        Me.grpMethod.Text = "Method"
        '
        'rdoKendall
        '
        Me.rdoKendall.AutoSize = True
        Me.rdoKendall.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rdoKendall.Location = New System.Drawing.Point(91, 15)
        Me.rdoKendall.Name = "rdoKendall"
        Me.rdoKendall.Size = New System.Drawing.Size(60, 17)
        Me.rdoKendall.TabIndex = 2
        Me.rdoKendall.Tag = "Kendall"
        Me.rdoKendall.Text = "Kendall"
        Me.rdoKendall.UseVisualStyleBackColor = True
        '
        'rdoPearson
        '
        Me.rdoPearson.AutoSize = True
        Me.rdoPearson.Checked = True
        Me.rdoPearson.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rdoPearson.Location = New System.Drawing.Point(15, 15)
        Me.rdoPearson.Name = "rdoPearson"
        Me.rdoPearson.Size = New System.Drawing.Size(64, 17)
        Me.rdoPearson.TabIndex = 1
        Me.rdoPearson.TabStop = True
        Me.rdoPearson.Tag = "Pearson"
        Me.rdoPearson.Text = "Pearson"
        Me.rdoPearson.UseVisualStyleBackColor = True
        '
        'rdoSpearman
        '
        Me.rdoSpearman.AutoSize = True
        Me.rdoSpearman.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rdoSpearman.Location = New System.Drawing.Point(164, 15)
        Me.rdoSpearman.Name = "rdoSpearman"
        Me.rdoSpearman.Size = New System.Drawing.Size(73, 17)
        Me.rdoSpearman.TabIndex = 3
        Me.rdoSpearman.Tag = "Spearman"
        Me.rdoSpearman.Text = "Spearman"
        Me.rdoSpearman.UseVisualStyleBackColor = True
        '
        'grpMissing
        '
        Me.grpMissing.Controls.Add(Me.rdoCompleteRowsOnly)
        Me.grpMissing.Controls.Add(Me.rdoPairwise)
        Me.grpMissing.Controls.Add(Me.ucrPnlCompletePairwise)
        Me.grpMissing.Location = New System.Drawing.Point(261, 241)
        Me.grpMissing.Name = "grpMissing"
        Me.grpMissing.Size = New System.Drawing.Size(158, 71)
        Me.grpMissing.TabIndex = 45
        Me.grpMissing.TabStop = False
        Me.grpMissing.Tag = "Missing"
        Me.grpMissing.Text = "Missing"
        '
        'cmdOptions
        '
        Me.cmdOptions.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdOptions.Location = New System.Drawing.Point(301, 514)
        Me.cmdOptions.Name = "cmdOptions"
        Me.cmdOptions.Size = New System.Drawing.Size(114, 25)
        Me.cmdOptions.TabIndex = 49
        Me.cmdOptions.Tag = "Options"
        Me.cmdOptions.Text = "Options"
        Me.cmdOptions.UseVisualStyleBackColor = True
        '
        'grpDisplayOptions
        '
        Me.grpDisplayOptions.Controls.Add(Me.ucrChkShave)
        Me.grpDisplayOptions.Location = New System.Drawing.Point(9, 346)
        Me.grpDisplayOptions.Name = "grpDisplayOptions"
        Me.grpDisplayOptions.Size = New System.Drawing.Size(410, 156)
        Me.grpDisplayOptions.TabIndex = 63
        Me.grpDisplayOptions.TabStop = False
        Me.grpDisplayOptions.Tag = "Display Options"
        Me.grpDisplayOptions.Text = "Display Options"
        '
        'lblConfInterval
        '
        Me.lblConfInterval.AutoSize = True
        Me.lblConfInterval.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblConfInterval.Location = New System.Drawing.Point(9, 294)
        Me.lblConfInterval.Name = "lblConfInterval"
        Me.lblConfInterval.Size = New System.Drawing.Size(102, 13)
        Me.lblConfInterval.TabIndex = 46
        Me.lblConfInterval.Text = "Confidence Interval:"
        '
        'lblSecondColumn
        '
        Me.lblSecondColumn.AutoSize = True
        Me.lblSecondColumn.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSecondColumn.Location = New System.Drawing.Point(260, 122)
        Me.lblSecondColumn.Name = "lblSecondColumn"
        Me.lblSecondColumn.Size = New System.Drawing.Size(88, 13)
        Me.lblSecondColumn.TabIndex = 42
        Me.lblSecondColumn.Tag = "Second_column"
        Me.lblSecondColumn.Text = "Second Variable:"
        '
        'lblSelectedVariables
        '
        Me.lblSelectedVariables.AutoSize = True
        Me.lblSelectedVariables.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSelectedVariables.Location = New System.Drawing.Point(260, 73)
        Me.lblSelectedVariables.Name = "lblSelectedVariables"
        Me.lblSelectedVariables.Size = New System.Drawing.Size(53, 13)
        Me.lblSelectedVariables.TabIndex = 38
        Me.lblSelectedVariables.Tag = ""
        Me.lblSelectedVariables.Text = "Variables:"
        '
        'lblFirstColumn
        '
        Me.lblFirstColumn.AutoSize = True
        Me.lblFirstColumn.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFirstColumn.Location = New System.Drawing.Point(260, 73)
        Me.lblFirstColumn.Name = "lblFirstColumn"
        Me.lblFirstColumn.Size = New System.Drawing.Size(70, 13)
        Me.lblFirstColumn.TabIndex = 39
        Me.lblFirstColumn.Tag = "First_column"
        Me.lblFirstColumn.Text = "First Variable:"
        '
        'ucrSaveFashion
        '
        Me.ucrSaveFashion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrSaveFashion.Location = New System.Drawing.Point(10, 510)
        Me.ucrSaveFashion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrSaveFashion.Name = "ucrSaveFashion"
        Me.ucrSaveFashion.Size = New System.Drawing.Size(266, 24)
        Me.ucrSaveFashion.TabIndex = 65
        '
        'ucrChkDisplayOptions
        '
        Me.ucrChkDisplayOptions.AutoSize = True
        Me.ucrChkDisplayOptions.Checked = False
        Me.ucrChkDisplayOptions.Location = New System.Drawing.Point(10, 317)
        Me.ucrChkDisplayOptions.Name = "ucrChkDisplayOptions"
        Me.ucrChkDisplayOptions.Size = New System.Drawing.Size(192, 23)
        Me.ucrChkDisplayOptions.TabIndex = 64
        '
        'ucrChkAbsolute
        '
        Me.ucrChkAbsolute.AutoSize = True
        Me.ucrChkAbsolute.Checked = False
        Me.ucrChkAbsolute.Location = New System.Drawing.Point(266, 444)
        Me.ucrChkAbsolute.Name = "ucrChkAbsolute"
        Me.ucrChkAbsolute.Size = New System.Drawing.Size(117, 23)
        Me.ucrChkAbsolute.TabIndex = 62
        '
        'ucrInputRearrange
        '
        Me.ucrInputRearrange.AddQuotesIfUnrecognised = True
        Me.ucrInputRearrange.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrInputRearrange.GetSetSelectedIndex = -1
        Me.ucrInputRearrange.IsReadOnly = False
        Me.ucrInputRearrange.Location = New System.Drawing.Point(175, 443)
        Me.ucrInputRearrange.Name = "ucrInputRearrange"
        Me.ucrInputRearrange.Size = New System.Drawing.Size(79, 21)
        Me.ucrInputRearrange.TabIndex = 60
        '
        'ucrChkRearrange
        '
        Me.ucrChkRearrange.AutoSize = True
        Me.ucrChkRearrange.Checked = False
        Me.ucrChkRearrange.Location = New System.Drawing.Point(17, 445)
        Me.ucrChkRearrange.Name = "ucrChkRearrange"
        Me.ucrChkRearrange.Size = New System.Drawing.Size(96, 23)
        Me.ucrChkRearrange.TabIndex = 59
        '
        'ucrInputDisplayNas
        '
        Me.ucrInputDisplayNas.AddQuotesIfUnrecognised = True
        Me.ucrInputDisplayNas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrInputDisplayNas.GetSetSelectedIndex = -1
        Me.ucrInputDisplayNas.IsReadOnly = False
        Me.ucrInputDisplayNas.Location = New System.Drawing.Point(127, 390)
        Me.ucrInputDisplayNas.Name = "ucrInputDisplayNas"
        Me.ucrInputDisplayNas.Size = New System.Drawing.Size(51, 21)
        Me.ucrInputDisplayNas.TabIndex = 57
        '
        'ucrChkLeadingZeros
        '
        Me.ucrChkLeadingZeros.AutoSize = True
        Me.ucrChkLeadingZeros.Checked = False
        Me.ucrChkLeadingZeros.Location = New System.Drawing.Point(17, 417)
        Me.ucrChkLeadingZeros.Name = "ucrChkLeadingZeros"
        Me.ucrChkLeadingZeros.Size = New System.Drawing.Size(115, 23)
        Me.ucrChkLeadingZeros.TabIndex = 55
        '
        'ucrNudDecimalPlaces
        '
        Me.ucrNudDecimalPlaces.AutoSize = True
        Me.ucrNudDecimalPlaces.DecimalPlaces = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudDecimalPlaces.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ucrNudDecimalPlaces.Location = New System.Drawing.Point(127, 365)
        Me.ucrNudDecimalPlaces.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.ucrNudDecimalPlaces.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudDecimalPlaces.Name = "ucrNudDecimalPlaces"
        Me.ucrNudDecimalPlaces.Size = New System.Drawing.Size(50, 20)
        Me.ucrNudDecimalPlaces.TabIndex = 52
        Me.ucrNudDecimalPlaces.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'ucrPnlColumns
        '
        Me.ucrPnlColumns.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrPnlColumns.Location = New System.Drawing.Point(88, 4)
        Me.ucrPnlColumns.Name = "ucrPnlColumns"
        Me.ucrPnlColumns.Size = New System.Drawing.Size(280, 36)
        Me.ucrPnlColumns.TabIndex = 34
        '
        'ucrPnlMethod
        '
        Me.ucrPnlMethod.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrPnlMethod.Location = New System.Drawing.Point(8, 13)
        Me.ucrPnlMethod.Name = "ucrPnlMethod"
        Me.ucrPnlMethod.Size = New System.Drawing.Size(229, 24)
        Me.ucrPnlMethod.TabIndex = 0
        '
        'ucrPnlCompletePairwise
        '
        Me.ucrPnlCompletePairwise.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrPnlCompletePairwise.Location = New System.Drawing.Point(6, 13)
        Me.ucrPnlCompletePairwise.Name = "ucrPnlCompletePairwise"
        Me.ucrPnlCompletePairwise.Size = New System.Drawing.Size(146, 49)
        Me.ucrPnlCompletePairwise.TabIndex = 0
        '
        'ucrSelectorCorrelation
        '
        Me.ucrSelectorCorrelation.AutoSize = True
        Me.ucrSelectorCorrelation.bDropUnusedFilterLevels = False
        Me.ucrSelectorCorrelation.bShowHiddenColumns = False
        Me.ucrSelectorCorrelation.bUseCurrentFilter = True
        Me.ucrSelectorCorrelation.Location = New System.Drawing.Point(9, 52)
        Me.ucrSelectorCorrelation.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrSelectorCorrelation.Name = "ucrSelectorCorrelation"
        Me.ucrSelectorCorrelation.Size = New System.Drawing.Size(213, 183)
        Me.ucrSelectorCorrelation.TabIndex = 37
        '
        'ucrBase
        '
        Me.ucrBase.AutoSize = True
        Me.ucrBase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrBase.Location = New System.Drawing.Point(11, 540)
        Me.ucrBase.Name = "ucrBase"
        Me.ucrBase.Size = New System.Drawing.Size(405, 52)
        Me.ucrBase.TabIndex = 50
        '
        'ucrChkShave
        '
        Me.ucrChkShave.AutoSize = True
        Me.ucrChkShave.Checked = False
        Me.ucrChkShave.Location = New System.Drawing.Point(8, 128)
        Me.ucrChkShave.Name = "ucrChkShave"
        Me.ucrChkShave.Size = New System.Drawing.Size(154, 23)
        Me.ucrChkShave.TabIndex = 26
        '
        'ucrSaveDataFrame
        '
        Me.ucrSaveDataFrame.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrSaveDataFrame.Location = New System.Drawing.Point(10, 510)
        Me.ucrSaveDataFrame.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrSaveDataFrame.Name = "ucrSaveDataFrame"
        Me.ucrSaveDataFrame.Size = New System.Drawing.Size(266, 24)
        Me.ucrSaveDataFrame.TabIndex = 54
        '
        'ucrSaveModel
        '
        Me.ucrSaveModel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrSaveModel.Location = New System.Drawing.Point(10, 510)
        Me.ucrSaveModel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrSaveModel.Name = "ucrSaveModel"
        Me.ucrSaveModel.Size = New System.Drawing.Size(266, 24)
        Me.ucrSaveModel.TabIndex = 48
        '
        'ucrReceiverMultipleColumns
        '
        Me.ucrReceiverMultipleColumns.AutoSize = True
        Me.ucrReceiverMultipleColumns.frmParent = Me
        Me.ucrReceiverMultipleColumns.Location = New System.Drawing.Point(258, 90)
        Me.ucrReceiverMultipleColumns.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverMultipleColumns.Name = "ucrReceiverMultipleColumns"
        Me.ucrReceiverMultipleColumns.Selector = Nothing
        Me.ucrReceiverMultipleColumns.Size = New System.Drawing.Size(120, 100)
        Me.ucrReceiverMultipleColumns.strNcFilePath = ""
        Me.ucrReceiverMultipleColumns.TabIndex = 41
        Me.ucrReceiverMultipleColumns.ucrSelector = Nothing
        '
        'ucrReceiverSecondColumn
        '
        Me.ucrReceiverSecondColumn.AutoSize = True
        Me.ucrReceiverSecondColumn.frmParent = Me
        Me.ucrReceiverSecondColumn.Location = New System.Drawing.Point(258, 137)
        Me.ucrReceiverSecondColumn.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverSecondColumn.Name = "ucrReceiverSecondColumn"
        Me.ucrReceiverSecondColumn.Selector = Nothing
        Me.ucrReceiverSecondColumn.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverSecondColumn.strNcFilePath = ""
        Me.ucrReceiverSecondColumn.TabIndex = 43
        Me.ucrReceiverSecondColumn.ucrSelector = Nothing
        '
        'ucrReceiverFirstColumn
        '
        Me.ucrReceiverFirstColumn.AutoSize = True
        Me.ucrReceiverFirstColumn.frmParent = Me
        Me.ucrReceiverFirstColumn.Location = New System.Drawing.Point(258, 90)
        Me.ucrReceiverFirstColumn.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverFirstColumn.Name = "ucrReceiverFirstColumn"
        Me.ucrReceiverFirstColumn.Selector = Nothing
        Me.ucrReceiverFirstColumn.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverFirstColumn.strNcFilePath = ""
        Me.ucrReceiverFirstColumn.TabIndex = 40
        Me.ucrReceiverFirstColumn.ucrSelector = Nothing
        '
        'ucrNudConfidenceInterval
        '
        Me.ucrNudConfidenceInterval.AutoSize = True
        Me.ucrNudConfidenceInterval.DecimalPlaces = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudConfidenceInterval.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ucrNudConfidenceInterval.Location = New System.Drawing.Point(127, 292)
        Me.ucrNudConfidenceInterval.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.ucrNudConfidenceInterval.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudConfidenceInterval.Name = "ucrNudConfidenceInterval"
        Me.ucrNudConfidenceInterval.Size = New System.Drawing.Size(50, 20)
        Me.ucrNudConfidenceInterval.TabIndex = 47
        Me.ucrNudConfidenceInterval.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'dlgCorrelation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(438, 596)
        Me.Controls.Add(Me.ucrSaveFashion)
        Me.Controls.Add(Me.ucrChkDisplayOptions)
        Me.Controls.Add(Me.ucrChkAbsolute)
        Me.Controls.Add(Me.lblMethod)
        Me.Controls.Add(Me.ucrInputRearrange)
        Me.Controls.Add(Me.ucrChkRearrange)
        Me.Controls.Add(Me.ucrInputDisplayNas)
        Me.Controls.Add(Me.lblDisplayNas)
        Me.Controls.Add(Me.ucrChkLeadingZeros)
        Me.Controls.Add(Me.lblDecimalPlaces)
        Me.Controls.Add(Me.ucrNudDecimalPlaces)
        Me.Controls.Add(Me.rdoTwoColumns)
        Me.Controls.Add(Me.rdoMultipleColumns)
        Me.Controls.Add(Me.ucrPnlColumns)
        Me.Controls.Add(Me.grpMethod)
        Me.Controls.Add(Me.grpMissing)
        Me.Controls.Add(Me.cmdOptions)
        Me.Controls.Add(Me.ucrSelectorCorrelation)
        Me.Controls.Add(Me.ucrBase)
        Me.Controls.Add(Me.grpDisplayOptions)
        Me.Controls.Add(Me.ucrSaveDataFrame)
        Me.Controls.Add(Me.ucrSaveModel)
        Me.Controls.Add(Me.lblConfInterval)
        Me.Controls.Add(Me.lblSelectedVariables)
        Me.Controls.Add(Me.lblFirstColumn)
        Me.Controls.Add(Me.ucrReceiverMultipleColumns)
        Me.Controls.Add(Me.ucrReceiverSecondColumn)
        Me.Controls.Add(Me.ucrReceiverFirstColumn)
        Me.Controls.Add(Me.lblSecondColumn)
        Me.Controls.Add(Me.ucrNudConfidenceInterval)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgCorrelation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "Correlation"
        Me.Text = "Correlation"
        Me.grpMethod.ResumeLayout(False)
        Me.grpMethod.PerformLayout()
        Me.grpMissing.ResumeLayout(False)
        Me.grpMissing.PerformLayout()
        Me.grpDisplayOptions.ResumeLayout(False)
        Me.grpDisplayOptions.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrChkDisplayOptions As ucrCheck
    Friend WithEvents ucrChkAbsolute As ucrCheck
    Friend WithEvents ucrChkShave As ucrCheck
    Friend WithEvents rdoCompleteRowsOnly As RadioButton
    Friend WithEvents rdoPairwise As RadioButton
    Friend WithEvents ucrPnlCompletePairwise As UcrPanel
    Friend WithEvents lblMethod As Label
    Friend WithEvents ucrInputRearrange As ucrInputComboBox
    Friend WithEvents ucrChkRearrange As ucrCheck
    Friend WithEvents ucrInputDisplayNas As ucrInputComboBox
    Friend WithEvents lblDisplayNas As Label
    Friend WithEvents ucrChkLeadingZeros As ucrCheck
    Friend WithEvents lblDecimalPlaces As Label
    Friend WithEvents ucrNudDecimalPlaces As ucrNud
    Friend WithEvents rdoTwoColumns As RadioButton
    Friend WithEvents rdoMultipleColumns As RadioButton
    Friend WithEvents ucrPnlColumns As UcrPanel
    Friend WithEvents grpMethod As GroupBox
    Friend WithEvents rdoKendall As RadioButton
    Friend WithEvents rdoPearson As RadioButton
    Friend WithEvents rdoSpearman As RadioButton
    Friend WithEvents ucrPnlMethod As UcrPanel
    Friend WithEvents grpMissing As GroupBox
    Friend WithEvents cmdOptions As Button
    Friend WithEvents ucrSelectorCorrelation As ucrSelectorByDataFrameAddRemove
    Friend WithEvents ucrBase As ucrButtons
    Friend WithEvents grpDisplayOptions As GroupBox
    Friend WithEvents ucrSaveDataFrame As ucrSave
    Friend WithEvents ucrSaveModel As ucrSave
    Friend WithEvents ucrNudConfidenceInterval As ucrNud
    Friend WithEvents lblConfInterval As Label
    Friend WithEvents ucrReceiverMultipleColumns As ucrReceiverMultiple
    Friend WithEvents ucrReceiverSecondColumn As ucrReceiverSingle
    Friend WithEvents lblSecondColumn As Label
    Friend WithEvents lblSelectedVariables As Label
    Friend WithEvents ucrReceiverFirstColumn As ucrReceiverSingle
    Friend WithEvents lblFirstColumn As Label
    Friend WithEvents ucrSaveFashion As ucrSave
End Class