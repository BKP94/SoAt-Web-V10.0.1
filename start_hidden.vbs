Dim sh
Set sh = CreateObject("WScript.Shell")

' Stop: kill process ที่ใช้ port เดิมก่อน
sh.Run "cmd /c taskkill /F /IM ""SoAt.API.exe"" >nul 2>&1", 0, True
sh.Run "cmd /c for /f ""tokens=5"" %a in ('netstat -aon ^| findstr :5139') do taskkill /F /PID %a >nul 2>&1", 0, True

' Start: รัน backend
sh.Run "cmd /c cd /d C:\Project_SoAt\SoAt_WebApp\backend\SoAt.API && dotnet run --launch-profile http", 0, False
