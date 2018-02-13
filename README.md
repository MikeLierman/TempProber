# TempProber
A small little application that pulls temps using Open Hardware Monitor and spits out info through console and returns proper exit code, for use on RMM dashboards with checks. (Eg. Solarwinds RMM Daily Safety Checks.)

### How it Works
Most RMM solutions only allow you to upload scripts, not full .exe files. Jump into the READY folder. You will see 3 files. TempProber.exe, ohm.dll, and a batch file. 

1. Upload TempProber.exe and ohm.dll to your web server.
2. Edit the batch file and point the URL to yours.
3. If you want to test it out, open Admin CMD, cd to the directory of the batch file. Run it. It will download from your server and place the two binaries in a folder called IT (or name it how you please) on the root of the C Drive. From then on, any time the batch script is called from your RMMs 24x7 or Daily Safety Checks, it will check to make sure the binaries exist, if they do, it will execute them and log the temperature. 

### Important Notes
* Exit codes are properly coded into TempProber.exe. If it fails to pull from the sensors, the check WILL NOT fail, but you will be able to click the More Info link next to the check to see what happened.
* Temperature is in farenheight for now. I have a list of known bugs and planned features below.
* I'd suggest checking back here every now and then for bug fixes, as I have not incorporated any updating mechanism.

### Known Bugs
* Open Hardware Monitor master branch itself has issues with some CPUs and will not display the correct temperature. You will be able to tell if the CPU temp is not supported on that machine because the temp will read something ridiculous like 40 degrees farenheight. Otherwise, temps are very accurate.

### Planned Features
* Some way to incorporate updates of the binary file. I have a few ideas, on how I could make this work. For now, subscribe to this github and download updated buils manually.

