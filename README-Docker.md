# Configuração Docker - Hackathon Monolito

## ✅ Status: Configurado e Testado

O projeto foi completamente configurado e testado com Docker, incluindo suporte a HTTPS com certificado auto-assinado.

## 🚀 Como Executar

### Ambiente de Desenvolvimento
```bash
# Build e execução
./docker-dev.sh

# Ou manualmente:
docker compose -f compose.dev.yaml build --no-cache
docker compose -f compose.dev.yaml up -d
```

### Ambiente de Produção
```bash
# Build e execução
./docker-build.sh

# Ou manualmente:
docker compose build --no-cache
docker compose up -d
```

## 🌐 Endpoints Disponíveis

### HTTP (Porta 8080)
- **Health Check**: `http://localhost:8080/health`
- **Swagger**: `http://localhost:8080/swagger`

### HTTPS (Porta 8081) - **Recomendado**
- **Health Check**: `https://localhost:8081/health`
- **Swagger**: `https://localhost:8081/swagger`
- **API Produtos**: `https://localhost:8081/produtos/selecionar?valor=10000&prazo=12`

## 🔧 Configurações Implementadas

### ✅ Connection Strings Corrigidas
- **SQL Server Remoto**: `dbhackathon.database.windows.net`
- **SQLite Local**: `./data/hack.db`
- Todas as configurações estão consistentes entre ambientes

### ✅ HTTPS Configurado
- Certificado auto-assinado gerado automaticamente
- Válido por 365 dias
- Suporte a HTTP/2
- Redirecionamento automático de HTTP para HTTPS

### ✅ Segurança
- Usuário não-root (`appuser`)
- Permissões adequadas para certificados
- Health checks configurados

### ✅ Imagem Base Otimizada
- Mudança de Alpine para Debian (resolve problema SQL Server)
- Multi-stage build para otimização
- Instalação de dependências necessárias

## 📊 Testes Realizados

### ✅ Health Check
```bash
curl -k https://localhost:8081/health
# Resposta: {"status":"healthy","timestamp":"...","version":"1.0.0"}
```

### ✅ API de Produtos
```bash
curl -k "https://localhost:8081/produtos/selecionar?valor=10000&prazo=12"
# Resposta: {"codigo":1,"descricao":"Produto 1",...}
```

### ✅ Conexão com Banco
- SQL Server remoto funcionando corretamente
- Consultas retornando dados válidos

## 🛠️ Comandos Úteis

### Verificar Status
```bash
docker compose ps
docker compose logs hackathonmonolito
```

### Parar Aplicação
```bash
docker compose down
```

### Rebuild
```bash
docker compose build --no-cache
```

### Acessar Container
```bash
docker compose exec hackathonmonolito bash
```

## 🔍 Troubleshooting

### Problema: "Globalization Invariant Mode is not supported"
**Solução**: Mudança de Alpine para Debian Linux (já implementada)

### Problema: Certificado SSL não confiável
**Solução**: Use `-k` flag no curl ou aceite o certificado auto-assinado

### Problema: Container reiniciando
**Solução**: Verifique logs com `docker compose logs hackathonmonolito`

## 📝 Arquivos de Configuração

- `compose.yaml` - Produção
- `compose.dev.yaml` - Desenvolvimento
- `docker.env` - Variáveis de ambiente
- `HackathonMonolito/Dockerfile` - Build da aplicação
- `.dockerignore` - Arquivos ignorados no build

## 🎯 Próximos Passos

1. **Certificado Real**: Substituir certificado auto-assinado por certificado válido
2. **Monitoramento**: Adicionar Prometheus/Grafana
3. **Logs**: Configurar ELK Stack
4. **CI/CD**: Pipeline de deploy automático 