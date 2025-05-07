# Build aşaması
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["WEB_TEST.csproj", "."]
RUN dotnet restore "WEB_TEST.csproj"
COPY . .
RUN dotnet build "WEB_TEST.csproj" -c Release -o /app/build

# Publish aşaması
FROM build AS publish
RUN dotnet publish "WEB_TEST.csproj" -c Release -o /app/publish \
    --no-self-contained \
    /p:UseAppHost=false \
    /p:GenerateRuntimeConfigurationFiles=true \
    /p:ErrorOnDuplicatePublishOutputFiles=true

# Runtime aşaması
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Huawei Cloud CAE için gerekli ayarlar
ENV ASPNETCORE_URLS=http://+:8080
ENV DOTNET_RUNNING_IN_CONTAINER=true

# Hem 8080 hem de 80 portunu expose et
EXPOSE 80
EXPOSE 8080

ENTRYPOINT ["dotnet", "WEB_TEST.dll"]
