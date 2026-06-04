$root = $PSScriptRoot

# scCenter (host: login + landing + DB deploy) — http://localhost:5100
Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd '$root\scCenter'; dotnet run --launch-profile http"

# scTeller (module) — http://localhost:5110
Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd '$root\scTeller'; dotnet run --launch-profile http"
