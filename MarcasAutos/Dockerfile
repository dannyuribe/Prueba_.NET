# ----------------------
# Etapa de build
# ----------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar el proyecto y restaurar paquetes
COPY MarcasAutos/MarcasAutos.csproj MarcasAutos/
RUN dotnet restore MarcasAutos/MarcasAutos.csproj

# Copiar todo el código y publicar
COPY . .
WORKDIR /src/MarcasAutos
RUN dotnet publish MarcasAutos.csproj -c Release -o /app/publish

# ----------------------
# Etapa de runtime
# ----------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar la app publicada desde la etapa build
COPY --from=build /app/publish .

# Exponer puertos para la API
EXPOSE 5000
EXPOSE 5001

# Comando de inicio de la API
ENTRYPOINT ["dotnet", "MarcasAutos.dll"]