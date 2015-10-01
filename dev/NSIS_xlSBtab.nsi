# --------------------------------------------------------------------------
#
# Install xlSBtab, the excel adding to SBtab. for more information 
# please see http://sbtab.net. 
#
# Frank T. Bergmann (September, 2015)
# --------------------------------------------------------------------------

!define PRODUCT_NAME "xlSBtab"
!define PRODUCT_VERSION "1.3"
!define PRODUCT_PUBLISHER "Frank T. Bergmann"
!define PRODUCT_WEB_SITE "https://github.com/fbergmann/xlSBtab"
!define PRODUCT_DIR_REGKEY "Software\Microsoft\Windows\CurrentVersion\App Paths\xlSBtab.vsto"
!define PRODUCT_UNINST_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"
!define PRODUCT_UNINST_ROOT_KEY "HKLM"

; MUI 1.67 compatible ------
!include "MUI.nsh"

; MUI Settings
!define MUI_ABORTWARNING
!define MUI_ICON "${NSISDIR}\Contrib\Graphics\Icons\modern-install.ico"
!define MUI_UNICON "${NSISDIR}\Contrib\Graphics\Icons\modern-uninstall.ico"

; Welcome page
!insertmacro MUI_PAGE_WELCOME
; Directory page
!insertmacro MUI_PAGE_DIRECTORY
; Instfiles page
!insertmacro MUI_PAGE_INSTFILES
; Finish page
!insertmacro MUI_PAGE_FINISH

; Uninstaller pages
!insertmacro MUI_UNPAGE_INSTFILES

; Language files
!insertmacro MUI_LANGUAGE "English"

; MUI end ------

Name "${PRODUCT_NAME} ${PRODUCT_VERSION}"
OutFile "Setup_${PRODUCT_NAME}_${PRODUCT_VERSION}.exe"
InstallDir "$PROGRAMFILES\xlSBtab"
InstallDirRegKey HKLM "${PRODUCT_DIR_REGKEY}" ""
ShowInstDetails hide
ShowUnInstDetails hide

# --------------------------------------------------------------------------
#
# Install plugin 
#
# --------------------------------------------------------------------------
Section "MainSection" SEC01
  DeleteRegKey HKLM "Software\xlSBtab"
  WriteRegStr HKLM "Software\xlSBtab" "Location" "$OUTDIR\"

	#install the excel plugin 
  SetOutPath "$INSTDIR"
  SetOverwrite ifnewer
  File "default_config.xml"
  File "..\xlSBtab\bin\Release\Microsoft.Office.Tools.Common.v4.0.Utilities.dll"
  File "..\xlSBtab\bin\Release\Microsoft.Office.Tools.Common.v4.0.Utilities.xml"
  File "..\xlSBtab\bin\Release\xlSBtab.dll"
  File "..\xlSBtab\bin\Release\xlSBtab.dll.manifest"
  File "..\xlSBtab\bin\Release\xlSBtab.pdb"
  File "..\xlSBtab\bin\Release\xlSBtab.vsto"
  
  
  # Replace dir in default_config.xml
  Push @InstDir@                        #text to be replaced
  Push $INSTDIR                         #replace with
  Push all                              #replace all occurrences
  Push all                              #replace all occurrences
  Push $INSTDIR\default_config.xml      #file to replace in
  Call AdvReplaceInFile                 #call find and replace function

  ; Register plugin twice, once for 64bit and then for 32bit ...
  SetRegView 64
  WriteRegStr HKLM "Software\Microsoft\Office\Excel\Addins\xlSBtab" "Description" "xlSBtab"
  WriteRegStr HKLM "Software\Microsoft\Office\Excel\Addins\xlSBtab" "FriendlyName" "xlSBtab"
  WriteRegStr HKLM "Software\Microsoft\Office\Excel\Addins\xlSBtab" "Manifest" "file:///$INSTDIR\xlSBtab.vsto|vstolocal"
  WriteRegDWORD HKLM "Software\Microsoft\Office\Excel\Addins\xlSBtab" "LoadBehavior" 3
  
  SetRegView 32
  WriteRegStr HKLM "Software\Microsoft\Office\Excel\Addins\xlSBtab" "Description" "xlSBtab"
  WriteRegStr HKLM "Software\Microsoft\Office\Excel\Addins\xlSBtab" "FriendlyName" "xlSBtab"
  WriteRegStr HKLM "Software\Microsoft\Office\Excel\Addins\xlSBtab" "Manifest" "file:///$INSTDIR\xlSBtab.vsto|vstolocal"
  WriteRegDWORD HKLM "Software\Microsoft\Office\Excel\Addins\xlSBtab" "LoadBehavior" 3

SectionEnd

# --------------------------------------------------------------------------
#
# Install Python
#
# --------------------------------------------------------------------------
!include "NSIS_python.nsh"

# --------------------------------------------------------------------------
#
# Install SBtab
#
# --------------------------------------------------------------------------
!include "NSIS_sbtab_final2.nsh"

