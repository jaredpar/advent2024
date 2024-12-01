
param (
  [string]$day = ""
)

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
  $day = "Day$day"
  $p = Join-Path $rootDir "src" $day
  $null = New-Item -ItemType Directory -Path $p
  & dotnet new console -n $day -o $p
  & dotnet sln add $p
}
finally {
  Pop-Location
}




