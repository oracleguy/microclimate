.PHONY: test build
run:
	dotnet run --project src/ClimateApi/ClimateApi.csproj
build:
	dotnet build
test:
	dotnet test
clean:
	dotnet clean
publish:
	dotnet publish