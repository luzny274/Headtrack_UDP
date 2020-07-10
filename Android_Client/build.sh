#!/bin/bash
set -e

currentFolder="$( cd "$( dirname "${BASH_SOURCE[0]}" )" >/dev/null 2>&1 && pwd )"

#https://gist.github.com/authmane512/a5ca42da6f506350392e6a3ee2c97a90#file-build-sh

. project.settings
. Compilers/compilers.settings

javaFolder=src/com/kircherelectronics/fsensor

javaFolder2=src/"$package_1"/"$package_2"/"$appName"
rjavaFolder=src/"$package_1"/"$package_2"/"$appName"

rjavaFolder2=src/com/kircherelectronics/fsensor

resFolder="res"
resFolder2="fsensor/src/main/res"
androidManifest="AndroidManifest.xml"

echo "Cleaning..."

rm -rf obj/*
rm -rf $rjavaFolder/R.java

echo "Generating R.java files..."
$AAPT package -f -m -J src -M $androidManifest -S $resFolder -I $PLATFORM

$AAPT package -f -m -J src -M fsensor/src/main/AndroidManifest.xml -S $resFolder2 -I $PLATFORM

echo "Compiling..."

$JAVAC -d obj -classpath src -bootclasspath $PLATFORM -source 1.7 -target 1.7 -cp fsensor/libs/commons-math3-3.6.1.jar $(find ./$javaFolder/* | grep .java) $javaFolder2/*

$JAVAC -d obj -classpath src -bootclasspath $PLATFORM -source 1.7 -target 1.7 $rjavaFolder/R.java
$JAVAC -d obj -classpath src -bootclasspath $PLATFORM -source 1.7 -target 1.7 $rjavaFolder2/R.java

echo "Translating to Dalvik bytecode..."
$DX --dex --output=classes.dex obj fsensor/libs/commons-math3-3.6.1.jar

echo "Making APK..."
$AAPT package -f -m -F bin/$appName.apk -M $androidManifest -S $resFolder -I $PLATFORM

$AAPT add bin/$appName.apk classes.dex

echo "Aligning and signing APK..."

echo 123456 | $APKSIGNER sign --ks Keystore/key.jks bin/$appName.apk
$ZIPALIGN -f 4 bin/$appName.apk bin/$appName-release.apk



