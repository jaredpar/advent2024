
param (
  [string]$day = ""
)

Set-StrictMode -version 2.0
$ErrorActionPreference="Stop"

function Create-Directory([string]$dir) {
  New-Item $dir -ItemType Directory -ErrorAction SilentlyContinue | Out-Null
}

if ($day -eq "") {
  Write-Host "Please provide a day number"
  exit 1
}

if ($day.Length -ne 2) {
  Write-Host "The day number must be two digits"
  exit 1
}

$rootDir = Split-Path -parent $PSScriptRoot
Push-Location $rootDir
try {
  $dayName = "Day$day"
  $dayDir = Join-Path $rootDir "src" $dayName
  Write-Host "Creating $dayDir"
  Create-Directory $dayDir

  # Create the README.md for the day
  $dayShortName = $day.TrimStart("0")
  $readmeContent = @"
# Advent Of Code 2024 Day $dayShortName

Solution for [Day $dayShortName](https://adventofcode.com/2024/day/$dayShortName)

"@
  New-Item (Join-Path $dayDir "README.md") -ItemType File -Value $readmeContent | Out-Null

  # Create the main project
  Write-Host "Creating the application"
  $appDir = Join-Path $dayDir "$($dayName).App"
  Create-Directory $appDir
  & dotnet new console -o $appDir -v m
  & dotnet sln add $appDir
  Move-Item (Join-Path $appDir "Program.cs") (Join-Path $appDir "$($dayName).cs")
  & dotnet add $appDir reference (Join-Path $rootDir "src\Advent.Util")

  # Create the unit test project
  Write-Host "Creating unit test project"
  $unitDir = Join-Path $dayDir "$($dayName).UnitTests"
  Create-Directory $unitDir
  & dotnet new classlib -o $unitDir -v m
  Move-Item (Join-Path $unitDir "Class1.cs") (Join-Path $appDir "$($dayName)Tests.cs")
  & dotnet sln add $unitDir
  $unitPackages = @(
    "Microsoft.NET.Test.Sdk",
    "xunit",
    "xunit.runner.visualstudio"
    "Xunit.Combinatorial"
  )
  foreach ($p in $unitPackages) {
    Write-Host "`tAdding package $p"
    & dotnet add $unitDir package $p | Out-Null
  }
  & dotnet add $unitDir reference $appDir
}
catch {
  Write-Host $_
  Write-Host $_.Exception
  Write-Host $_.ScriptStackTrace
  exit 1
}
finally {
  Pop-Location
}




