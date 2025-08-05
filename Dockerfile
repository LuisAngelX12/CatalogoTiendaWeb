# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia la solución y el proyecto
COPY *.sln .
COPY CatalogoTiendaWeb/*.csproj ./CatalogoTiendaWeb/
RUN dotnet restore

# Copia todo y publica la aplicación
COPY . .
WORKDIR /app/CatalogoTiendaWeb
RUN dotnet publish -c Release -o out

# Imagen final para ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/CatalogoTiendaWeb/out .
ENTRYPOINT ["dotnet", "CatalogoTiendaWeb.dll"]
