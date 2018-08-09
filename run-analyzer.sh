#!/bin/sh

export sonar=4238241226b0fc3b5a38a238d68ef4f898f12cdb

dotnet-sonarscanner begin /k:"jw-analyzer" /d:sonar.host.url="http://localhost:9000" /d:sonar.login=$sonar
dotnet build tests/MyApp
dotnet-sonarscanner end /d:sonar.login=$sonar