# stop-dev.ps1 — หยุด dev server ของ project นี้ (คู่กับ start-dev.ps1)
# หยุดเฉพาะ process ที่ listen อยู่บน port 5100 (scCenter) / 5110 (scTeller)
# ไม่แตะ dotnet ตัวอื่น (เช่นที่รันใน Visual Studio บน port อื่น)

foreach ($port in 5100, 5110) {
    $procId = (Get-NetTCPConnection -LocalPort $port -State Listen -ErrorAction SilentlyContinue).OwningProcess
    if ($procId) {
        $name = (Get-Process -Id $procId -ErrorAction SilentlyContinue).ProcessName
        Stop-Process -Id $procId -Force -ErrorAction SilentlyContinue
        Write-Host "stopped :$port  (PID $procId  $name)"
    }
    else {
        Write-Host "no listener on :$port"
    }
}
