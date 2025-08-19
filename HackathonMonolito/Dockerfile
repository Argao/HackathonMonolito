# Multi-stage build para otimizar o tamanho da imagem
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Criar usuário não-root para segurança
RUN addgroup -g 1001 -S appgroup && \
    adduser -u 1001 -S appuser -G appgroup
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
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

# Instalar curl para healthcheck
USER root
RUN apk add --no-cache curl
USER appuser

# Copiar aplicação publicada
COPY --from=publish /app/publish .

# Configurar variáveis de ambiente padrão
ENV ASPNETCORE_URLS=http://+:8080;https://+:8081
ENV ASPNETCORE_ENVIRONMENT=Production

# Healthcheck
HEALTHCHECK --interval=30s --timeout=10s --start-period=40s --retries=3 \
    CMD curl -f http://localhost:8080/health || exit 1

ENTRYPOINT ["dotnet", "HackathonMonolito.dll"]
