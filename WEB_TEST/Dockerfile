# Build aşaması
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["WEB_TEST.csproj", "."]
RUN dotnet restore "WEB_TEST.csproj"

COPY . .
RUN dotnet publish "WEB_TEST.csproj" -c Release -r linux-x64 \
    -o /app/publish \
    --self-contained true \
    /p:PublishSingleFile=true \
    /p:IncludeNativeLibrariesForSelfExtract=true \
    /p:PublishTrimmed=false

# Runtime aşaması (artık dotnet runtime içermiyor, çünkü self-contained)
FROM debian:bullseye-slim AS final

# Native kütüphaneler (uygulama içerse bile bazıları sistemden gerekir)
RUN apt-get update && \
    apt-get install -y libicu67 libssl1.1 libkrb5-3 zlib1g && \
    rm -rf /var/lib/apt/lists/*

WORKDIR /app
COPY --from=build /app/publish ./

ENV ASPNETCORE_URLS=http://+:8080
ENV DOTNET_RUNNING_IN_CONTAINER=true

EXPOSE 80
EXPOSE 8080

ENTRYPOINT ["./WEB_TEST"]
