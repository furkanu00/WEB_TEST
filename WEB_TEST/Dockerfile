# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project file first for better layer caching
COPY ["WEB_TEST.csproj", "."]
RUN dotnet restore "WEB_TEST.csproj"

# Copy everything else and build
COPY . .
RUN dotnet build "WEB_TEST.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "WEB_TEST.csproj" -c Release -o /app/publish \
    --no-self-contained \
    /p:UseAppHost=false \
    /p:GenerateRuntimeConfigurationFiles=true

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy published content
COPY --from=publish /app/publish .

# Huawei Cloud CAE specific settings
ENV ASPNETCORE_URLS=http://+:8080
ENV DOTNET_RUNNING_IN_CONTAINER=true
EXPOSE 8080

ENTRYPOINT ["dotnet", "WEB_TEST.dll"]