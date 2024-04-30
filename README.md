# Sucesso Eventos

## Rodadndo com Docker 

Para iniciar o projeto com Docker, execute o seguinte comando na raiz do projeto:

Antes de executar o projeto, certifique-se de configurar a conexão com o banco de dados no arquivo `appsettings.json`, conforme abaixo:

```json
"DefaultConnection": "server=sql_db;database=sucessoeventos;user=sa;password=Root@2024;TrustServerCertificate=True"
```

```
docker compose up --build
```

## Rodadndo 

### Configuração do Banco de Dados

Antes de executar o projeto, certifique-se de configurar a conexão com o banco de dados no arquivo `appsettings.json`, conforme abaixo:

```json
"DefaultConnection": "server=SEU_SERVIDOR;database=SUA_DATABASE;user=SEU_USUARIO;password=SUA_SENHA;TrustServerCertificate=True"
```

### Executando as Migrações

Para aplicar as migrações ao banco de dados, execute o seguinte comando no terminal:

```
 dotnet ef database update
```

### Restaurando as Dependências

Certifique-se de restaurar as dependências do projeto executando o comando:

```
 dotnet restore
```


### Rodando o projeto

Por fim, execute o projeto com o seguinte comando:

```
 dotnet watch run
```

Isso iniciará o servidor e você poderá acessar o seu projeto localmente.

```
 http://localhost:5149
```
