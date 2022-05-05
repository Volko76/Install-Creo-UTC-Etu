MsgBox(1, "Installation de Créo v4.0 étudiant UTC", "Attention, ce programme automatise une partie de l'installation de Creo : (Le téléchargement, l'extraction, la suppression des anciennes clées et versions de Créo, le lancement du programme d'installation et la création des variables d'environnement)")

Local Const $sFilePath = "C:\ProgramData\PTC\Licensing"
Local Const $link = "https://download.utc.fr/index.php/download/creo-v4-0/?wpdmdl=11"
Local $ZipFolder = "MED-100WIN-CD-410_M040_Win64.zip"
Local $UnzippedFolder = "UnzippedFolder"
If FileExists($UnzippedFolder) Then
		DirRemove($UnzippedFolder, 1)
EndIf
Local $download = InetGet($link, @ScriptDir & $ZipFolder)
MsgBox(1, "te", $download)
_ExtractZip(@ScriptDir & $ZipFolder, $UnzippedFolder)
MsgBox(1, "test", "test")
If Not(FileExists($sFilePath)) Then
		DirRemove($sFilePath, 1)
EndIf
EnvSet("PTC_PMA_HC_URL_4", "https://documentations.utc.fr/creodoc/Creo4.0/help/creo_help_pma/")
Run(@ScriptDir & $UnzippedFolder & "\" & "setup.exe", "", @SW_MINIMIZE)

Func _ExtractZip($sZipFile, $sDestinationFolder, $sFolderStructure = "")

    Local $i
    Do
        $i += 1
        $sTempZipFolder = @TempDir & "\Temporary Directory " & $i & " for " & StringRegExpReplace($sZipFile, ".*\\", "")
    Until Not FileExists($sTempZipFolder) ; this folder will be created during extraction

    Local $oShell = ObjCreate("Shell.Application")

    If Not IsObj($oShell) Then
        Return SetError(1, 0, 0) ; highly unlikely but could happen
    EndIf

    Local $oDestinationFolder = $oShell.NameSpace($sDestinationFolder)
    If Not IsObj($oDestinationFolder) Then
        DirCreate($sDestinationFolder)
;~         Return SetError(2, 0, 0) ; unavailable destionation location
    EndIf

    Local $oOriginFolder = $oShell.NameSpace($sZipFile & "\" & $sFolderStructure) ; FolderStructure is overstatement because of the available depth
    If Not IsObj($oOriginFolder) Then
        Return SetError(3, 0, 0) ; unavailable location
    EndIf

    Local $oOriginFile = $oOriginFolder.Items();get all items
    If Not IsObj($oOriginFile) Then
        Return SetError(4, 0, 0) ; no such file in ZIP file
    EndIf

    ; copy content of origin to destination
    $oDestinationFolder.CopyHere($oOriginFile, 20) ; 20 means 4 and 16, replaces files if asked

    DirRemove($sTempZipFolder, 1) ; clean temp dir

    Return 1 ; All OK!

EndFunc