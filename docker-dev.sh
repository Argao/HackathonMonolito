#!/bin/bash

# Script para desenvolvimento do Hackathon Monolito
set -e

echo "🔧 Iniciando ambiente de desenvolvimento..."

# Verificar se o Docker está rodando
if ! docker info > /dev/null 2>&1; then
    echo "❌ Docker não está rodando. Por favor, inicie o Docker e tente novamente."
    exit 1
fi

# Build da imagem de desenvolvimento
echo "📦 Fazendo build da imagem de desenvolvimento..."
docker compose -f compose.dev.yaml build --no-cache

# Executar os containers
echo "🏃 Executando containers em modo desenvolvimento..."
docker compose -f compose.dev.yaml up -d

# Aguardar um pouco para a aplicação inicializar
echo "⏳ Aguardando inicialização da aplicação..."
sleep 10

# Verificar status dos containers
echo "📊 Status dos containers:"
docker compose -f compose.dev.yaml ps

# Verificar logs
echo "📋 Logs da aplicação:"
docker compose -f compose.dev.yaml logs hackathonmonolito

echo "✅ Ambiente de desenvolvimento está rodando!"
echo "🌐 Acesse: http://localhost:8080"
echo "📚 Swagger: http://localhost:8080/swagger"
echo "💚 Health Check: http://localhost:8080/health"
echo ""
echo "Para parar a aplicação: docker compose -f compose.dev.yaml down"
echo "Para ver logs: docker compose -f compose.dev.yaml logs -f hackathonmonolito"
echo "Para rebuild: docker compose -f compose.dev.yaml build --no-cache" 