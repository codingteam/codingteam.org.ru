param (
    [string] $MigrationName
)

$ErrorActionPreference = 'Stop'

Push-Location "$PSScriptRoot/../Ctor.Database.Migrations"
try {
    dotnet ef --startup-project ../Ctor.Server migrations add $MigrationName
} finally {
    Pop-Location
}
