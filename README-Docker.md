# 🐳 Configuração Docker - Hackathon Monolito

Este documento descreve como configurar e executar o projeto Hackathon Monolito usando Docker.

## 📋 Pré-requisitos

- Docker Desktop instalado e rodando
- Docker Compose (incluído no Docker Desktop)
- Acesso ao banco de dados SQL Server remoto

## 🚀 Execução Rápida

### Opção 1: Script Automatizado
```bash
./docker-build.sh
```

### Opção 2: Comandos Manuais
```bash
# Build da imagem
docker compose build

# Executar containers
docker compose up -d

# Ver logs
docker compose logs -f hackathonmonolito
```

## ⚙️ Configuração

### Variáveis de Ambiente

Edite o arquivo `docker.env` para configurar as variáveis de ambiente:

```env
# Configurações da Aplicação
ASPNETCORE_ENVIRONMENT=Production
ASPNETCORE_URLS=http://+:8080;https://+:8081

# Connection Strings
ConnectionStrings__ProdutosDb=Server=SEU_SERVIDOR,1433;Database=hack;User ID=SEU_USUARIO;Password=SUA_SENHA;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True;Connection Timeout=30;
ConnectionStrings__LocalDb=Data Source=./data/hack.db

# Configurações de Log
Logging__LogLevel__Default=Information
Logging__LogLevel__Microsoft.AspNetCore=Warning
```

### Configuração do Banco de Dados

⚠️ **Importante**: Como o SQL Server é um banco remoto, certifique-se de:

1. **Ajustar a connection string** no arquivo `docker.env` com os dados corretos do seu banco
2. **Verificar conectividade** com o banco remoto
3. **Configurar firewall/redes** se necessário para permitir conexão

## 🌐 Endpoints Disponíveis

Após a execução, a aplicação estará disponível em:

- **Aplicação**: http://localhost:8080
- **Swagger/API Docs**: http://localhost:8080/swagger
- **Health Check**: http://localhost:8080/health

## 📊 Comandos Úteis

```bash
# Ver status dos containers
docker compose ps

# Ver logs em tempo real
docker compose logs -f hackathonmonolito

# Parar containers
docker compose down

# Parar e remover volumes
docker compose down -v

# Rebuild da imagem
docker compose build --no-cache

# Executar em modo foreground (ver logs)
docker compose up
```

## 🔧 Troubleshooting

### Problema: Container não inicia
```bash
# Verificar logs detalhados
docker compose logs hackathonmonolito

# Verificar se a porta está disponível
netstat -tulpn | grep 8080
```

### Problema: Erro de conexão com banco
1. Verifique se a connection string está correta no `docker.env`
2. Teste a conectividade com o banco remoto
3. Verifique se o banco está acessível da rede onde o Docker está rodando

### Problema: Health check falha
```bash
# Verificar se a aplicação está respondendo
curl http://localhost:8080/health

# Verificar logs da aplicação
docker compose logs hackathonmonolito
```

## 🏗️ Estrutura do Docker

### Dockerfile Otimizado
- **Multi-stage build** para reduzir tamanho da imagem
- **Alpine Linux** para menor footprint
- **Usuário não-root** para segurança
- **Health check** integrado
- **Cache otimizado** para builds mais rápidos

### Docker Compose
- **Rede isolada** para comunicação entre containers
- **Volumes persistentes** para dados da aplicação
- **Health checks** para monitoramento
- **Restart policy** para alta disponibilidade

## 🔒 Segurança

- Usuário não-root no container
- Imagem base Alpine Linux (menor superfície de ataque)
- Variáveis de ambiente para configurações sensíveis
- Health checks para monitoramento

## 📈 Monitoramento

A aplicação inclui:
- **Health check endpoint**: `/health`
- **Logs estruturados** via ASP.NET Core
- **Métricas básicas** de status da aplicação

## 🚀 Deploy em Produção

Para deploy em produção:

1. Ajuste as variáveis de ambiente no `docker.env`
2. Configure secrets management adequado
3. Use um registry de imagens (Docker Hub, Azure Container Registry, etc.)
4. Configure load balancer se necessário
5. Configure monitoramento e alertas

## 📞 Suporte

Em caso de problemas:
1. Verifique os logs: `docker compose logs hackathonmonolito`
2. Teste a conectividade com o banco
3. Verifique as configurações no `docker.env`
4. Consulte a documentação do ASP.NET Core 