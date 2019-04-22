# Run the tests and collate code coverage results
#dotnet test -c Release --no-build --no-restore Domain/SharedKernel/Dibware.Salon.Domain.SharedKernel.UnitTests/Dibware.Salon.Domain.SharedKernel.UnitTests.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=../lcov
dotnet test -c Release --no-build --no-restore Domain/SharedKernel/Dibware.Salon.Domain.SharedKernel.UnitTests/Dibware.Salon.Domain.SharedKernel.UnitTests.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
