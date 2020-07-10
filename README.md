# Headtrack_UDP
Project consists of an Android app measuring rotation and sending it via UDP and a Windows program receiving rotation and emulating mouse movement.

## Android Client


### FSensor
Uses library [FSensor](https://github.com/KalebKE/FSensor).


### Using with [Opentrack](https://github.com/opentrack/opentrack)
Select input option "UDP over network" in Opentrack. 

Get PORT number by clicking on hammer. 

Get IP address by running "ipconfig" command in cmd.


### APK
Apk location: "Android_Client/bin/Headtrack_UDP.apk".


### Building
Put required file locations to "Android_Client/Compiler/compilers.settings" and run "build.sh".

Alternatively you can just start new project in Android studio and copy the code there (It's just two files in "Android_Client/src/com/mantegral/Headtrack_UDP/" and a library [FSensor](https://github.com/KalebKE/FSensor)).

![alt text](https://github.com/luzny274/Headtrack_UDP/raw/master/Android_Client/android_client_screenshot.jpg "Android_client")

## Windows mouse emulator
C# Visual Studio project, executable located in "Windows_MouseEmulation/bin".
