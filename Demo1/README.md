# Demo 1 - Utilizando um container tomcat

Lista de comandos a serem executados

Faz download de uma imagem docker de Tomcat para o Docker Host
```bash
docker pull tomcat
```

Lista as imagens disponíveis no docker host
```bash
docker images
```

Executa o Container com a imagem de Tomcat publicando a porta do Host 8080 com o container 8080
```bash
docker run -d -p 8080:8080 tomcat
```

Acesse a url para acessar o seu container Tomcat
[Tomcat Localhost](http://localhost:8080)
