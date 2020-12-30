;#DropDB AmaraProject.WasteManagerEasyTest

#Application AmaraProject.WasteManagerWin
#Application AmaraProject.WasteManagerWeb

*FillForm
 User Name = Admin
*Action Log In

#IfDef AmaraProject.WasteManagerWin

*Action About...
 
*Action OK

#EndIf

#IfDef AmaraProject.WasteManagerWeb
*Action Navigation(My Details)
#EndIf
