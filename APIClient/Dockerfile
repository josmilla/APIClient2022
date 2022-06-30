FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY *.csproj ./
RUN dotnet restore
# copy everything else and build app
COPY . ./
WORKDIR /source
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "APIClient.dll"]

# create a new build target called componenttestrunner
FROM build AS test
# navigate to the component test directory
WORKDIR ApiUnit.Test
# when you run this build target it will run the component tests
CMD ["dotnet", "test", "--logger:trx"]