Section -Post
  WriteUninstaller "$INSTDIR\uninst.exe"
  WriteRegStr HKLM "${PRODUCT_DIR_REGKEY}" "" "$INSTDIR\xlSBtab.vsto"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayName" "$(^Name)"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "UninstallString" "$INSTDIR\uninst.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayIcon" "$INSTDIR\xlSBtab.vsto"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayVersion" "${PRODUCT_VERSION}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "URLInfoAbout" "${PRODUCT_WEB_SITE}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "Publisher" "${PRODUCT_PUBLISHER}"
SectionEnd

Function un.onUninstSuccess
  HideWindow
  MessageBox MB_ICONINFORMATION|MB_OK "$(^Name) was successfully removed from your computer."
FunctionEnd

Function un.onInit
  MessageBox MB_ICONQUESTION|MB_YESNO|MB_DEFBUTTON2 "Are you sure you want to completely remove $(^Name) and all of its components?" IDYES +2
  Abort
FunctionEnd

Section Uninstall
  # Delete Keys
  DeleteRegKey ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}"
  DeleteRegKey HKLM "${PRODUCT_DIR_REGKEY}"

  # remove entries from 64 and 32bit registry
  SetRegView 64
  DeleteRegKey  HKLM "Software\xlSBtab"
  DeleteRegKey  HKLM "Software\Microsoft\Office\Excel\Addins\xlSBtab"
  SetRegView 32
  DeleteRegKey  HKLM "Software\xlSBtab"
  DeleteRegKey  HKLM "Software\Microsoft\Office\Excel\Addins\xlSBtab"



  # delete files
  Delete "$INSTDIR\uninst.exe"
  Delete "$INSTDIR\xlSBtab.vsto"
  Delete "$INSTDIR\xlSBtab.pdb"
  Delete "$INSTDIR\xlSBtab.dll.manifest"
  Delete "$INSTDIR\xlSBtab.dll"
  Delete "$INSTDIR\Microsoft.Office.Tools.Common.v4.0.Utilities.xml"
  Delete "$INSTDIR\Microsoft.Office.Tools.Common.v4.0.Utilities.dll"
  Delete "$INSTDIR\default_config.xml"

  # delete directories
  RMDir "$INSTDIR"
  
  #delete additional dirs
  

  SetAutoClose true
SectionEnd


Function AdvReplaceInFile

         ; call stack frame:
         ;   0 (Top Of Stack) file to replace in
         ;   1 number to replace after (all is valid)
         ;   2 replace and onwards (all is valid)
         ;   3 replace with
         ;   4 to replace

         ; save work registers and retrieve function parameters
         Exch $0 ;file to replace in
         Exch 4
         Exch $4 ;to replace
         Exch
         Exch $1 ;number to replace after
         Exch 3
         Exch $3 ;replace with
         Exch 2
         Exch $2 ;replace and onwards
         Exch 2
         Exch
         Push $5 ;minus count
         Push $6 ;universal
         Push $7 ;end string
         Push $8 ;left string
         Push $9 ;right string
         Push $R0 ;file1
         Push $R1 ;file2
         Push $R2 ;read
         Push $R3 ;universal
         Push $R4 ;count (onwards)
         Push $R5 ;count (after)
         Push $R6 ;temp file name
         GetTempFileName $R6
         FileOpen $R1 $0 r ;file to search in
         FileOpen $R0 $R6 w ;temp file
                  StrLen $R3 $4
                  StrCpy $R4 -1
                  StrCpy $R5 -1
        loop_read:
         ClearErrors
         FileRead $R1 $R2 ;read line
         IfErrors exit
         StrCpy $5 0
         StrCpy $7 $R2

        loop_filter:
         IntOp $5 $5 - 1
         StrCpy $6 $7 $R3 $5 ;search
         StrCmp $6 "" file_write2
         StrCmp $6 $4 0 loop_filter

         StrCpy $8 $7 $5 ;left part
         IntOp $6 $5 + $R3
         StrCpy $9 $7 "" $6 ;right part
         StrCpy $7 $8$3$9 ;re-join

         IntOp $R4 $R4 + 1
         StrCmp $2 all file_write1
         StrCmp $R4 $2 0 file_write2
         IntOp $R4 $R4 - 1

         IntOp $R5 $R5 + 1
         StrCmp $1 all file_write1
         StrCmp $R5 $1 0 file_write1
         IntOp $R5 $R5 - 1
         Goto file_write2

        file_write1:
         FileWrite $R0 $7 ;write modified line
         Goto loop_read

        file_write2:
         FileWrite $R0 $R2 ;write unmodified line
         Goto loop_read

        exit:
         FileClose $R0
         FileClose $R1

         SetDetailsPrint none
         Delete $0
         Rename $R6 $0
         Delete $R6
         SetDetailsPrint both

         Pop $R6
         Pop $R5
         Pop $R4
         Pop $R3
         Pop $R2
         Pop $R1
         Pop $R0
         Pop $9
         Pop $8
         Pop $7
         Pop $6
         Pop $5
         Pop $4
         Pop $3
         Pop $2
         Pop $1
         Pop $0
FunctionEnd
