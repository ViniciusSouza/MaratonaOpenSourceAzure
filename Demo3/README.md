# Demo 3 - utilizando o mapeamento de volume

Nesse demo vamos utilizar o mapeamento de container do Docker para ter acesso a um diretório da máquina local dentro do container.

Esse tipo de utilização pode habilitar diversos casos de uso, como por exemplo o compartilhamento de dados entre os containers que estão rodando. 

Os containers são imutáveis para ter os dados peristentes entre as execuções do container devemos utilizar o volume.

Ou para o caso de desenvolvimento para termos agilidade durante o desenvolvimento.

Veja o dockerfile abaixo
```dockerfile
FROM nginx
WORKDIR /
EXPOSE 80
```

Diferentemente da demo anterior não temos a presença da directiva *COPY*, já que não queremos neste momento que os arquivos do meu projeto façam parte do container.

```bash
docker build . -f Dockerfile -t demo3
```

Saida do comando
```bash
Step 1/3 : FROM nginx
 ---> 5e69fe4b3c31
Step 2/3 : WORKDIR /
 ---> Using cache
 ---> b9ec0ad9da5d
Step 3/3 : EXPOSE 80
 ---> Using cache
 ---> 31ac9a8da692
Successfully built 31ac9a8da692
```

```bash
docker run -i -t -p 9000:80 -v C:\Users\visouza\Repos\MaratonaOpenSourceAzure\Demo3\wwwroot:/usr/share/nginx/html demo3
```

Utilizando o parâmetro -v conseguimos disponibilizar o nosso código para o container e a cada atualizaçao do código não precisaremos gerar um novo container a cada alteração, o que é ideal para o desenvolvimento local.