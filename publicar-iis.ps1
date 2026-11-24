# =============================================================
# Publica la API y el Front de ByteLab en carpetas para IIS
# Ejecutar en PowerShell desde la carpeta de la solución:
#     powershell -ExecutionPolicy Bypass -File .\publicar-iis.ps1
# =============================================================
$destino = "C:\inetpub\bytelab"

dotnet publish .\servicio_bytelab\servicio_bytelab.csproj -c Release -o "$destino\api"
dotnet publish .\front_bytelab\front_bytelab.csproj -c Release -o "$destino\web"

Write-Host ""
Write-Host "Listo. Ahora en IIS:" -ForegroundColor Green
Write-Host "  1. Sitio 'bytelab-api' -> carpeta $destino\api -> puerto 5210"
Write-Host "  2. Sitio 'bytelab-web' -> carpeta $destino\web -> puerto 8080"
Write-Host "  3. Grupo de aplicaciones de ambos: 'Sin código administrado'"
