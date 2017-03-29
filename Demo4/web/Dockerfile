FROM microsoft/aspnetcore-build
WORKDIR /app
COPY . .
RUN ["dotnet", "restore"]
EXPOSE 80
ENTRYPOINT ["dotnet", "run"]