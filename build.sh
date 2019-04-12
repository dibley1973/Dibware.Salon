#!/usr/bin/env bash
dotnet restore
dotnet clean -c Release
dotnet build Dibware.Salon.sln -c Release