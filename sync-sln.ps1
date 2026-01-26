param(
    [string]$SlnxPath = "explore-pattern.slnx",
    [string]$OutputSln = "explore-pattern.sln"
)

Write-Host "Reading $SlnxPath"

if (!(Test-Path $SlnxPath)) {
    Write-Error "❌ SLNX file not found"
    exit 1
}

# Parse SLNX (JSON)
$json = Get-Content $SlnxPath -Raw | ConvertFrom-Json

$projects = $json.solution.projects.path

if (!$projects -or $projects.Count -eq 0) {
    Write-Error "❌ No projects found in slnx"
    exit 1
}

Write-Host "Found projects:"
$projects | ForEach-Object { Write-Host " - $_" }

# Create empty .sln (legacy)
if (Test-Path $OutputSln) {
    Remove-Item $OutputSln -Force
}

Write-Host "Creating empty solution: $OutputSln"

dotnet new sln --name temp --output . | Out-Null
Rename-Item "temp.sln" $OutputSln -Force
Remove-Item "temp.slnx" -Force -ErrorAction SilentlyContinue

# Add projects
foreach ($proj in $projects) {
    Write-Host "Adding $proj"
    dotnet sln $OutputSln add $proj
}

Write-Host ""
Write-Host "✅ Solution sync completed successfully"
Write-Host "Generated solution: $OutputSln"
