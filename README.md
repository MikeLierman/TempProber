# TempProber

A small command line application that pulls temps of various hardware components using Open Hardware Monitor library API, and outputs info along with proper exit code, for use on RMM dashboards. (Eg. Solarwinds RMM, formally MAX Focus, but should be compatible with many others.) Supports only Windows based workstations and servers. Read below for more info.  Screenshot of what this script returns when using Solarwinds: https://i.imgur.com/q7IECBI.jpg

For update information and discussion, join the Invise Labs Discord: https://discord.gg/gK7NQ7h

### How it Works — READ FIRST BEFORE DOWNLOADING
Most RMM solutions only allow you to upload scripts, not .exe files. The pre-made Windows based scripts for monitoring and logging hardware temperatures have never worked for me. Not once. This is a solution that works, always, without fail. It's pretty dang cool to be able to see HW temps of the CPU, GPU, and HDD on each RMM connected machine, right from your dashboard. This info is even viewable using the RMM mobile app.

GETTING STARTED
1. Download the latest release (ready folder). https://github.com/MikeLierman/TempProber/releases. Inside you will see 3 files. TempProber.exe, ohm.dll, and a batch file. 
2. Upload TempProber.exe and ohm.dll to your web server. Services like Dropbox or Mega will not work because you do not have direct DL access.
3. Edit the batch file and point the URL to yours.
4. Test it. Move the batch file to an empty folder. Open Admin CMD, cd to batch file, and execute. Script will check if the TempProber.exe and ohm.dll binaries already exist, if they do, they are run, if not, they are downloaded. Default save/run directory is C:\IT. This can be changed.
5. TempProber.exe will check for temp sensors on each major hardware component and output the results. After which it returns an exit code used by your RMM dashboard to determine PASS or FAIL on the "check." If you've done everything correctly, in command prompt you will see temperatures of each component the script detected. If you do not see this, you messed up, go back to step 1.
6. After verifying that you understand how the script functions, go ahead and upload JUST THE BATCH FILE to your RMM dashboard script manager. Deploy it to several machines as a test before deploying to every connected agent.

### Download
https://github.com/MikeLierman/TempProber/releases

### Important Notes
* High temp alerts are set to 190F and above, this will trigger the check to fail using exit code -3.
* Checks fail through exit codes that are coded into TempProber.exe. However, if a temp sensor is not functioning, or TempProber simply doesn't work (rare scenario), the check will not fail. In the event that the script encounters an error, it will output the details so that you can recify the problem.
* Temperature is in fahrenheit for now. I have a list of known bugs and planned features below.
* I'd suggest checking back here every now and then for bug fixes, as I have not incorporated any updating mechanism.

### Known Bugs
* Open Hardware Monitor itself, and thus our library, has issues with some CPUs and will not display the correct temperature. You will be able to tell if the CPU temp is not supported on that PC because the temp will read something ridiculous like 40 degrees farenheight. Otherwise, temps are accurate.

### Planned Features
* Some way to incorporate auto updating. It's a consideration. Don't hold your breath. For now subscribe here on Github to receive new build notifcations, or join our Discord channel.
* Log temps over time and return average, min, and max to dashboard, instead of just a simple read out. 

### About Us
Check our site http://invi.se/labs for annoucements and other projects. We code scripts and programs to make our lives as IT Professionals easier. 

