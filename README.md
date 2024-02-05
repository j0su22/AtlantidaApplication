# Atlantida Application Project
**Por Josué Cortez**


# Sistema de Gestión de Tarjeta de Crédito

Este proyecto es un sistema de gestión de transacciones para tarjetas de crédito, desarrollado con .NET Core 7.0 y C#, utilizando SQL Server como sistema de gestión de bases de datos. El sistema permite simular transacciones de gastos y abonos en una tarjeta de crédito.

## Estructura del Proyecto

El proyecto incluye dos principales aplicaciones:

1. **API en ASP.NET Core**: Proporciona los endpoints necesarios para gestionar las transacciones.
2. **Aplicación ASP.NET Core MVC**: Interfaz de usuario para interactuar con el sistema de gestión de tarjetas de crédito.

Además, se incluyen los siguientes recursos:

- **Script de Base de Datos**: Ubicado en la carpeta `DataBase`, contiene todos los scripts necesarios para configurar la base de datos en SQL Server.
- **Pruebas de Postman**: En la carpeta `Postman`, se encuentran las colecciones exportadas para probar los endpoints del API.

## Requisitos Previos

Para ejecutar este proyecto, necesitarás:

- Visual Studio 2022
    - .NET Core 7.0 SDK
- SQL Server
    - SQL Management Studio
- Postman (opcional, para ejecutar pruebas de API)

## Configuración

### Base de Datos

1. Instala SQL Server si aún no lo has hecho.
2. Ejecuta el script SQL encontrado en `./DataBase` para crear y configurar la base de datos.

### Aplicación

1. Clona este repositorio en tu máquina local.
2. Abre la solución con tu IDE preferido (recomendado: Visual Studio).
3. Restaura los paquetes NuGet.
4. Asegúrate de configurar la cadena de conexión a la base de datos en los proyectos de API y MVC, según corresponda.
5. Compila la solución para verificar que todo esté configurado correctamente.

## Ejecución

Para ejecutar la aplicación:

1. Ejecuta el proyecto de API. Esto expondrá los endpoints necesarios para la aplicación.
2. Ejecuta el proyecto de aplicación MVC para iniciar la interfaz de usuario.
3. Navega a la dirección web proporcionada por el proyecto MVC para empezar a usar la aplicación.

## Pruebas con Postman

Para probar el API:

1. Importa la colección de Postman proporcionada en la carpeta `Postman`.
2. Asegúrate de que el proyecto de API esté ejecutándose.
3. Utiliza las solicitudes de Postman importadas para probar los diferentes endpoints.
