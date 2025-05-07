# Build aşaması
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Proje dosyasını kopyala ve restore et
COPY ["WEB_TEST.csproj", "."]
RUN dotnet restore "WEB_TEST.csproj"

# Tüm dosyaları kopyala ve publish et (self-contained tek dosya olarak)
COPY . .
RUN dotnet publish "WEB_TEST.csproj" -c Release -o /app/publish \
    --self-contained true \
    -r linux-x64 \
    /p:PublishSingleFile=true \
    /p:PublishTrimmed=false \
    /p:IncludeNativeLibrariesForSelfExtract=true

# Runtime aşaması
FROM debian:bullseye-slim AS final

# Gerekli bağımlılıkları yükle (özellikle glibc ve libssl gibi runtime için gerekli olanlar)
RUN apt-get update && \
    apt-get install -y libicu67 libssl1.1 libkrb5-3 zlib1g && \
    rm -rf /var/lib/apt/lists/*

WORKDIR /app

# Publish edilmiş uygulamayı kopyala
COPY --from=build /app/publish ./

# Huawei Cloud CAE için gerekli ortam değişkenleri
ENV ASPNETCORE_URLS=http://+:8080
ENV DOTNET_RUNNING_IN_CONTAINER=true

# Portları aç
EXPOSE 80
EXPOSE 8080

# Uygulamanın adını buraya doğru yaz
ENTRYPOINT ["./WEB_TEST"]
