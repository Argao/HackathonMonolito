# Multi-stage build para otimizar o tamanho da imagem
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Instalar curl para healthcheck
RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*

# Criar usuário não-root para segurança
RUN groupadd -g 1001 appgroup && \
    useradd -u 1001 -g appgroup -s /bin/bash appuser

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar arquivos de projeto primeiro para aproveitar cache do Docker
COPY ["HackathonMonolito/HackathonMonolito.csproj", "HackathonMonolito/"]
RUN dotnet restore "HackathonMonolito/HackathonMonolito.csproj"

# Copiar o resto dos arquivos
COPY . .
WORKDIR "/src/HackathonMonolito"

# Build da aplicação
ARG BUILD_CONFIGURATION=Release
RUN dotnet build "HackathonMonolito.csproj" -c $BUILD_CONFIGURATION -o /app/build --no-restore

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "HackathonMonolito.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false --no-restore

FROM base AS final
WORKDIR /app

# Gerar certificado auto-assinado para HTTPS
RUN openssl req -x509 -newkey rsa:4096 -keyout key.pem -out cert.pem -days 365 -nodes \
    -subj "/C=BR/ST=SP/L=Sao Paulo/O=Hackathon/CN=localhost" && \
    chmod 644 cert.pem && \
    chmod 600 key.pem && \
    chown appuser:appgroup cert.pem key.pem

# Copiar aplicação publicada
COPY --from=publish /app/publish .

# Mudar para usuário não-root
USER appuser

# Configurar variáveis de ambiente padrão
ENV ASPNETCORE_URLS=http://+:8080;https://+:8081
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/app/cert.pem
ENV ASPNETCORE_Kestrel__Certificates__Default__KeyPath=/app/key.pem

# Healthcheck
HEALTHCHECK --interval=30s --timeout=10s --start-period=40s --retries=3 \
    CMD curl -f -k https://localhost:8081/health || curl -f http://localhost:8080/health || exit 1

ENTRYPOINT ["dotnet", "HackathonMonolito.dll"]
