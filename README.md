# 🧾 Facturador - Prueba Técnica

Este proyecto es un sistema de facturación desarrollado en .NET 8, compuesto por:

- ✅ Backend: ASP.NET Core Web API (`FacturadorAPI`).
- ✅ Frontend: Blazor (`FacturadorBlazor`).
- ✅ Base de Datos: SQL Server (`FacturadorDB`).

---

## 🚀 ¿Cómo ejecutar la solución?

### 🔧 Requisitos

- Visual Studio 2022.
- .NET 8.
- SQL Server.

### 🔁 Pasos para levantar la solución

1. Clonar el repositorio
2. Abrir la solución `FacturadorSolucion.sln` en Visual Studio
3. Configurar la conexión a base de datos en `appsettings.json` de `FacturadorAPI`

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=FacturadorDB;Trusted_Connection=True;"
   }

4. Ejecutar el script SQL para crear la base de datos y las tablas.

5. Ejecutar la solución con:

FacturadorAPI como proyecto de inicio.

FacturadorBlazor como segundo proyecto.

🗄 Script SQL – Base de Datos

CREATE DATABASE FacturadorDB;
GO

USE FacturadorDB;
GO

CREATE TABLE Cliente (
    Cli_ID INT NOT NULL PRIMARY KEY IDENTITY(1000,1),
    RazonSocial NVARCHAR(255) NOT NULL,
    CUIT NVARCHAR(50) NOT NULL,
    Direccion NVARCHAR(255) NOT NULL,
    Deshabilitado BIT NOT NULL
);

CREATE TABLE Articulo (
    Art_ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Descripcion NVARCHAR(255) NOT NULL,
    Precio DECIMAL(18, 2) NOT NULL
);

CREATE TABLE Factura_Cabecera (
    Fact_ID INT NOT NULL PRIMARY KEY IDENTITY(2000,1),
    FechaAlta DATE NOT NULL,
    Cli_ID INT NOT NULL,
    Estado NVARCHAR(50) NOT NULL,
    FOREIGN KEY (Cli_ID) REFERENCES Cliente(Cli_ID)
);

CREATE TABLE Factura_Detalle (
    Fact_Dtl_ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Fact_ID INT NOT NULL,
    FechaAlta DATE NOT NULL,
    Art_ID INT NOT NULL,
    Cantidad INT NOT NULL,
    Precio DECIMAL(18, 2) NOT NULL,
    Monto DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (Fact_ID) REFERENCES Factura_Cabecera(Fact_ID),
    FOREIGN KEY (Art_ID) REFERENCES Articulo(Art_ID)
);

GO

📁 Estructura del proyecto

/FacturadorSolucion
│
├── /FacturadorAPI       → Proyecto Web API (.NET 8)
├── /FacturadorBlazor    → Proyecto Blazor Server (.NET 8)
└── FacturadorSolucion.sln

🛠 En construcción...
Este proyecto está en desarrollo como parte de una prueba técnica.