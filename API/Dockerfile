# Estágio 1: Build (usando o SDK completo do .NET 8)
# Usamos a imagem oficial da Microsoft com todas as ferramentas de build.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia todos os arquivos do seu repositório para dentro do container
COPY . .

# Executa o comando publish no seu projeto específico.
# Ele restaura os pacotes, compila e publica a aplicação em uma pasta 'out'.
RUN dotnet publish "API/vitalapi/vitalapi.csproj" -c Release -o /app/publish

# Estágio 2: Final (usando o runtime enxuto do ASP.NET)
# Usamos uma imagem muito menor, apenas com o necessário para rodar a API.
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copia apenas os arquivos publicados do estágio de build para a imagem final.
COPY --from=build /app/publish .

# O Railway define a porta automaticamente, mas é uma boa prática expor uma.
EXPOSE 8080

# Comando para iniciar a sua API.
ENTRYPOINT ["dotnet", "vitalapi.dll"]