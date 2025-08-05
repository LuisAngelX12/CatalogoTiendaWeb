# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar solución y proyecto(s)
COPY *.sln ./
COPY CatalogoTiendaWeb/*.csproj ./CatalogoTiendaWeb/

# Restaurar paquetes
RUN dotnet restore

# Copiar todo el código fuente
COPY . .

# Publicar en modo Release, salida en /app/out
WORKDIR /app/CatalogoTiendaWeb
RUN dotnet publish -c Release -o /app/out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar desde build la carpeta publicada
COPY --from=build /app/out ./

# Exponer puerto 80
EXPOSE 80

# Comando para ejecutar la app
ENTRYPOINT ["dotnet", "CatalogoTiendaWeb.dll"]
