# replace_login_vars.ps1
# Global replace of Oracle session package variable references → PostgreSQL current_setting()
# Run from repo root after all ora2pg extractions are complete:
#   powershell -File backend/Database/ora2pg/replace_login_vars.ps1

param(
    [string]$DatabaseDir = "$PSScriptRoot\.."
)

$dir = Resolve-Path $DatabaseDir

# Replacement map: Oracle pattern → PostgreSQL equivalent
$replacements = @(
    # Login session variables from pka_com_login package
    @{ From = "pka_com_login.login_id";   To = "current_setting('app.login_id', true)" }
    @{ From = "pka_com_login.login_br";   To = "current_setting('app.login_br', true)" }
    @{ From = "pka_com_login.login_name"; To = "current_setting('app.login_name', true)" }
    @{ From = "pka_com_login.window_active"; To = "current_setting('app.window_active', true)" }
    # Finance date from pka_fin_daily (replaced by PostgreSQL function)
    @{ From = "pka_fin_daily.finance_date"; To = "fp_finance_date()" }
)

$sqlFiles = Get-ChildItem $dir -Filter "*.sql" -Recurse | Where-Object { $_.Name -ne 'output.sql' }
$totalFiles = $sqlFiles.Count
$changedFiles = 0

foreach ($file in $sqlFiles) {
    $content = [System.IO.File]::ReadAllText($file.FullName, [System.Text.Encoding]::UTF8)
    $original = $content

    foreach ($r in $replacements) {
        $content = $content -replace [regex]::Escape($r.From), $r.To
    }

    if ($content -ne $original) {
        [System.IO.File]::WriteAllText($file.FullName, $content, [System.Text.Encoding]::UTF8)
        $changedFiles++
        $rel = $file.FullName.Replace($dir.Path, '').TrimStart('\/')
        Write-Host "  Updated: $rel"
    }
}

Write-Host ""
Write-Host "Replace complete: $changedFiles / $totalFiles files updated"
