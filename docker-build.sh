#!/bin/bash

# Script para build e execução do Hackathon Monolito
set -e

echo "🚀 Iniciando build e execução do Hackathon Monolito..."

# Verificar se o Docker está rodando
if ! docker info > /dev/null 2>&1; then
    echo "❌ Docker não está rodando. Por favor, inicie o Docker e tente novamente."
    exit 1
fi

# Build da imagem
echo "📦 Fazendo build da imagem..."
docker compose build --no-cache

# Executar os containers
echo "🏃 Executando containers..."
docker compose up -d

# Aguardar um pouco para a aplicação inicializar
echo "⏳ Aguardando inicialização da aplicação..."
sleep 10

# Verificar status dos containers
echo "📊 Status dos containers:"
docker compose ps

# Verificar logs
echo "📋 Logs da aplicação:"
docker compose logs hackathonmonolito

echo "✅ Aplicação está rodando!"
echo "🌐 Acesse: http://localhost:8080"
echo "📚 Swagger: http://localhost:8080/swagger"
echo "💚 Health Check: http://localhost:8080/health"
echo ""
echo "Para parar a aplicação: docker compose down"
echo "Para ver logs: docker compose logs -f hackathonmonolito" 