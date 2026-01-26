Write-Host " Starting SonarQube Local Scan..." -ForegroundColor Cyan

# =============================
# CONFIGURATION
# =============================
$ProjectRoot = "D:\works\developments\learn\dotnet\explore-dotnet-repository-pattern"
$CsprojPath  = "src\explore-pattern.Api\explore-pattern.Api.csproj"
$SonarKey    = "explore-dotnet-repository-pattern"
$SonarName   = "explore-dotnet-repository-pattern"
$SonarVer    = "1.0"
$SonarUrl    = "http://localhost:9000"
$SonarToken  = "sqp_7d19b600431296d66afe5c04a44a02d7843a3e58"
$Container   = "sonarqube"

# =============================
# STEP 1: Ensure Docker Running
# =============================
Write-Host "Checking Docker..." -ForegroundColor Yellow
docker info > $null 2>&1
if ($LASTEXITCODE -ne 0) {
    Write-Error "❌ Docker Desktop belum running. Jalankan Docker Desktop dulu."
    exit 1
}

# =============================
# STEP 2: Start SonarQube
# =============================
Write-Host "Starting SonarQube container..." -ForegroundColor Yellow
docker start $Container > $null 2>&1

Write-Host " Waiting SonarQube to be ready (30s)..." -ForegroundColor Gray
Start-Sleep -Seconds 30

# =============================
# STEP 3: Go to Project Root
# =============================
Set-Location $ProjectRoot

# =============================
# STEP 4: Sonar BEGIN
# =============================
Write-Host "SonarScanner BEGIN" -ForegroundColor Green
dotnet sonarscanner begin `
 /k:"$SonarKey" `
 /n:"$SonarName" `
 /v:"$SonarVer" `
 /d:sonar.host.url="$SonarUrl" `
 /d:sonar.login="$SonarToken" `
 /d:sonar.projectBaseDir="$ProjectRoot"

if ($LASTEXITCODE -ne 0) {
    Write-Error "❌ SonarScanner BEGIN failed"
    exit 1
}

# =============================
# STEP 5: BUILD
# =============================
Write-Host "Building project..." -ForegroundColor Green
dotnet build $CsprojPath

if ($LASTEXITCODE -ne 0) {
    Write-Error "❌ Build failed"
    exit 1
}

# =============================
# STEP 6: Sonar END
# =============================
Write-Host "SonarScanner END" -ForegroundColor Green
dotnet sonarscanner end `
 /d:sonar.login="$SonarToken"

if ($LASTEXITCODE -ne 0) {
    Write-Error "❌ SonarScanner END failed"
    exit 1
}

Write-Host "SonarQube Scan completed successfully!" -ForegroundColor Cyan
Write-Host "Open SonarQube Dashboard: http://localhost:9000/dashboard?id=$SonarKey"

