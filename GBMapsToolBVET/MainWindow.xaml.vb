Imports System
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports System.Windows.Controls
Imports System.Threading
Imports System.Xml
Imports System.Diagnostics
Imports System.ComponentModel

Class MainWindow
    Friend bvedir, gbIdir, currDir As String
    Friend newData As Boolean
    Friend saved As Boolean

    Public Enum filetype
        x = 0
        img = 1
        wav = 2
    End Enum

    Private Sub buttonBrowseBVEDataDir_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseBVEDataDir.Click
        Dim FolderDialog As New FolderBrowserDialog
        With FolderDialog
            .RootFolder = Environment.SpecialFolder.MyComputer
            .ShowNewFolderButton = True
        End With
        If FolderDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            textBoxBVEdataDir.Text = FolderDialog.SelectedPath
            bvedir = FolderDialog.SelectedPath
        End If
    End Sub

    Private Sub buttonGBImageDir_Click(sender As Object, e As RoutedEventArgs) Handles buttonGBImageDir.Click
        Dim FolderDialog As New FolderBrowserDialog
        With FolderDialog
            .RootFolder = Environment.SpecialFolder.MyComputer
            .ShowNewFolderButton = True
        End With
        If FolderDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            textBoxGBimgDir.Text = FolderDialog.SelectedPath
            gbIdir = FolderDialog.SelectedPath
        End If
    End Sub

    Private Sub buttonBrowseRailSleeper1_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseRailSleeper1.Click
        UpdateXFileField(textBoxRailSleeper1, filetype.x)
    End Sub

    Private Sub buttonBrowseRailLeft1_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseRailLeft1.Click
        UpdateXFileField(textRailLeft1, filetype.x)
    End Sub

    Private Sub buttonBrowseRailRight1_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseRailRight1.Click
        UpdateXFileField(textRailRight1, filetype.x)
    End Sub

    Private Sub buttonBrowseRailSleeper2_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseRailSleeper2.Click
        UpdateXFileField(textBoxRailSleeper2, filetype.x)
    End Sub

    Private Sub buttonBrowseRailLeft2_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseRailLeft2.Click
        UpdateXFileField(textRailLeft2, filetype.x)
    End Sub

    Private Sub buttonBrowseRailRight2_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseRailRight2.Click
        UpdateXFileField(textRailRight2, filetype.x)
    End Sub

    Private Sub buttonBrowseRailSleeper3_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseRailSleeper3.Click
        UpdateXFileField(textBoxRailSleeper3, filetype.x)
    End Sub

    Private Sub buttonBrowseRailLeft3_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseRailLeft3.Click
        UpdateXFileField(textRailLeft3, filetype.x)
    End Sub

    Private Sub buttonBrowseRailRight3_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseRailRight3.Click
        UpdateXFileField(textRailRight3, filetype.x)
    End Sub

    Private Sub buttonBrowseRailSleeper4_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseRailSleeper4.Click
        UpdateXFileField(textBoxRailSleeper4, filetype.x)
    End Sub

    Private Sub buttonBrowseRailLeft4_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseRailLeft4.Click
        UpdateXFileField(textRailLeft4, filetype.x)
    End Sub

    Private Sub buttonBrowseRailRight4_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseRailRight4.Click
        UpdateXFileField(textRailRight4, filetype.x)
    End Sub

    Private Sub buttonBrowseRailSleeper5_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseRailSleeper5.Click
        UpdateXFileField(textBoxRailSleeper5, filetype.x)
    End Sub

    Private Sub buttonBrowseRailLeft5_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseRailLeft5.Click
        UpdateXFileField(textRailLeft5, filetype.x)
    End Sub

    Private Sub buttonBrowseRailRight5_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseRailRight5.Click
        UpdateXFileField(textRailRight5, filetype.x)
    End Sub

    Private Sub buttonBrowseRailImage_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseRailImage.Click
        UpdateXFileField(textBoxRailImage, filetype.img)
    End Sub

    Private Sub buttonBrowsePoleStructure_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowsePoleStructure.Click
        UpdateXFileField(textBoxPoleStructure, filetype.x)
    End Sub

    Private Sub buttonBrowseOverHeadWire_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseOverHeadWire.Click
        UpdateXFileField(textBoxOverHeadWire, filetype.x)
    End Sub

    Private Sub buttonBrowseSound_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseSound.Click
        UpdateXFileField(textBoxSoundFile, filetype.wav)
    End Sub

    Private Sub buttonGenControlXMLTxt_Click(sender As Object, e As RoutedEventArgs) Handles buttonGenControlXMLTxt.Click
        Dim count = 0

        For Each tb As System.Windows.Controls.Label In FindVisualChildren(Of System.Windows.Controls.Label)(GBToolsMain)
            count += 1
        Next

        MessageBox.Show(count)
    End Sub

    Private Sub buttonBrowseTunnelEntranceFile_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseTunnelEntranceFile.Click
        UpdateXFileField(textBoxTunnelEntranceFile, filetype.x)
    End Sub

    Private Sub buttonBrowseTunnelWallLeft_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseTunnelWallLeft.Click
        UpdateXFileField(textBoxTunnelWallLeft, filetype.x)
    End Sub

    Private Sub buttonBrowseTunnelWallRight_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseTunnelWallRight.Click
        UpdateXFileField(textBoxTunnelWallRight, filetype.x)
    End Sub

    Private Sub buttonBrowseTunnelExitStructure_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseTunnelExitStructure.Click
        UpdateXFileField(textBoxTunnelExitStructure, filetype.x)
    End Sub

    Private Sub buttonBrowseBridgeLeft_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseBridgeLeft.Click
        UpdateXFileField(textBoxBridgeLeft, filetype.x)
    End Sub

    Private Sub buttonBrowseBridgeRight_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseBridgeRight.Click
        UpdateXFileField(textBoxBridgeRight, filetype.x)
    End Sub

    Private Sub buttonBrowseBridgePier_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseBridgePier.Click
        UpdateXFileField(textBoxBridgePier, filetype.x)
    End Sub

    Private Sub buttonBrowseOverPassWallLeft_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseOverPassWallLeft.Click
        UpdateXFileField(textBoxOverPassWallLeft, filetype.x)
    End Sub

    Private Sub buttonBrowseOverPassWallRight_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseOverPassWallRight.Click
        UpdateXFileField(textBoxOverPassWallRight, filetype.x)
    End Sub

    Private Sub buttonBrowseOverPassPier_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseOverPassPier.Click
        UpdateXFileField(textBoxOverPassPier, filetype.x)
    End Sub

    Private Sub buttonBrowseHillCutLeft_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseHillCutLeft.Click
        UpdateXFileField(textBoxHillCutLeft, filetype.x)
    End Sub

    Private Sub buttonBrowseHillCutRight_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseHillCutRight.Click
        UpdateXFileField(textBoxHillCutRight, filetype.x)
    End Sub

    Private Sub buttonBrowseDikeLeft_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseDikeLeft.Click
        UpdateXFileField(textBoxDikeLeft, filetype.x)
    End Sub

    Private Sub buttonBrowseDikeRight_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseDikeRight.Click
        UpdateXFileField(textBoxDikeRight, filetype.x)
    End Sub

    Private Sub buttonBrowseRCgateLeft_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseRCgateLeft.Click
        UpdateXFileField(textBoxRCgateLeft, filetype.x)
    End Sub

    Private Sub buttonBrowseRCIntersection_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseRCIntersection.Click
        UpdateXFileField(textBoxRCIntersection, filetype.x)
    End Sub

    Private Sub buttonBrowseRCgateRight_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseRCgateRight.Click
        UpdateXFileField(textBoxRCgateRight, filetype.x)
    End Sub

    Private Sub buttonBrowseRCSound_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseRCSound.Click
        UpdateXFileField(textBoxRCSound, filetype.wav)
    End Sub

    Private Sub buttonBrowsePlatformLeft_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowsePlatformLeft.Click
        UpdateXFileField(textBoxPlatformLeft, filetype.x)
    End Sub

    Private Sub buttonBrowsePlatformMiddleLeft_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowsePlatformMiddleLeft.Click
        UpdateXFileField(textBoxPlatformMiddleLeft, filetype.x)
    End Sub

    Private Sub buttonBrowsePlatformMiddleRight_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowsePlatformMiddleRight.Click
        UpdateXFileField(textBoxPlatformMiddleRight, filetype.x)
    End Sub

    Private Sub buttonbrowsePlatformRight_Click(sender As Object, e As RoutedEventArgs) Handles buttonbrowsePlatformRight.Click
        UpdateXFileField(textBoxPlatformRight, filetype.x)
    End Sub

    Private Sub buttonBrowsePlatformRoofLeft_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowsePlatformRoofLeft.Click
        UpdateXFileField(textBoxPlatformRoofLeft, filetype.x)
    End Sub

    Private Sub buttonBrowsePlatformRoofMiddleLeft_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowsePlatformRoofMiddleLeft.Click
        UpdateXFileField(textBoxPlatformRoofMiddleLeft, filetype.x)
    End Sub

    Private Sub buttonBrowsePlatformRoofMiddleRight_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowsePlatformRoofMiddleRight.Click
        UpdateXFileField(textBoxPlatformRoofMiddleRight, filetype.x)
    End Sub

    Private Sub buttonBrowsermRoofRight_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowsermRoofRight.Click
        UpdateXFileField(textBoxPlatformRoofRight, filetype.x)
    End Sub

    Private Sub buttonBrowseCrackLeft_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseCrackLeft.Click
        UpdateXFileField(textBoxCrackLeft, filetype.x)
    End Sub

    Private Sub buttonBrowseCrackRight_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseCrackRight.Click
        UpdateXFileField(textBoxCrackRight, filetype.x)
    End Sub

    Private Sub buttonBrowseUGGroundLeft_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseUGGroundLeft.Click
        UpdateXFileField(textBoxUGGroundLeft, filetype.x)
    End Sub

    Private Sub buttonBrowseUGGroundRight_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseUGGroundRight.Click
        UpdateXFileField(textBoxUGGroundRight, filetype.x)
    End Sub

    Private Sub buttonBrowseUGWallLeft_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseUGWallLeft.Click
        UpdateXFileField(textBoxUGWallLeft, filetype.x)
    End Sub

    Private Sub buttonBrowseUGWallRight_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseUGWallRight.Click
        UpdateXFileField(textBoxUGWallRight, filetype.x)
    End Sub

    Private Sub buttonBrowseUGEntrance_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseUGEntrance.Click
        UpdateXFileField(textBoxUGEntrance, filetype.x)
    End Sub

    Private Sub buttonBrowseUGWallLeft1_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseUGWallLeft1.Click
        UpdateXFileField(textBoxUGWallLeft1, filetype.x)
    End Sub

    Private Sub buttonBrowseUGWallRight1_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseUGWallRight1.Click
        UpdateXFileField(textBoxUGWallRight1, filetype.x)
    End Sub

    Private Sub buttonBrowseUGExit_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseUGExit.Click
        UpdateXFileField(textBoxUGExit, filetype.x)
    End Sub

    Private Sub buttonBrowseFOfile_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseFOfile.Click
        UpdateXFileField(textBoxFOfile, filetype.x)
    End Sub

    Private Sub buttonBrowseEtc1Str_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseEtc1Str.Click
        UpdateXFileField(textBoxEtc1Str, filetype.x)
    End Sub

    Private Sub buttonBrowseEtcStrLeft_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseEtcStrLeft.Click
        UpdateXFileField(textBoxEtcStrLeft, filetype.x)
    End Sub

    Private Sub buttonBrowseEtcStrRight_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseEtcStrRight.Click
        UpdateXFileField(textBoxEtcStrRight, filetype.x)
    End Sub

    Private Sub buttonBrowseUGImage_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseUGImage.Click
        UpdateXFileField(textBoxUGImage, filetype.img)
    End Sub

    Public Shared Function FindVisualChildren(Of T As DependencyObject)(depObj As DependencyObject) As IEnumerable(Of T)
        If depObj IsNot Nothing Then
            For i As Integer = 0 To VisualTreeHelper.GetChildrenCount(depObj) - 1
                Dim child As DependencyObject = VisualTreeHelper.GetChild(depObj, i)
                If child IsNot Nothing AndAlso TypeOf child Is T Then
                    Return DirectCast(child, T)
                End If

                For Each childOfChild As T In FindVisualChildren(Of T)(child)
                    Return childOfChild
                Next
            Next
        End If
        Return Nothing
    End Function

    Public Sub UpdateXFileField(TB As Windows.Controls.TextBox, file As filetype)
        Dim FileDialog As New OpenFileDialog
        With FileDialog
            .AddExtension = True
            .CheckFileExists = True
            .CheckPathExists = True
            If IO.Directory.Exists(currDir) Then .InitialDirectory = currDir
            .Multiselect = False
            .CheckFileExists = True
            .CheckPathExists = True
            .DereferenceLinks = True
            Select Case file
                Case filetype.x
                    .Filter = "DirectX 3D object|*.x"
                Case filetype.img
                    .Filter = "Image Files (*.gif, *.jpg, *.png)|*.gif;*.jpg;*.png"
                Case filetype.wav
                    .Filter = "Sound Files|*.wav"
                Case Else
                    .Filter = "All files|*.*"
            End Select

        End With
        If FileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            Select Case file
                Case filetype.x
                    TB.Text = FileDialog.FileName.ToLower.Replace(bvedir.ToLower & "\", "")
                Case filetype.img
                    TB.Text = FileDialog.FileName.ToLower.Replace(gbIdir.ToLower & "\", "")
                Case filetype.wav
                    Dim filename = "sounds\" & My.Computer.FileSystem.GetFileInfo(FileDialog.FileName).Name
                    TB.Text = filename
                Case Else
                    TB.Text = FileDialog.FileName.ToLower.Replace(bvedir.ToLower & "\", "")
            End Select

            currDir = My.Computer.FileSystem.GetParentPath(FileDialog.FileName)
        End If
    End Sub

    Private Sub buttonBrowseTunnelImage_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseTunnelImage.Click
        UpdateXFileField(textBoxTunnelImage, filetype.img)
    End Sub

    Private Sub buttonBrowseTrainFolder_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseTrainFolder.Click
        Dim FolderDialog As New FolderBrowserDialog
        With FolderDialog
            .RootFolder = Environment.SpecialFolder.MyComputer
            .ShowNewFolderButton = True
        End With
        If FolderDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            textBoxRunTrainsfolder.Text = FolderDialog.SelectedPath
        End If
    End Sub

    Private Sub buttonBrowseRCImage_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseRCImage.Click
        UpdateXFileField(textBoxRCImage, filetype.img)
    End Sub

    Private Sub buttonBrowsePoleImage_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowsePoleImage.Click
        UpdateXFileField(textBoxPoleImage, filetype.img)
    End Sub

    Private Sub buttonBrowsePlatformImage_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowsePlatformImage.Click
        UpdateXFileField(textBoxPlatformImage, filetype.img)
    End Sub

    Private Sub buttonBrowseOverPassImage_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseOverPassImage.Click
        UpdateXFileField(textBoxOverPassImage, filetype.img)
    End Sub

    Private Sub buttonBrowseHillCutImage_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseHillCutImage.Click
        UpdateXFileField(textBoxHillCutImage, filetype.img)
    End Sub

    Private Sub buttonBrowseFOImage_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseFOImage.Click
        UpdateXFileField(textBoxFOImage, filetype.img)
    End Sub

    Private Sub buttonBrowseEtcImage_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseEtcImage.Click
        UpdateXFileField(textBoxEtcImage, filetype.img)
    End Sub

    Private Sub buttonBrowseDikeImage_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseDikeImage.Click
        UpdateXFileField(textBoxDikeImage, filetype.img)
    End Sub

    Private Sub buttonBrowseCrackImage_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseCrackImage.Click
        UpdateXFileField(textBoxCrackImage, filetype.img)
    End Sub

    Private Sub buttonBrowseBridgeImage_Click(sender As Object, e As RoutedEventArgs) Handles buttonBrowseBridgeImage.Click
        UpdateXFileField(textBoxBridgeImage, filetype.img)
    End Sub

    Private Sub buttonNewRail_Click(sender As Object, e As RoutedEventArgs) Handles buttonNewRail.Click

    End Sub

    Private Sub buttonAddNewUG_Click(sender As Object, e As RoutedEventArgs) Handles buttonAddNewUG.Click

    End Sub

    Private Sub buttonAddNewTunnel_Click(sender As Object, e As RoutedEventArgs) Handles buttonAddNewTunnel.Click

    End Sub

    Private Sub buttonAddNewSound_Click(sender As Object, e As RoutedEventArgs) Handles buttonAddNewSound.Click

    End Sub

    Private Sub buttonAddNewRC_Click(sender As Object, e As RoutedEventArgs) Handles buttonAddNewRC.Click

    End Sub

    Private Sub buttonAddNewPole_Click(sender As Object, e As RoutedEventArgs) Handles buttonAddNewPole.Click

    End Sub

    Private Sub buttonAddNewPlatform_Click(sender As Object, e As RoutedEventArgs) Handles buttonAddNewPlatform.Click

    End Sub

    Private Sub buttonAddNewOverpass_Click(sender As Object, e As RoutedEventArgs) Handles buttonAddNewOverpass.Click

    End Sub

    Private Sub buttonAddNewHillCut_Click(sender As Object, e As RoutedEventArgs) Handles buttonAddNewHillCut.Click

    End Sub

    Private Sub buttonAddNewFO_Click(sender As Object, e As RoutedEventArgs) Handles buttonAddNewFO.Click

    End Sub

    Private Sub buttonAddNewEtc_Click(sender As Object, e As RoutedEventArgs) Handles buttonAddNewEtc.Click

    End Sub

    Private Sub buttonAddNewDike_Click(sender As Object, e As RoutedEventArgs) Handles buttonAddNewDike.Click

    End Sub

    Private Sub buttonAddNewCrack_Click(sender As Object, e As RoutedEventArgs) Handles buttonAddNewCrack.Click

    End Sub

    Private Sub buttonAddNewBridge_Click(sender As Object, e As RoutedEventArgs) Handles buttonAddNewBridge.Click

    End Sub

    Private Sub buttonOpenXML_Click(sender As Object, e As RoutedEventArgs) Handles buttonOpenXML.Click

    End Sub

    Private Sub buttonNewXML_Click(sender As Object, e As RoutedEventArgs) Handles buttonNewXML.Click
        dataGridRail.Items.Clear()
        dataGridPoles.Items.Clear()
        dataGridRunningTrain.Items.Clear()
        dataGridSoundFiles.Items.Clear()
        dataGridTunnel.Items.Clear()
        dataGridBridge.Items.Clear()
        dataGridOverpass.Items.Clear()
        dataGridHillCut.Items.Clear()
        dataGridDike.Items.Clear()
        dataGridRC.Items.Clear()
        dataGridPlatform.Items.Clear()
        dataGridCrack.Items.Clear()
        dataGridUG.Items.Clear()
        dataGridFO.Items.Clear()
        dataGridEtc.Items.Clear()
    End Sub

    Private Sub buttonSaveXML_Click(sender As Object, e As RoutedEventArgs) Handles buttonSaveXML.Click

    End Sub

    Private Sub buttonGenJS_Click(sender As Object, e As RoutedEventArgs) Handles buttonGenJS.Click

    End Sub
End Class
