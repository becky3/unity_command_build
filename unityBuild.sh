#!/bin/bash

UNITY_APP_PATH=/Applications/Unity/Unity.app/Contents/MacOS/Unity
UNITY_PROJECT_PATH=./
UNITY_BUILDE_NAME=Builder.Build
UNITY_LOG_PATH=./build/android/build.log

$UNITY_APP_PATH -batchmode \
    -quit \
    -projectPath $UNITY_PROJECT_PATH \
    -executeMethod $UNITY_BUILDE_NAME \
    -logfile $UNITY_LOG_PATH \
    -platform Android \
    -isRelease false

if [ $? -eq 1 ]; then
    echo "error!! check logfile: ${UNITY_LOG_PATH}"
    exit 1
fi
echo "success!!"
exit 0
