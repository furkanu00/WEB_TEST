# Build aşaması
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY WEB_TEST.csproj ./WEB_TEST/
WORKDIR /src/WEB_TEST
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o /app/out

# Runtime aşaması
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
EXPOSE 8080
EXPOSE 80
ENTRYPOINT ["dotnet", "WEB_TEST.dll"]
