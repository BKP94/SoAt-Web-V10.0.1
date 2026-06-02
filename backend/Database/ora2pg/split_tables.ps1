# split_tables.ps1
# Splits ora2pg output.sql into one file per table.
#
# Output files:
#   _header.sql           — global SET / CREATE EXTENSION lines (runs first — _ sorts before a-z)
#   <tablename>.sql       — one per table (CREATE TABLE + indexes + NOT NULL)
#   z_fk_constraints.sql  — all ALTER TABLE ... ADD CONSTRAINT ... FOREIGN KEY (runs last)
#
# Run from the repo root:
#   powershell -File backend/Database/ora2pg/split_tables.ps1

param(
    [string]$InputFile = "$PSScriptRoot\..\Tables\output.sql",
    [string]$OutputDir = "$PSScriptRoot\..\Tables"
)

$input  = Resolve-Path $InputFile
$outDir = Resolve-Path $OutputDir
$lines  = [System.IO.File]::ReadAllLines($input, [System.Text.Encoding]::UTF8)

$headerBuf = [System.Text.StringBuilder]::new()
$tableBuf  = [System.Text.StringBuilder]::new()
$fkBuf     = [System.Text.StringBuilder]::new()
$curTable  = $null
$tableCount = 0

# Start of a table (or sequence) definition
$tableRx = [regex]'^(?:CREATE|DROP)\s+(?:UNLOGGED\s+)?(?:FOREIGN\s+)?(?:TABLE|SEQUENCE)\s+(?:IF\s+(?:NOT\s+)?EXISTS\s+)?["\[]?(\w+)'
# FK constraint (goes to z_fk_constraints.sql)
$fkRx    = [regex]'^ALTER\s+TABLE\s+\S+\s+ADD\s+CONSTRAINT\s+\S+\s+FOREIGN\s+KEY'

function WriteFile ([string]$path, [System.Text.StringBuilder]$buf) {
    if ($buf.Length -gt 0) {
        [System.IO.File]::WriteAllText($path, $buf.ToString(), [System.Text.Encoding]::UTF8)
    }
}

function FlushTable {
    if ($script:curTable -and $script:tableBuf.Length -gt 0) {
        WriteFile (Join-Path $outDir "$($script:curTable).sql") $script:tableBuf
        $script:tableCount++
        $script:tableBuf.Clear() | Out-Null
        $script:curTable = $null
    }
}

foreach ($line in $lines) {
    # FK constraint line → fk buffer
    if ($fkRx.IsMatch($line)) {
        FlushTable
        $fkBuf.AppendLine($line) | Out-Null
        continue
    }

    $m = $tableRx.Match($line)
    if ($m.Success) {
        FlushTable
        $script:curTable = $m.Groups[1].Value.ToLower()
        $script:tableBuf.AppendLine($line) | Out-Null
    }
    elseif ($curTable) {
        $tableBuf.AppendLine($line) | Out-Null
    }
    else {
        # Before first table — global header
        $headerBuf.AppendLine($line) | Out-Null
    }
}
FlushTable  # flush last table

# Write output files
if ($headerBuf.Length -gt 0) {
    WriteFile (Join-Path $outDir "_header.sql") $headerBuf
    Write-Host "_header.sql written"
}
if ($fkBuf.Length -gt 0) {
    WriteFile (Join-Path $outDir "z_fk_constraints.sql") $fkBuf
    Write-Host "z_fk_constraints.sql written"
}

Write-Host "Split complete: $tableCount table files written to $outDir"
