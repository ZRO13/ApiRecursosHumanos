# 1. Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar la solución y los archivos de proyecto respetando la estructura
COPY ["SistemaRRHH.API.sln", "./"]
COPY ["ApplicationCore/ApplicationCore.csproj", "ApplicationCore/"]
COPY ["Presentation/Presentation.csproj", "Presentation/"]

# Restaurar dependencias a nivel de solución
RUN dotnet restore "SistemaRRHH.API.sln"

# Copiar el resto del código fuente
COPY . .

# Moverse a la carpeta del proyecto principal (API) y publicarlo
WORKDIR "/src/Presentation"
RUN dotnet publish "Presentation.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 2. Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Exponer el puerto por defecto de .NET 8
EXPOSE 8080

# Iniciar la aplicación (Verifica que tu proyecto principal se llame Presentation)
ENTRYPOINT ["dotnet", "Presentation.dll"]