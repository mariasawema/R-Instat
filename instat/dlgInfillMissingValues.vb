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

Imports instat.Translations
Public Class dlgInfillMissingValues
    Private bFirstLoad As Boolean = True
    Private bReset As Boolean = True
    Private iDialogHeight As Integer
    Private iBaseMaxY
    Private clsApproximateFunction, clsAggregateFunction, clsNaLocfFunction, clsSplineFunction, clsNaFillFunction, clsStructTSFunction, clsSetSeedFunction, clsAveFunction, clsPatchClimateElementFunction, clsVisualizeElementNa As New RFunction
    Private clsBracketOperator As New ROperator
    Private Sub dlgInfillMissingValues_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        autoTranslate(Me)
        If bFirstLoad Then
            iDialogHeight = Me.Height
            iBaseMaxY = ucrBase.Location.Y
            InitialiseDialog()
            bFirstLoad = False
        End If
        If bReset Then
            SetDefaults()
        End If
        SetRcodeForControls(bReset)
        bReset = False
        TestOkEnabled()
    End Sub

    Private Sub InitialiseDialog()
        Dim dctFunctionNames As New Dictionary(Of String, String)
        ucrBase.clsRsyntax.bExcludeAssignedFunctionOutput = False

        'TODO:Enabled once working, added now for display purposes and therefore show the intention!
        ucrReceiverMultipleStation.Enabled = False
        lblMultipleStation.Enabled = False

        ucrPnlOptions.AddRadioButton(rdoDisplay)
        ucrPnlOptions.AddRadioButton(rdoFitSingle)
        ucrPnlOptions.AddRadioButton(rdoFitMultiple)
        ucrPnlOptions.AddRadioButton(rdoShow)

        ucrPnlOptions.AddFunctionNamesCondition(rdoFitSingle, {"ave", "na.aggregate"})
        ucrPnlOptions.AddFunctionNamesCondition(rdoFitMultiple, {frmMain.clsRLink.strInstatDataObject & "$patch_climate_element"})
        ucrPnlOptions.AddFunctionNamesCondition({rdoDisplay, rdoShow}, frmMain.clsRLink.strInstatDataObject & "visualize_element_na")
        ucrPnlOptions.AddParameterValuesCondition(rdoDisplay, "type", "distribution")
        ucrPnlOptions.AddParameterValuesCondition(rdoShow, "type", "imputations")

        ucrPnlMethods.AddRadioButton(rdoNaAggregate)
        ucrPnlMethods.AddRadioButton(rdoNaApproximate)
        ucrPnlMethods.AddRadioButton(rdoNaFill)
        ucrPnlMethods.AddRadioButton(rdoNaLocf)
        ucrPnlMethods.AddRadioButton(rdoNaStructTS)
        ucrPnlMethods.AddRadioButton(rdoNaSpline)

        ucrPnlMethods.AddFunctionNamesCondition(rdoNaApproximate, "na.approx")
        ucrPnlMethods.AddFunctionNamesCondition(rdoNaAggregate, "na.aggregate")
        ucrPnlMethods.AddFunctionNamesCondition(rdoNaFill, "na.fill")
        ucrPnlMethods.AddFunctionNamesCondition(rdoNaLocf, "na.locf")
        ucrPnlMethods.AddFunctionNamesCondition(rdoNaStructTS, "na.StructTS")
        ucrPnlMethods.AddFunctionNamesCondition(rdoNaSpline, "na.spline")

        ucrPnlStartEnd.AddRadioButton(rdoLeaveAsMissing)
        ucrPnlStartEnd.AddRadioButton(rdoExtendFill)

        ucrSelectorInfillMissing.SetParameter(New RParameter("data_name", 0))
        ucrSelectorInfillMissing.SetParameterIsString()

        ucrReceiverElement.SetParameter(New RParameter("x", 0))
        ucrReceiverElement.Selector = ucrSelectorInfillMissing
        ucrReceiverElement.SetParameterIsRFunction()
        ucrReceiverElement.bUseFilteredData = False

        ucrReceiverStation.SetParameter(New RParameter("factor", 1, bNewIncludeArgumentName:=False))
        ucrReceiverStation.Selector = ucrSelectorInfillMissing
        ucrReceiverStation.SetParameterIsRFunction()
        ucrReceiverStation.SetClimaticType("station")
        ucrReceiverStation.bUseFilteredData = False
        ucrReceiverStation.bAutoFill = True

        ucrInputConstant.SetValidationTypeAsNumeric()
        ucrInputConstant.AddQuotesIfUnrecognised = False

        ucrInputComboFunction.SetParameter(New RParameter("FUN", 2))
        dctFunctionNames.Add("Mean", "summary_mean")
        dctFunctionNames.Add("Median", "summary_median")
        dctFunctionNames.Add("Sample", "summary_sample")
        ucrInputComboFunction.SetItems(dctFunctionNames)
        ucrInputComboFunction.SetDropDownStyleAsNonEditable()

        ucrChkCopyFromBelow.SetParameter(New RParameter("fromLast", 1))
        ucrChkCopyFromBelow.SetValuesCheckedAndUnchecked("TRUE", "FALSE")
        ucrChkCopyFromBelow.SetText("Copy from Below")
        ucrChkCopyFromBelow.SetRDefault("FALSE")

        ucrChkBy.SetText("By:")
        ucrChkBy.AddParameterPresentCondition(True, "by")
        ucrChkBy.AddParameterPresentCondition(False, "by", False)

        ucrChkMaxGap.SetText("Maximum Gap:")
        ucrChkMaxGap.AddParameterPresentCondition(True, "maxgap")
        ucrChkMaxGap.AddParameterPresentCondition(False, "maxgap", False)

        ucrReceiverByFactor.SetParameter(New RParameter("by", 1, bNewIncludeArgumentName:=False))
        ucrReceiverByFactor.Selector = ucrSelectorInfillMissing
        ucrReceiverByFactor.SetParameterIsRFunction()
        ucrReceiverByFactor.SetIncludedDataTypes({"factor", "character"}, bStrict:=True)
        ucrReceiverByFactor.strSelectorHeading = "Factors and Characters"
        ucrReceiverByFactor.SetClimaticType("month")
        ucrReceiverByFactor.bAutoFill = True

        ucrNudMaximum.SetParameter(New RParameter("maxgap", 5))
        ucrNudMaximum.SetMinMax(iNewMin:=1, iNewMax:=Integer.MaxValue)

        ucrNudSetSeed.SetParameter(New RParameter("seed", 0))

        ucrChkSetSeed.SetText("Set Seed:")
        ucrChkSetSeed.AddRSyntaxContainsFunctionNamesCondition(True, {"set.seed"})
        ucrChkSetSeed.AddRSyntaxContainsFunctionNamesCondition(False, {"set.seed"}, False)

        ucrReceiverDate.SetParameter(New RParameter("date_col_name", 1))
        ucrReceiverDate.Selector = ucrSelectorInfillMissing
        ucrReceiverDate.SetClimaticType("date")
        ucrReceiverDate.SetParameterIsString()
        ucrReceiverDate.bAutoFill = True

        ucrReceiverObserved.SetParameter(New RParameter("var", 2))
        ucrReceiverObserved.Selector = ucrSelectorInfillMissing
        ucrReceiverObserved.SetParameterIsString()
        ucrReceiverObserved.SetDataType("numeric", bStrict:=True)

        ucrReceiverEstimatedElements.SetParameter(New RParameter("vars", 3))
        ucrReceiverEstimatedElements.Selector = ucrSelectorInfillMissing
        ucrReceiverEstimatedElements.SetParameterIsString()
        ucrReceiverEstimatedElements.SetDataType("numeric", bStrict:=True)

        ucrReceiverDisplayShowDate.SetParameter(New RParameter("x_axis_labels_col_name", 4))
        ucrReceiverDisplayShowDate.Selector = ucrSelectorInfillMissing
        ucrReceiverDisplayShowDate.SetParameterIsString()
        ucrReceiverDisplayShowDate.SetClimaticType("date")
        ucrReceiverDisplayShowDate.bAutoFill = True

        ucrReceiverDisplayObserved.SetParameter(New RParameter("element_col_name", 1))
        ucrReceiverDisplayObserved.Selector = ucrSelectorInfillMissing
        ucrReceiverDisplayObserved.SetParameterIsString()
        ucrReceiverDisplayObserved.SetDataType("numeric", bStrict:=True)

        ucrReceiverImputed.SetParameter(New RParameter("element_col_name_imputed", 2))
        ucrReceiverImputed.Selector = ucrSelectorInfillMissing
        ucrReceiverImputed.SetParameterIsString()
        ucrReceiverImputed.SetDataType("numeric", bStrict:=True)

        ucrPnlStartEnd.AddToLinkedControls(ucrInputConstant, {rdoLeaveAsMissing, rdoExtendFill}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrPnlMethods.AddToLinkedControls(ucrInputComboFunction, {rdoNaAggregate}, bNewLinkedHideIfParameterMissing:=True)
        ucrPnlMethods.AddToLinkedControls(ucrReceiverStation, {rdoNaApproximate, rdoNaFill, rdoNaSpline, rdoNaLocf, rdoNaStructTS}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrPnlMethods.AddToLinkedControls(ucrPnlStartEnd, {rdoNaFill}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrPnlMethods.AddToLinkedControls(ucrChkCopyFromBelow, {rdoNaLocf}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrPnlMethods.AddToLinkedControls(ucrChkBy, {rdoNaAggregate}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrChkBy.AddToLinkedControls(ucrReceiverByFactor, {True}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrChkMaxGap.AddToLinkedControls(ucrNudMaximum, {True}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrInputComboFunction.AddToLinkedControls(ucrChkSetSeed, {"Sample"}, bNewLinkedHideIfParameterMissing:=True)
        ucrChkSetSeed.AddToLinkedControls(ucrNudSetSeed, {True}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True, bNewLinkedChangeToDefaultState:=True, objNewDefaultState:=1)
        ucrPnlOptions.AddToLinkedControls({ucrReceiverDate, ucrChkMeanBias, ucrChkStdBias, ucrReceiverObserved, ucrInputNewColumnName, ucrReceiverEstimatedElements, ucrReceiverMultipleStation}, {rdoFitMultiple}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrPnlOptions.AddToLinkedControls({ucrChkBy, ucrChkMaxGap, ucrPnlMethods, ucrReceiverElement, ucrSaveNewColumn}, {rdoFitSingle}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrChkMeanBias.AddToLinkedControls(ucrInputMeanBias, {True}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True, bNewLinkedChangeToDefaultState:=True, objNewDefaultState:=5)
        ucrChkStdBias.AddToLinkedControls(ucrInputStdBias, {True}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True, bNewLinkedChangeToDefaultState:=True, objNewDefaultState:=2.5)
        ucrPnlOptions.AddToLinkedControls({ucrReceiverStation, ucrSaveGraph, ucrReceiverDisplayShowDate, ucrReceiverDisplayObserved}, {rdoDisplay, rdoShow}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrPnlOptions.AddToLinkedControls({ucrReceiverImputed}, {rdoShow}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrPnlOptions.AddToLinkedControls({ucrInputComboType}, {rdoDisplay}, bNewLinkedHideIfParameterMissing:=True)
        ucrInputComboType.AddToLinkedControls({ucrChkFlipCordinates}, {"Gap size"}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrInputComboType.AddToLinkedControls({ucrInputIntervalSize}, {"Intervals"}, bNewLinkedHideIfParameterMissing:=True)
        ucrInputComboFunction.SetLinkedDisplayControl(lblFunction)
        ucrPnlStartEnd.SetLinkedDisplayControl(grpStartEnd)
        ucrNudMaximum.SetLinkedDisplayControl(lblRows)
        ucrReceiverStation.SetLinkedDisplayControl(lblStation)
        ucrInputConstant.SetLinkedDisplayControl(lblValue)
        ucrReceiverDate.SetLinkedDisplayControl(lblDate)
        ucrReceiverEstimatedElements.SetLinkedDisplayControl(lblEstimated)
        ucrReceiverElement.SetLinkedDisplayControl(lblElement)
        ucrPnlMethods.SetLinkedDisplayControl(grpMethods)
        ucrReceiverObserved.SetLinkedDisplayControl(lblObserved)
        ucrReceiverMultipleStation.SetLinkedDisplayControl(lblMultipleStation)
        ucrInputNewColumnName.SetLinkedDisplayControl(lblNewColumnName)
        ucrReceiverDisplayShowDate.SetLinkedDisplayControl(lblDisplayDate)
        ucrReceiverDisplayObserved.SetLinkedDisplayControl(lblDisplayElement)
        ucrReceiverImputed.SetLinkedDisplayControl(lblImputed)
        ucrInputComboType.SetLinkedDisplayControl(lblType)
        ucrInputIntervalSize.SetLinkedDisplayControl(lblIntervalSize)

        ucrSaveNewColumn.SetDataFrameSelector(ucrSelectorInfillMissing.ucrAvailableDataFrames)
        ucrSaveNewColumn.SetSaveTypeAsColumn()
        ucrSaveNewColumn.SetIsComboBox()
        ucrSaveNewColumn.SetLabelText("New Column Name:")

        ucrChkMeanBias.SetText("Maximum mean bias:")
        ucrChkMeanBias.AddParameterPresentCondition(True, "max_mean_bias")
        ucrChkMeanBias.AddParameterPresentCondition(False, "max_mean_bias", False)

        ucrChkStdBias.SetText("Maximum stdev bias:")
        ucrChkStdBias.AddParameterPresentCondition(True, "max_stdev_bias")
        ucrChkStdBias.AddParameterPresentCondition(False, "max_stdev_bias", False)

        ucrInputMeanBias.SetParameter(New RParameter("max_mean_bias", 4))
        ucrInputMeanBias.AddQuotesIfUnrecognised = False
        ucrInputMeanBias.SetValidationTypeAsNumeric()

        ucrInputStdBias.SetParameter(New RParameter("max_stdev_bias", 5))
        ucrInputStdBias.AddQuotesIfUnrecognised = False
        ucrInputStdBias.SetValidationTypeAsNumeric()

        ucrInputNewColumnName.SetParameter(New RParameter("column_name", 7))
        ucrInputNewColumnName.SetDataFrameSelector(ucrSelectorInfillMissing.ucrAvailableDataFrames)

        ucrNudFacetColumns.SetParameter(New RParameter("ncol", 4))
        ucrNudFacetColumns.SetMinMax(iNewMin:=1)

        ucrChkAddLegend.SetParameter(New RParameter("legend", 9))
        ucrChkAddLegend.SetValuesCheckedAndUnchecked("TRUE", "FALSE")
        ucrChkAddLegend.SetText("Add legend")
        ucrChkAddLegend.SetRDefault("TRUE")

        ucrChkFlipCordinates.SetParameter(New RParameter("orientation", 10))
        ucrChkFlipCordinates.SetValuesCheckedAndUnchecked(Chr(34) & "horizontal" & Chr(34), Chr(34) & "vertical" & Chr(34))
        ucrChkFlipCordinates.SetText("Flip coordinates")
        ucrChkFlipCordinates.SetRDefault(Chr(34) & "horizontal" & Chr(34))

        ucrInputComboType.SetItems({"Distribution", "Gap size", "Intervals"})
        ucrInputComboType.SetDropDownStyleAsNonEditable()

        ucrInputIntervalSize.SetParameter(New RParameter("interval_size", 11))
        ucrInputIntervalSize.SetValidationTypeAsNumeric()
        ucrInputIntervalSize.AddQuotesIfUnrecognised = False

        ucrSaveGraph.SetPrefix("lineplot")
        ucrSaveGraph.SetSaveTypeAsGraph()
        ucrSaveGraph.SetDataFrameSelector(ucrSelectorInfillMissing.ucrAvailableDataFrames)
        ucrSaveGraph.SetCheckBoxText("Save Graph")
        ucrSaveGraph.SetIsComboBox()
        ucrSaveGraph.SetAssignToIfUncheckedValue("last_graph")
    End Sub

    Private Sub SetDefaults()
        clsApproximateFunction = New RFunction
        clsAggregateFunction = New RFunction
        clsNaLocfFunction = New RFunction
        clsSplineFunction = New RFunction
        clsNaFillFunction = New RFunction
        clsStructTSFunction = New RFunction
        clsSetSeedFunction = New RFunction
        clsAveFunction = New RFunction
        clsPatchClimateElementFunction = New RFunction
        clsVisualizeElementNa = New RFunction

        clsBracketOperator = New ROperator

        ucrSelectorInfillMissing.Reset()
        ucrReceiverElement.SetMeAsReceiver()
        ucrSaveNewColumn.Reset()

        'Temp fix: Set panel conditions properly!
        rdoLeaveAsMissing.Checked = True
        rdoNaApproximate.Checked = True
        ucrInputConstant.SetName("0")
        rdoDisplay.Checked = True
        ucrChkMaxGap.Checked = True
        ucrInputComboType.cboInput.SelectedItem = "Distribution"

        clsApproximateFunction.SetPackageName("zoo")
        clsApproximateFunction.SetRCommand("na.approx")
        clsApproximateFunction.AddParameter("x", "x", iPosition:=0, bIncludeArgumentName:=False)
        clsApproximateFunction.AddParameter("rule", 2, iPosition:=1)
        clsApproximateFunction.AddParameter("maxgap", 10, iPosition:=5)

        clsAggregateFunction.SetPackageName("zoo")
        clsAggregateFunction.SetRCommand("na.aggregate")
        clsAggregateFunction.AddParameter("FUN", "summary_mean", iPosition:=2)
        clsAggregateFunction.AddParameter("maxgap", 10, iPosition:=5)

        clsSetSeedFunction.SetRCommand("set.seed")

        clsNaLocfFunction.SetPackageName("zoo")
        clsNaLocfFunction.SetRCommand("na.locf0")
        clsNaLocfFunction.AddParameter("x", "x", iPosition:=0, bIncludeArgumentName:=False)

        clsSplineFunction.SetPackageName("zoo")
        clsSplineFunction.SetRCommand("na.spline")
        clsSplineFunction.AddParameter("x", "x", iPosition:=0, bIncludeArgumentName:=False)

        clsNaFillFunction.SetPackageName("zoo")
        clsNaFillFunction.SetRCommand("na.fill")
        clsNaFillFunction.AddParameter("x", "x", iPosition:=0, bIncludeArgumentName:=False)

        clsStructTSFunction.SetPackageName("imputeTS")
        clsStructTSFunction.SetRCommand("na_kalman")
        clsStructTSFunction.AddParameter("x", "x", iPosition:=0, bIncludeArgumentName:=False)
        clsStructTSFunction.AddParameter("model", Chr(34) & "StructTS" & Chr(34), iPosition:=1)
        clsStructTSFunction.AddParameter("smooth", "TRUE", iPosition:=2)

        clsAveFunction.SetPackageName("stats")
        clsAveFunction.SetRCommand("ave")

        clsBracketOperator.SetOperation(")")
        clsBracketOperator.AddParameter("left", "function(x", iPosition:=0)
        clsBracketOperator.bBrackets = False
        clsBracketOperator.bSpaceAroundOperation = False

        clsPatchClimateElementFunction.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$patch_climate_element")

        clsVisualizeElementNa.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$visualize_element_na")
        clsVisualizeElementNa.AddParameter("data_name", Chr(34) & ucrSelectorInfillMissing.ucrAvailableDataFrames.strCurrDataFrame & Chr(34), iPosition:=0)
        clsVisualizeElementNa.AddParameter("type", Chr(34) & "distribution" & Chr(34), iPosition:=8)
        clsVisualizeElementNa.AddParameter("interval_size", 1461, iPosition:=11)
        clsVisualizeElementNa.SetAssignTo("last_graph", strTempDataframe:=ucrSelectorInfillMissing.ucrAvailableDataFrames.cboAvailableDataFrames.Text, strTempGraph:="last_graph")
        clsVisualizeElementNa.AddParameter("ncol", 1, iPosition:=4)

        ucrBase.clsRsyntax.ClearCodes()
        ucrBase.clsRsyntax.SetBaseRFunction(clsVisualizeElementNa)
    End Sub

    Private Sub SetRcodeForControls(bReset As Boolean)
        ucrReceiverElement.AddAdditionalCodeParameterPair(clsAggregateFunction, New RParameter("object", 0), iAdditionalPairNo:=1)

        ucrNudMaximum.AddAdditionalCodeParameterPair(clsAggregateFunction, ucrNudMaximum.GetParameter(), iAdditionalPairNo:=1)
        ucrNudMaximum.AddAdditionalCodeParameterPair(clsSplineFunction, ucrNudMaximum.GetParameter(), iAdditionalPairNo:=2)
        ucrNudMaximum.AddAdditionalCodeParameterPair(clsNaLocfFunction, ucrNudMaximum.GetParameter(), iAdditionalPairNo:=3)
        ucrNudMaximum.AddAdditionalCodeParameterPair(clsNaFillFunction, ucrNudMaximum.GetParameter(), iAdditionalPairNo:=4)
        ucrNudMaximum.AddAdditionalCodeParameterPair(clsStructTSFunction, ucrNudMaximum.GetParameter(), iAdditionalPairNo:=5)

        ucrReceiverElement.SetRCode(clsAveFunction, bReset)
        ucrReceiverStation.SetRCode(clsAveFunction, bReset)
        ucrReceiverByFactor.SetRCode(clsAggregateFunction, bReset)
        ucrInputComboFunction.SetRCode(clsAggregateFunction, bReset)
        ucrChkCopyFromBelow.SetRCode(clsNaLocfFunction, bReset)
        ucrChkBy.SetRCode(clsAggregateFunction, bReset)
        ucrNudMaximum.SetRCode(clsApproximateFunction, bReset)
        'ucrChkMaxGap.SetRCode(clsApproximateFunction, bReset)
        ucrNudSetSeed.SetRCode(clsSetSeedFunction, bReset)
        ucrChkSetSeed.SetRSyntax(ucrBase.clsRsyntax, bReset)
        ucrSelectorInfillMissing.SetRCode(clsPatchClimateElementFunction, bReset)
        ucrReceiverDate.SetRCode(clsPatchClimateElementFunction, bReset)
        ucrReceiverObserved.SetRCode(clsPatchClimateElementFunction, bReset)
        ucrReceiverEstimatedElements.SetRCode(clsPatchClimateElementFunction, bReset)
        ucrInputMeanBias.SetRCode(clsPatchClimateElementFunction, bReset)
        ucrInputStdBias.SetRCode(clsPatchClimateElementFunction, bReset)
        ucrChkMeanBias.SetRCode(clsPatchClimateElementFunction, bReset)
        ucrChkStdBias.SetRCode(clsPatchClimateElementFunction, bReset)
        ucrInputNewColumnName.SetRCode(clsPatchClimateElementFunction, bReset)
        ucrReceiverDisplayObserved.SetRCode(clsVisualizeElementNa, bReset)
        ucrReceiverDisplayShowDate.SetRCode(clsVisualizeElementNa, bReset)
        ucrReceiverImputed.SetRCode(clsVisualizeElementNa, bReset)
        ucrNudFacetColumns.SetRCode(clsVisualizeElementNa, bReset)
        ucrChkAddLegend.SetRCode(clsVisualizeElementNa, bReset)
        ucrChkFlipCordinates.SetRCode(clsVisualizeElementNa, bReset)
        ucrInputIntervalSize.SetRCode(clsVisualizeElementNa, bReset)

        ucrSaveNewColumn.AddAdditionalRCode(clsAggregateFunction, iAdditionalPairNo:=1)

        ucrSaveNewColumn.SetRCode(clsAveFunction, bReset)
        ucrSaveGraph.SetRCode(clsVisualizeElementNa, bReset)

        'ucrPnlOptions.SetRCode(ucrBase.clsRsyntax.clsBaseFunction, bReset)
    End Sub

    Private Sub ucrPnlMethods_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrPnlMethods.ControlValueChanged, ucrReceiverElement.ControlValueChanged
        If rdoNaApproximate.Checked Then
            ucrSaveNewColumn.SetPrefix("Int_" & ucrReceiverElement.GetVariableNames(False))
            clsBracketOperator.AddParameter("right", clsRFunctionParameter:=clsApproximateFunction, iPosition:=1)
        ElseIf rdoNaAggregate.Checked Then
            ucrSaveNewColumn.SetPrefix("Typ_" & ucrReceiverElement.GetVariableNames(False))
        ElseIf rdoNaFill.Checked Then
            ucrSaveNewColumn.SetPrefix("Con_" & ucrReceiverElement.GetVariableNames(False))
            clsBracketOperator.AddParameter("right", clsRFunctionParameter:=clsNaFillFunction, iPosition:=1)
        ElseIf rdoNaStructTS.Checked Then
            ucrSaveNewColumn.SetPrefix("Str_" & ucrReceiverElement.GetVariableNames(False))
            clsBracketOperator.AddParameter("right", clsRFunctionParameter:=clsStructTSFunction, iPosition:=1)
        ElseIf rdoNaSpline.Checked Then
            ucrSaveNewColumn.SetPrefix("Spl_" & ucrReceiverElement.GetVariableNames(False))
            clsBracketOperator.AddParameter("right", clsRFunctionParameter:=clsSplineFunction, iPosition:=1)
        ElseIf rdoNaLocf.Checked Then
            ucrSaveNewColumn.SetPrefix("Cop_" & ucrReceiverElement.GetVariableNames(False))
            clsBracketOperator.AddParameter("right", clsRFunctionParameter:=clsNaLocfFunction, iPosition:=1)
        End If
        clsAveFunction.AddParameter("FUN", clsROperatorParameter:=clsBracketOperator, iPosition:=2)
    End Sub

    Private Sub ucrPnlStartEnd_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrPnlStartEnd.ControlValueChanged, ucrInputConstant.ControlValueChanged
        If rdoLeaveAsMissing.Checked Then
            clsNaFillFunction.AddParameter("fill", "list(" & "NA," & ucrInputConstant.GetValue() & ",NA" & ")", iPosition:=1)
        ElseIf rdoExtendFill.Checked Then
            clsNaFillFunction.AddParameter("fill", "list(" & Chr(34) & "extend" & Chr(34) & "," & ucrInputConstant.GetValue() & "," & Chr(34) & "extend" & Chr(34) & ")", iPosition:=1)
        Else
            clsNaFillFunction.RemoveParameterByName("fill")
        End If
    End Sub

    Private Sub ucrChkBy_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrChkBy.ControlValueChanged
        If ucrChkBy.Checked Then
            ucrReceiverByFactor.SetMeAsReceiver()
        Else
            ucrReceiverElement.SetMeAsReceiver()
        End If
    End Sub

    Private Sub ucrInputComboFunction_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrInputComboFunction.ControlValueChanged, ucrPnlMethods.ControlValueChanged, ucrChkSetSeed.ControlValueChanged, ucrPnlOptions.ControlValueChanged
        If rdoFitSingle.Checked AndAlso rdoNaAggregate.Checked AndAlso ucrChkSetSeed.Checked Then
            Select Case ucrInputComboFunction.GetValue()
                Case "Sample"
                    ucrBase.clsRsyntax.AddToBeforeCodes(clsSetSeedFunction, 0)
                Case Else
                    ucrBase.clsRsyntax.RemoveFromBeforeCodes(clsSetSeedFunction)
            End Select
        Else
            ucrBase.clsRsyntax.RemoveFromBeforeCodes(clsSetSeedFunction)
        End If
    End Sub

    Private Sub TestOkEnabled()
        If rdoFitSingle.Checked AndAlso (ucrReceiverElement.IsEmpty OrElse Not ucrSaveNewColumn.IsComplete OrElse (rdoNaFill.Checked AndAlso ((rdoLeaveAsMissing.Checked OrElse rdoExtendFill.Checked) AndAlso ucrInputConstant.IsEmpty))) Then
            ucrBase.OKEnabled(False)
        ElseIf rdoFitMultiple.Checked AndAlso (ucrReceiverDate.IsEmpty OrElse ucrReceiverObserved.IsEmpty OrElse ucrReceiverEstimatedElements.IsEmpty OrElse (ucrChkMeanBias.Checked AndAlso ucrInputMeanBias.IsEmpty) OrElse (ucrChkStdBias.Checked AndAlso ucrInputStdBias.IsEmpty) OrElse ucrInputNewColumnName.IsEmpty) Then
            ucrBase.OKEnabled(False)
        ElseIf (rdoShow.Checked AndAlso ucrReceiverImputed.IsEmpty) OrElse (rdoDisplay.Checked OrElse rdoShow.Checked) AndAlso (ucrReceiverDisplayShowDate.IsEmpty OrElse ucrReceiverDisplayObserved.IsEmpty OrElse Not ucrSaveGraph.IsComplete) Then
            ucrBase.OKEnabled(False)
        Else
            ucrBase.OKEnabled(True)
        End If
    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRcodeForControls(True)
        TestOkEnabled()
    End Sub

    Private Sub ucrPnlOptions_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrPnlOptions.ControlValueChanged, ucrPnlMethods.ControlValueChanged, ucrInputComboType.ControlValueChanged
        If rdoDisplay.Checked OrElse rdoShow.Checked Then
            ucrBase.clsRsyntax.SetBaseRFunction(clsVisualizeElementNa)
            ucrBase.clsRsyntax.iCallType = 3
            Me.Size = New System.Drawing.Size(Me.Width, iDialogHeight * 0.72)
            ucrBase.Location = New Point(ucrBase.Location.X, iBaseMaxY / 1.5)
            ucrReceiverDisplayObserved.SetMeAsReceiver()
            If rdoDisplay.Checked Then
                Select Case ucrInputComboType.GetText
                    Case "Distribution"
                        ucrChkAddLegend.Visible = False
                        clsVisualizeElementNa.AddParameter("type", Chr(34) & "distribution" & Chr(34), iPosition:=8)
                    Case "Gap size"
                        ucrChkAddLegend.Visible = True
                        clsVisualizeElementNa.AddParameter("type", Chr(34) & "gapsize" & Chr(34), iPosition:=8)
                    Case "Intervals"
                        ucrChkAddLegend.Visible = True
                        clsVisualizeElementNa.AddParameter("type", Chr(34) & "interval" & Chr(34), iPosition:=8)
                End Select
            ElseIf rdoShow.Checked Then
                ucrChkAddLegend.Visible = True
                clsVisualizeElementNa.AddParameter("type", Chr(34) & "imputation" & Chr(34), iPosition:=8)
            End If
            cmdDisplayOptions.Visible = True
        ElseIf rdoFitSingle.Checked Then
            ucrChkAddLegend.Visible = False
            cmdDisplayOptions.Visible = False
            Me.Size = New System.Drawing.Size(Me.Width, iDialogHeight)
            ucrBase.Location = New Point(ucrBase.Location.X, iBaseMaxY)
            ucrReceiverElement.SetMeAsReceiver()
            ucrBase.clsRsyntax.iCallType = 0
            If rdoNaAggregate.Checked Then
                ucrBase.clsRsyntax.SetBaseRFunction(clsAggregateFunction)
            Else
                ucrBase.clsRsyntax.SetBaseRFunction(clsAveFunction)
            End If
        ElseIf rdoFitMultiple.Checked Then
            ucrChkAddLegend.Visible = False
            cmdDisplayOptions.Visible = False
            ucrBase.clsRsyntax.SetBaseRFunction(clsPatchClimateElementFunction)
            ucrBase.clsRsyntax.iCallType = 2
            Me.Size = New System.Drawing.Size(Me.Width, iDialogHeight * 0.8)
            ucrBase.Location = New Point(ucrBase.Location.X, iBaseMaxY / 1.32)
            ucrReceiverObserved.SetMeAsReceiver()
        End If
    End Sub

    Private Sub ucrReceiverObserved_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrReceiverObserved.ControlValueChanged
        If Not ucrReceiverObserved.IsEmpty Then
            ucrInputNewColumnName.SetName(ucrReceiverObserved.GetVariableNames(False) & "_Infilled")
        End If
    End Sub

    Private Sub ucrReceiverStation_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrReceiverStation.ControlValueChanged
        If Not ucrReceiverStation.IsEmpty Then
            clsVisualizeElementNa.AddParameter("station_col_name", ucrReceiverStation.GetVariableNames(), iPosition:=3)
        Else
            clsVisualizeElementNa.RemoveParameterByName("station_col_name")
        End If
    End Sub

    Private Sub ucrSelectorInfillMissing_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrSelectorInfillMissing.ControlValueChanged
        clsVisualizeElementNa.AddParameter("data_name", Chr(34) & ucrSelectorInfillMissing.ucrAvailableDataFrames.strCurrDataFrame & Chr(34), iPosition:=0)
    End Sub

    Private Sub ucrReceiverStation_ControlContentsChanged(ucrChangedControl As ucrCore) Handles ucrReceiverStation.ControlContentsChanged, ucrPnlOptions.ControlContentsChanged
        If (rdoDisplay.Checked OrElse rdoShow.Checked) AndAlso Not ucrReceiverStation.IsEmpty Then
            ucrNudFacetColumns.Visible = True
            lblFacetColumns.Visible = True
        Else
            ucrNudFacetColumns.Visible = False
            lblFacetColumns.Visible = False
        End If
    End Sub

    Private Sub ucrReceiverElement_ControlContentsChanged(ucrChangedControl As ucrCore) Handles ucrReceiverElement.ControlContentsChanged, ucrSaveNewColumn.ControlContentsChanged, ucrPnlStartEnd.ControlContentsChanged, ucrInputConstant.ControlContentsChanged, ucrPnlMethods.ControlContentsChanged, ucrPnlOptions.ControlContentsChanged, ucrReceiverDate.ControlContentsChanged, ucrReceiverObserved.ControlContentsChanged, ucrReceiverEstimatedElements.ControlContentsChanged, ucrChkMeanBias.ControlContentsChanged, ucrInputMeanBias.ControlContentsChanged, ucrChkStdBias.ControlContentsChanged, ucrInputStdBias.ControlContentsChanged, ucrInputNewColumnName.ControlContentsChanged, ucrReceiverImputed.ControlContentsChanged, ucrReceiverDisplayShowDate.ControlContentsChanged, ucrReceiverDisplayObserved.ControlContentsChanged, ucrSaveGraph.ControlContentsChanged
        TestOkEnabled()
    End Sub
End Class