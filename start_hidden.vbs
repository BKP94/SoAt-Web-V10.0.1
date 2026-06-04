Dim sh
Set sh = CreateObject("WScript.Shell")

' Stop: kill process ที่ใช้ port เดิมก่อน (scCenter 5100, scTeller 5110)
sh.Run "cmd /c for /f ""tokens=5"" %a in ('netstat -aon ^| findstr :5100') do taskkill /F /PID %a >nul 2>&1", 0, True
sh.Run "cmd /c for /f ""tokens=5"" %a in ('netstat -aon ^| findstr :5110') do taskkill /F /PID %a >nul 2>&1", 0, True

' Start: scCenter (host) + scTeller (module)
sh.Run "cmd /c cd /d C:\Project_SoAt\SoAt_WebApp\scCenter && dotnet run --launch-profile http", 0, False
sh.Run "cmd /c cd /d C:\Project_SoAt\SoAt_WebApp\scTeller && dotnet run --launch-profile http", 0, False
