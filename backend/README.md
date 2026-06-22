# Backend - Sistema de Inventario

API desarrollada en ASP.NET Core Web API para la gestión de usuarios y productos con autenticación mediante JWT.

---

## Tecnologías utilizadas

- C#
- .NET  8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger

---

## Descripción del proyecto

Este backend forma parte de un sistema de inventario y proporciona una API REST para:

- Autenticación de usuarios
- Generación de token JWT
- Gestión de productos (CRUD completo)
- Protección de endpoints mediante autenticación

---

## Autenticación (JWT)

El sistema implementa autenticación con JSON Web Token (JWT):

- El usuario inicia sesión con usuario o email + contraseña
- Si las credenciales son correctas, se genera un token JWT
- El token es requerido para acceder a los endpoints protegidos
- Si el token es inválido o no se envía, se retorna error 401 Unauthorized

---

##  Endpoints de la API

### Auth

#### Login
POST /api/auth/login


**Descripción:**  
Valida las credenciales del usuario y retorna un token JWT.

**Respuestas:**
- 200 OK → Login exitoso + token JWT
- 401 Unauthorized → Credenciales inválidas

---

### Products (Protegido con JWT)

> Todos los endpoints requieren autenticación mediante Bearer Token.

#### Obtener todos los productos
GET /api/products


#### Obtener producto por ID
GET /api/products/{id}


#### Crear producto
POST /api/products


#### Actualizar producto
PUT /api/products/{id}


#### Eliminar producto lógico
DELETE /api/products/{id}


---

##  Base de datos

- Motor: SQL Server
- ORM: Entity Framework Core
- Migraciones utilizadas para la creación y actualización de tablas

---

###  Configuración de conexión

```json
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=PruebaTecnicaDB;Trusted_Connection=True;TrustServerCertificate=True;" 
```

## Ejecución del proyecto


### Pasos para ejecutar

## Opción 1: Visual Studio

- Abrir la solución (.sln) en Visual Studio  
- Verificar la cadena de conexión en `appsettings.json`

- Abrir la Package Manager Console:
  - Tools → NuGet Package Manager → Package Manager Console

- Aplicar migraciones ejecutando el siguiente comando:
- Update-Database

## Opción 2: Visual Studio Code

- Clonar el repositorio:
  git clone https://github.com/Carlos-Pech/Prueba-Backend.git

- cd backend

- Abrir en VS Code:
  code .

- Restaurar dependencias:
  dotnet restore

- Instalar herramienta de Entity Framework (solo primera vez):
  dotnet tool install --global dotnet-ef

- Aplicar migraciones:
  dotnet ef database update

- Ejecutar el proyecto:
  dotnet run

## Acceder a Swagger:
https://localhost:{puerto}/swagger