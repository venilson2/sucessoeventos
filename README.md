# Sucesso Eventos

## Configuração do Banco de Dados

Antes de executar o projeto, certifique-se de configurar a conexão com o banco de dados no arquivo `appsettings.json`, conforme abaixo:

```json
"DefaultConnection": "server=SEU_SERVIDOR;database=SUA_DATABASE;user=SEU_USUARIO;password=SUA_SENHA;TrustServerCertificate=True"
```
## Executando Localmente

- Executando as Migrações
```
 dotnet ef database update
```

- Restaurando as Dependências
```
 dotnet restore
```

- Rodando o projeto
```
 dotnet watch run
```
- iniciará o servidor local.
```
 http://localhost:5149
```

## Executando com Docker 

> Observação: Ao executar com o docker ele executará as migrations automaticamente, apenas se atente a configuração do arquivo  ```appsettings.json``` 

- execute o comando:
```
docker compose up --build
```

- iniciará o servidor local.
```
 http://localhost:5149
```
