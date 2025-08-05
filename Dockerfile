# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln .
COPY CatalogoTiendaWeb/*.csproj ./CatalogoTiendaWeb/
RUN dotnet restore

COPY . .
WORKDIR /app/CatalogoTiendaWeb
RUN dotnet publish -c Release -o out

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/CatalogoTiendaWeb/out ./

EXPOSE 80
ENTRYPOINT ["dotnet", "CatalogoTiendaWeb.dll"]
