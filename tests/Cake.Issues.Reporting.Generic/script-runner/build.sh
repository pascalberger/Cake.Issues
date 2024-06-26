#!/bin/bash
SCRIPT_NAME="build.cake"

echo "Restoring .NET Core tools"
dotnet tool restore

echo "Bootstrapping Cake"
dotnet cake $SCRIPT_NAME --bootstrap

echo "Running Build"
dotnet cake $SCRIPT_NAME --settings_skippackageversioncheck=true "$@"