# Instrucciones para ejecutar la API Crud Person.

Este archivo proporciona instrucciones detalladas para configurar y ejecutar el API Backend correctamente.

## Requisitos previos

Antes de comenzar, asegúrate de tener instalados los siguientes componentes en tu sistema:

- MySQL Server: Se requiere para almacenar y gestionar los datos.
- .NET Core SDK 3.1: Es necesario para compilar y ejecutar el proyecto de backend.

Puedes descargar e instalar estos componentes desde los siguientes enlaces:

 [Descargar de .NET](https://dotnet.microsoft.com/es-es/download/dotnet/8.0)
 [MySQL](https://dev.mysql.com/downloads/mysql/)

### Pasos para la configuración

### Instalación de MySQL
1. Descarga e instala MySQL Server desde el sitio web oficial de MySQL.
2. Durante la instalación, se te pedirá configurar una contraseña para el usuario root de MySQL. Asegúrate de recordar esta contraseña ya que la necesitarás más adelante.

###  Creación de la base de datos y tablas

1. Abre tu cliente MySQL (por ejemplo, MySQL Workbench) e inicia sesión con tu usuario y contraseña.
2. Crea una nueva base de datos llamada "redEfectiva".
3. Ejecuta el siguiente script SQL para crear la tabla necesaria:
```
CREATE DATABASE redEfectiva;
USE redEfectiva;

CREATE TABLE Person (
    PersonId VARCHAR(36) NOT NULL UNIQUE,
    FirstName VARCHAR(255) NOT NULL,
    LastName VARCHAR(255) NOT NULL,
    Gender VARCHAR(10) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Email VARCHAR(255) NOT NULL,
    Phone VARCHAR(20) NOT NULL,
    Status TINYINT NOT NULL DEFAULT 1,
    MaritalStatus VARCHAR(20),
    CreatedDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (PersonId)
);

```

## Configuración del proyecto API Backend

1. Clona este repositorio en tu máquina local.
2. Abre la solución del proyecto en tu editor de código preferido.

## Configuración de la cadena de conexión

1. Abre el archivo appsettings.json.
2. En la sección "ConnectionStrings", actualiza la cadena de conexión para que coincida con tu configuración de MySQL:

```
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=test;user=root;password=TU_CONTRASEÑA;"
  }
}

```
Reemplaza "TU_CONTRASEÑA" con la contraseña que configuraste durante la instalación de MySQL.

## Ejecución del proyecto

1. Abre una terminal en el directorio raíz del proyecto.
2. Ejecuta el siguiente comando para compilar y ejecutar el API:
```
dotnet run

```