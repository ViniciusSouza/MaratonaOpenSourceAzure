#Docker Compose

É comum em uma arquitetura de microservice ter mais de um container para compor uma aplicação ou serviço.

O Docker possui uma ferramenta muito poderosa para ajudar na tarefa de trabalhar com os diferentes containers que vão compor o nosso serviço.

Para ilustrar a utilização do compose vamos utilizar duas aplicação web, sendo que uma delas é um aspnet core mvc e a outra um aspnet core webapi.

As aplicações foram criadas inicialmente utilizando o comando dotnet new

Criando o projeto web(mvc) a partir do dotnet new ajuda na criação de um serviço web mvc. 
```bash
mkdir web
cd web
dotnet new mvc --auth None --framework netcoreapp1.1
```

Foram adicionadas pequenas alterações no projeto web (mvc) para utilizar o serviço webapi, simulando assim uma dependência entre os dois projetos.

Criando o projeto web(mvc) a partir do dotnet new ajuda na criação de um serviço web api. 
```bash
mkdir webapi
cd webapi
dotnet new webapi --framework netcoreapp1.1
```

Cada um dos projetos possui o seu dockerfile, que será utilizado durante o processe do build do docker-compose.

docker-compose.yml ou docker-compose.yaml

É o arquivo de definição do serviços e de seus componentes, podemos utilizar uma imagem diretamente ou o dockerfile utilizado em cada serviço.

```docker-compose
version:  '2'

services: 
  web:
    
    build: 
      context: ./web
    environment: 
      - ImageApiUri=http://localhost:8080/api/image
    ports: 
      - "5000:80"
    depends_on: 
      - imageapi
  imageapi:
    build: 
      context: ./webapi
    ports: 
      - "8080:80"
``` 

Para executar o docker-compose vamos primeiro criar as imagens.

```bash
docker-compose build
```

Em seguida vamos executar todos os container utilizando o seguinte comando
```bash
docker-compose up
```


