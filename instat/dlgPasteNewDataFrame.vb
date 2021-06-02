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

Imports RDotNet
Imports instat.Translations
Public Class dlgPasteNewDataFrame

    Private bFirstLoad As Boolean = True
    Private bReset As Boolean = True
    Private clsAddData, clsDataList, clsPasteFunction As New RFunction

    Private Sub dlgPasteNewDataFrame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        autoTranslate(Me)
        If bFirstLoad Then
            InitialiseDialog()
            bFirstLoad = False
        End If
        If bReset Then
            SetDefaults()
        End If
        'reset the clip board data parameter value
        SetClipBoardDataParameter()
        SetRCodeForControls(bReset)
        bReset = False
        TestOkEnabled()
    End Sub

    Private Sub InitialiseDialog()
        'todo. attach the help id later
        'ucrBase.iHelpTopicID = 332

        ucrSaveNewDFName.SetIsTextBox()
        ucrSaveNewDFName.SetSaveTypeAsDataFrame()
        ucrSaveNewDFName.SetLabelText("New Data Frame Name:")
        ucrSaveNewDFName.SetPrefix("data")

        ucrChkRowHeader.SetText("First row is header")
        ucrChkRowHeader.SetParameter(New RParameter("header", 1))

        ucrNudPreviewLines.Maximum = 1000

    End Sub

    Private Sub SetDefaults()
        clsAddData = New RFunction
        clsDataList = New RFunction
        clsPasteFunction = New RFunction

        'todo 29/05/2021. this is temporarily done this way because of how
        'function ConstructAssignTo in clsRCodeStructure is currently implemented.
        'It doesn't construct assignTo statements correctly
        clsAddData.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$import_data")
        clsAddData.AddParameter("data_tables", clsRFunctionParameter:=clsDataList, iPosition:=0)
        clsDataList.SetRCommand("list")
        clsDataList.AddParameter(strParameterName:=ucrSaveNewDFName.GetText, clsRFunctionParameter:=clsPasteFunction)

        clsPasteFunction.SetPackageName("clipr")
        clsPasteFunction.SetRCommand("read_clip_tbl")
        SetClipBoardDataParameter()
        clsPasteFunction.AddParameter("header", "TRUE", iPosition:=1)
        'copied data could be long, so restrict to 1000 rows only for import. 
        'please note. for some reason,this parameter is not used by clipr if x(data) parameter is specified.
        clsPasteFunction.AddParameter("nrows", 1000, iPosition:=2)

        ucrBase.clsRsyntax.SetBaseRFunction(clsAddData)

        ucrNudPreviewLines.Value = 10
        ucrSaveNewDFName.Reset()
    End Sub

    Private Sub SetRCodeForControls(bReset As Boolean)
        ucrChkRowHeader.SetRCode(clsPasteFunction, bReset)
        'todo 29/05/2021. this is temporarily commented out
        'ucrSaveNewDFName.SetRCode(clsPasteFunction, bReset)
    End Sub

    Private Sub TestOkEnabled()
        ucrBase.OKEnabled(ucrSaveNewDFName.IsComplete AndAlso ValidateAndPreviewCopiedData())
    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRCodeForControls(True)
        TestOkEnabled()
    End Sub

    Private Sub ucrControls_ControlContentsChanged(ucrchangedControl As ucrCore) Handles ucrChkRowHeader.ControlContentsChanged, ucrNudPreviewLines.ControlContentsChanged
        TestOkEnabled()
    End Sub

    Private Sub ucrSaveNewDFName_ControlValueChangedChanged(ucrchangedControl As ucrCore) Handles ucrSaveNewDFName.ControlValueChanged
        clsDataList.ClearParameters()
        clsDataList.AddParameter(strParameterName:=ucrSaveNewDFName.GetText, clsRFunctionParameter:=clsPasteFunction)
        TestOkEnabled()
    End Sub

    Private Sub btnRefreshPreview_Click(sender As Object, e As EventArgs) Handles btnRefreshPreview.Click
        SetClipBoardDataParameter()
        TestOkEnabled()
    End Sub

    Public Sub SetClipBoardDataParameter()
        clsPasteFunction.AddParameter("x", Chr(34) & My.Computer.Clipboard.GetText & Chr(34), iPosition:=0)
    End Sub

    ''' <summary>
    ''' validates copied data and displays it for preview.
    ''' </summary>
    ''' <returns>returns true if copied data can be pasted to the selected data frame or false if not</returns>
    Private Function ValidateAndPreviewCopiedData() As Boolean
        Dim bValid As Boolean = False
        Dim dfTemp As DataFrame
        Dim expTemp As SymbolicExpression
        'Dim copiedDataRowCount As Integer
        Dim clsTempImport As New RFunction
        'split copied data to an array of indivindual lines. Used to validate length of data.
        'Dim arrStrTemp() As String = My.Computer.Clipboard.GetText().Split(New String() {Environment.NewLine}, StringSplitOptions.None)

        'set feedback controls default states
        panelNoDataPreview.Visible = True
        lblConfirmText.Text = ""
        lblConfirmText.ForeColor = Color.Red

        'remove the last element in the array. It's always an empty line and is ignored by clipr
        'If arrStrTemp.Length > 2 Then
        '    ReDim Preserve arrStrTemp(arrStrTemp.Length - 2)
        'End If

        'get the actual row count of the copied data (based on whether the header is selected or not)
        'copiedDataRowCount = If(ucrChkRowHeader.Checked, arrStrTemp.Length - 1, arrStrTemp.Length)

        'validate allowed number of rows
        'If copiedDataRowCount = 0 Then
        '    lblConfirmText.Text = "No copied data detected."
        '    Return bValid
        'Else
        '    lblConfirmText.Text = "Click Ok to paste data to new data frames."
        'End If

        'use clipr package to check if structure of data can be pasted to a data frame 
        clsTempImport.SetPackageName("clipr")
        clsTempImport.SetRCommand("read_clip_tbl")

        'reconstruct the copied data from the array. No need will just be slower, 
        'so let clipr use its clipboard functionality. commented code left here for future refernce
        'clsTempImport.AddParameter("x", Chr(34) & Strings.Join(arrStrTemp, Environment.NewLine) & Chr(34))

        clsTempImport.AddParameter("header", If(ucrChkRowHeader.Checked, "TRUE", "FALSE"))
        'copied data could be long, so restrict to 10 rows only for preview. 
        'please note. for some reason,this parameter is not used by clipr if x(data) parameter is specified.
        clsTempImport.AddParameter("nrows", ucrNudPreviewLines.Value)

        'get the data frame produced by clipr data frame
        expTemp = frmMain.clsRLink.RunInternalScriptGetValue(clsTempImport.ToScript(), bSilent:=True)
        dfTemp = expTemp?.AsDataFrame
        If dfTemp IsNot Nothing Then
            Try
                'try to preview the data
                frmMain.clsGrids.FillSheet(dfTemp, "temp", grdDataPreview, bIncludeDataTypes:=False, iColMax:=frmMain.clsGrids.iMaxCols)
                bValid = True
                lblConfirmText.Text = "Click Ok to paste data to new data frames." & Environment.NewLine &
                   "Found: Columns = " & dfTemp.ColumnCount & ", Rows = " & dfTemp.RowCount
                lblConfirmText.ForeColor = Color.Green
            Catch
                lblConfirmText.Text = "Could not preview data. Cannot be pasted."
                lblConfirmText.ForeColor = Color.Red
            End Try
        Else
            lblConfirmText.Text = "Could not preview data. Cannot be pasted."
            lblConfirmText.ForeColor = Color.Red
        End If

        panelNoDataPreview.Visible = Not bValid
        Return bValid
    End Function

End Class
