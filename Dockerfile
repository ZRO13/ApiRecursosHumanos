# 1. Fase base para ejecución en OpenShift
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# OpenShift requiere que la app no corra como root por seguridad
USER $APP_UID 
WORKDIR /app
EXPOSE 8080

# 2. Fase de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar el archivo de la solución y las definiciones de los proyectos
COPY ["SistemaRRHH.API.sln", "./"]
COPY ["Presentation/Presentation.csproj", "Presentation/"]
COPY ["ApplicationCore/ApplicationCore.csproj", "ApplicationCore/"]

# Restaurar dependencias a nivel global usando la solución
RUN dotnet restore "SistemaRRHH.API.sln"

# Copiar el resto del código fuente a la imagen
COPY . .
WORKDIR "/src/Presentation"

# Compilar
RUN dotnet build "./Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

# 3. Fase de publicación
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# 4. Fase final (Imagen ligera solo con los binarios)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Presentation.dll"]