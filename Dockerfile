FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app


COPY *.sln .
COPY absa.phonebook.api/*csproj ./absa.phonebook.api/
COPY absa.phonebook.api.test/*csproj ./absa.phonebook.api.test/
RUN dotnet restore

COPY . .
WORKDIR /app/absa.phonebook.api
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/absa.phonebook.api/out ./
ENTRYPOINT ["dotnet", "absa.phonebook.api.dll"]
