# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar solución y proyecto
COPY *.sln ./
COPY *.csproj ./

# Restaurar dependencias
RUN dotnet restore

# Copiar todo el código
COPY . ./

# Publicar
RUN dotnet publish -c Release -o /out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out ./
ENTRYPOINT ["dotnet", "CatalogoTiendaWeb.dll"]
