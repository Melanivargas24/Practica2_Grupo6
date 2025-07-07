# Práctica Programada 2
Con el objetivo de mejorar la gestión de sus clientes, una empresa dedicada a las ventas por internet ha desarrollado un sistema basado en una API REST. Esta API permite realizar operaciones CRUD (crear, leer, actualizar y eliminar) sobre los registros de clientes y sus respectivos números de teléfono.

## Integrantes del equipo
- Erick Esteban Aguilar Villalobos
- Ariel Solís Bermúdez
- Melani Tamar Vargas Arrieta
- Esteban Vargas Vargas

## Especificaciones básicas
**a. Arquitectura del proyecto:**
El proyecto sigue una arquitectura en capas bien separadas, lo cual promueve la mantenibilidad y escalabilidad del sistema. Las capas están organizadas en los siguientes proyectos:

- **EmpresaVOObjetos**
Contiene las clases de entidades (modelos del dominio) y ViewModels.
También incluye la configuración de AutoMapper (clase `MappingProfile`).

- **EmpresaVDAL (Data Access Layer)**
Encargado del acceso a datos mediante Entity Framework Core.
Incluye el `DbContext` (`EmpresaContext`) y los repositorios.

- **EmpresaVBLL (Business Logic Layer)**
Encapsula la lógica de negocio. Define servicios que usan los repositorios para aplicar reglas o lógica adicional.

- **EmpresaVe (Web API)**
Proyecto ASP.NET Core Web API.

**b. Librerías y paquetes Nuget utilizados**
Los paquetes NuGet utilizados en el proyecto son:
```bash
<ItemGroup>
  <PackageReference Include="AutoMapper" Version="15.0.0" />
  <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="9.0.6" />
  <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="9.0.6">
    <PrivateAssets>all</PrivateAssets>
    <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
  </PackageReference>
  <PackageReference Include="Swashbuckle.AspNetCore" Version="6.6.2" />
</ItemGroup>
  ```
- `AutoMapper`: herramienta para mapear objetos automáticamente entre entidades, DTOs y ViewModels.

- `Microsoft.EntityFrameworkCore.SqlServer`: para conectarse a SQL Server desde Entity Framework Core.

- `Microsoft.EntityFrameworkCore.Tools`: herramientas adicionales para manejar migraciones y scaffolding.

- `Swashbuckle.AspNetCore`: para generar documentación Swagger de la API REST.

**c. Link del repositorio**
https://github.com/Melanivargas24/Practica2_Grupo6.git
