$ErrorActionPreference = 'Stop'

Push-Location "$PSScriptRoot/../Ctor.Database.Migrations"
try {
    dotnet ef --startup-project ../Ctor.Server migrations remove
} finally {
    Pop-Location
}
