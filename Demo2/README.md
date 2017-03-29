#Demo 2 - Utilização de DockerFile para construir a sua Imagem

Nesse exemplo vou fazer o uso do container NGINX para um servidor de arquivos HTMl estáticos.

O DockerFile é a receita da nossa imagem de container.

```dockerfile
FROM nginx
WORKDIR app
COPY wwwroot /usr/share/nginx/html
EXPOSE 80
```

No caso do dockerfile acima estamos informando ao Docker que vamos basear nossa imagem na imagem do docker hub do nginx

Em seguida copiamos os dados do diretório wwwroot para dentro do container no diretório /usr/share/nginx/html

Por fim estamos definindo que vamos utilizar a porta 80 do container.

Para construir a imagem vamos utilizar o seguinte comando
```bash
docker build . -f Dockerfile -t demo2
```

Como saida do comando teremos

```bash
Sending build context to Docker daemon 4.608 kB
Step 1/4 : FROM nginx
 ---> 5e69fe4b3c31
Step 2/4 : WORKDIR app
 ---> Using cache
 ---> 0df60df30134
Step 3/4 : COPY wwwroot /usr/share/nginx/html
 ---> Using cache
 ---> 3e4a868b8831
Step 4/4 : EXPOSE 80
 ---> Using cache
 ---> fdab952cd763
Successfully built fdab952cd763
```

No fim para rodar a nossa demo

```bash
docker run -i -t -p 9000:80 demo2
```

Abra o navegador para ver a página de demo
[Nginx Localhost](http://localhost:9000)

Reparem que é possível acompanhar o log dos requests recebidos pelo browser no container.
