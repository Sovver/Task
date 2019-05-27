;#DropDB TaskEasyTest

#Application Task.Win
#Application Task.Web
#IfDef Task.Win

*Action About...
 
*Action OK

#EndIf

#IfDef Task.Web
!Action Navigation(My Details)
#EndIf
