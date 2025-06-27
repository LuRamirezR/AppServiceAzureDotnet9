# Weather Forecast API con PostgreSQL

Este proyecto es una API de pronóstico del tiempo construida con .NET 9 y PostgreSQL usando Entity Framework Core.

## Requisitos Previos

- .NET 9 SDK
- Docker y Docker Compose (para PostgreSQL local)
- PostgreSQL (alternativa sin Docker)

## Configuración Local

### 1. Instalar dependencias

```bash
dotnet restore
```

### 2. Configurar base de datos PostgreSQL

#### Opción A: Usando Docker Compose (Recomendado)

```bash
docker-compose up -d
```

#### Opción B: PostgreSQL local

Instala PostgreSQL localmente y crea una base de datos llamada `weatherdb`.

### 3. Variables de entorno locales

Las variables de entorno están configuradas en `Properties/launchSettings.json`:

- `POSTGRES_HOST`: localhost
- `POSTGRES_PORT`: 5432
- `POSTGRES_DB`: weatherdb
- `POSTGRES_USER`: postgres
- `POSTGRES_PASSWORD`: postgres

### 4. Ejecutar la aplicación

```bash
dotnet run
```

La API estará disponible en:

- HTTP: http://localhost:5208/weatherforecast
- HTTPS: https://localhost:7264/weatherforecast

## Configuración para Azure

### Variables de entorno en Azure App Service

En el portal de Azure, en tu App Service, ve a **Configuration** > **Application settings** y agrega:

1. `POSTGRES_HOST`: [URL de tu servidor PostgreSQL en Azure]
2. `POSTGRES_PORT`: `5432`
3. `POSTGRES_DB`: [nombre de tu base de datos]
4. `POSTGRES_USER`: [usuario de la base de datos]
5. `POSTGRES_PASSWORD`: [contraseña de la base de datos]

### GitHub Actions Secrets

En tu repositorio de GitHub, ve a **Settings** > **Secrets and variables** > **Actions** y asegúrate de tener:

1. `AZURE_WEBAPP_NAME`: [nombre de tu App Service]
2. `AZURE_WEBAPP_PUBLISH_PROFILE`: [perfil de publicación descargado de Azure]

### PostgreSQL en Azure

Para producción, puedes usar:

1. **Azure Database for PostgreSQL** (recomendado)
2. **PostgreSQL en Azure Container Instances**
3. **PostgreSQL en Azure VM**

## Estructura del Proyecto

```
AppServiceAzureDotnet9/
├── Data/
│   └── WeatherContext.cs          # Contexto de Entity Framework
├── Properties/
│   └── launchSettings.json        # Variables de entorno locales
├── .github/
│   └── workflows/
│       └── deploy.yml            # Pipeline de GitHub Actions
├── docker-compose.yml            # PostgreSQL local
├── Program.cs                    # Configuración principal
└── appsettings.json             # Configuración de la aplicación
```

## API Endpoints

- `GET /weatherforecast`: Obtiene el pronóstico del tiempo desde la base de datos PostgreSQL

## Notas Importantes

- La aplicación usa `context.Database.EnsureCreated()` para crear automáticamente la base de datos y las tablas
- Los datos semilla se insertan automáticamente la primera vez
- Las variables de entorno permiten diferentes configuraciones entre desarrollo y producción
- La cadena de conexión usa interpolación de variables de entorno para mayor flexibilidad
