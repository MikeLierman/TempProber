@echo off
if exist "C:\IT\TempProber.exe" (
    cd "C:\IT"
    TempProber.exe
) else (
    powershell -Command "(New-Object Net.WebClient).DownloadFile('https://YOURSERVER.NET/dl/TempProber/TempProber.exe', 'TempProber.exe')"

    powershell -Command "(New-Object Net.WebClient).DownloadFile('https://YOURSERVER.NET/dl/TempProber/ohm.dll', 'ohm.dll')"
    
    md "C:\IT" > null
    move TempProber.exe "C:\IT\TempProber.exe" /y > null
    move ohm.dll "C:\IT\ohm.dll" /y > null
    cd "C:\IT"
    TempProber.exe
)