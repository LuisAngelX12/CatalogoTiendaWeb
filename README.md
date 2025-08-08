# Catálogo Web de Tienda

Este proyecto consiste en una aplicación web desarrollada en **ASP.NET MVC 8.0** con persistencia en **PostgreSQL**, cuyo propósito es simular el catálogo funcional de una tienda en línea. 
Está orientado al aprendizaje práctico del patrón de diseño **MVC**, la gestión de base de datos mediante **Entity Framework Core** y el uso de metodologías ágiles como **Scrum-Kanban**.

## Equipo de Desarrollo

- Luis Ángel Hernández Monge
- Ashley Sardí Fonseca
- Yaer Blanco Quirós

## Tecnologías utilizadas

- ASP.NET Core MVC 9.0
- Entity Framework Core (con conector Npgsql para PostgreSQL)
- Bootstrap 5
- HTML + Razor
- PostgreSQL
- Visual Studio / Visual Studio Code
- Git + GitHub

## Funcionalidades principales

- Área de Administrador
  - Gestión de productos (crear, editar, eliminar, listar)
  - Visualización de ventas o inventario (Simple/ilustrativo)
  
- Área de Clientes
  - Registro e inicio de sesión
  - Visualización del catálogo de productos
  - Búsqueda y filtrado de productos
  - Carrito de compras básico

- Seguridad
  - Roles separados para Administrador y Cliente
  - Control de sesión y cierre seguro

## Estructura del Proyecto

- `Models/` – Clases que representan las entidades del sistema (Producto, Usuario, etc.).
- `Controllers/` – Controladores para manejar la lógica de negocio.
- `Views/` – Vistas separadas para cliente y administrador usando Razor.
- `wwwroot/` – Archivos estáticos como CSS, JS e imágenes.

## Metodología de trabajo

El proyecto fue desarrollado utilizando una mezcla de **Scrum y Kanban**, dividiendo el trabajo en sprints semanales de dos semanas con tableros visuales para gestionar tareas, backlog y avances.

## Cómo ejecutar el proyecto

1. Clona este repositorio:

   ```bash
   git clone https://github.com/usuario/repositorio-catalogo.git
   cd repositorio-catalogo

2. Abre el proyecto (Visual Studios/code)

3. Ejecuta en la terminal del proyecto (Para actualizar la migracion de la base de datos):

  ``bash
  dotnet ef database update
  ``bash
  
4. Ejecuta el proyecto:

  ``bash
  dotnet run
  ``bash
  
// ¡Listo! Ya puedes acceder a tu catálogo en línea en https://localhost:5001 (o el puerto configurado).
