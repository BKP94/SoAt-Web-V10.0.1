$root = $PSScriptRoot

Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd '$root\backend\SoAt.API'; dotnet run --launch-profile http"
