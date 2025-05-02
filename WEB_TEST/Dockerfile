# .NET 8.0 Runtime (base image)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080  # Huawei CAE varsayılan portu

# .NET 8.0 SDK (build image)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["HuaweiCAEDemo.csproj", "."]
RUN dotnet restore "HuaweiCAEDemo.csproj"
COPY . .
RUN dotnet build "HuaweiCAEDemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HuaweiCAEDemo.csproj" -c Release -o /app/publish --self-contained false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# Huawei Cloud CAE için port ayarı
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "HuaweiCAEDemo.dll"]