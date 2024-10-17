FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# RUN apt-get update && apt-get install -y git

# ARG CLONE_URL
# ARG INTERNAL_PORT

WORKDIR /app

RUN git clone ${CLONE_URL} .

RUN rm -rf .git

RUN dotnet restore

COPY appsettings.json .

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

EXPOSE ${INTERNAL_PORT}

ENTRYPOINT ["dotnet", "main-menu-api.dll"]


# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copiar arquivos do projeto
COPY . .

# Restaurar dependências
RUN dotnet restore

# Build da aplicação
RUN dotnet publish -c Release -o /app/publish

# Etapa de produção
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expor a porta onde a API será executada
EXPOSE 80

# Definir o comando de entrada
ENTRYPOINT ["dotnet", "SuaAPI.dll"]
