# TempProber
A small little application that pulls temps using the Open Hardware Monitor library API and spits out info through console and returns proper exit code, for use on RMM dashboards. (Eg. Solarwinds RMM, formally MAX Focus.)

For update information and discussion, join or Discord: https://discord.gg/gK7NQ7h

### How it Works
Most RMM solutions only allow you to upload scripts, not full .exe files. And the scripts that are out there for logging and monitoring temperatures, rely on WIM, which simply does not work. Ever. This is a solution that works, always, without fail. It's pretty dang cool to be able to see HW temps on each RMM connected machine. 

1. Download the READY folder. Inside you will see 3 files. TempProber.exe, ohm.dll, and a batch file. 
1. Upload TempProber.exe and ohm.dll to your web server. Services like DB or Mega will not work because you do not have direct DL access.
2. Edit the batch file and point the URL to yours.
3. Open Admin CMD, cd to batch file and run it. Script will check if the TempProber.exe and ohm.dll binaries already exist, if they do, they are run, if not, they are downloaded to a folder called IT which is placed in the root of C:\.
4. TempProber.exe returns temps of all hardware components through iteration. After which it returns an exit code used by your RMM dashboard to determine PASS or FAIL on the "check."

### Important Notes
* High temps are set to 190 and above, this will trigger the check to fail using exit code -3.
* Checks fail through exit codes that are coded into TempProber.exe. However, if a temp sensor is not functioning, or TempProber simply doesn't work (rare scenario), the check will not fail. If it fails, you will be able to see the error text, so that you can rectify the problem.
* Temperature is in farenheight for now. I have a list of known bugs and planned features below.
* I'd suggest checking back here every now and then for bug fixes, as I have not incorporated any updating mechanism.

### Known Bugs
* Open Hardware Monitor itself, and thus our library, has issues with some CPUs and will not display the correct temperature. You will be able to tell if the CPU temp is not supported on that PC because the temp will read something ridiculous like 40 degrees farenheight. Otherwise, temps are accurate.

### Planned Features
* Some way to incorporate auto updating. It's a consideration. Don't hold your breath. For now subscribe here on Github to receive new build notifcations, or join our Discord channel.
* Log temps over time and return average, min, and max to dashboard, instead of just a simple read out. 

### About Us
Check our site http://invi.se/labs for annoucements and other projects. We code scripts and programs to make our lives as IT Professionals easier. 

