# .NET 8.0 Runtime (base image)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080  # Huawei CAE varsayılan portu

# .NET 8.0 SDK (build image)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["WEB_TEST.csproj", "."]
RUN dotnet restore "WEB_TEST.csproj"
COPY . .
RUN dotnet build "WEB_TEST.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WEB_TEST.csproj" -c Release -o /app/publish --self-contained false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# Huawei Cloud CAE için port ayarı
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "WEB_TEST.dll"]