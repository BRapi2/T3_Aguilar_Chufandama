# T3_Aguilar_Chufandama — Instrucciones para conectar a SQL Server y ejecutar

Este proyecto es una aplicación ASP.NET MVC (net6.0) que implementa CRUD para la entidad `Libro`, autenticación por cookies y autorización para el CRUD.

Objetivo de este README: dejar todo listo para conectar a Microsoft SQL Server (local o en Docker) próximamente.

---

## 1) Notas importantes
- El proyecto ya tiene `ApplicationDbContext` y `DbSet<Libro>`. El arranque aplica migraciones automáticamente si existen (se usa `Database.Migrate()` en `Program.cs`).
- En `Controllers/LibroController.cs` la clase está protegida por `[Authorize(Policy = "RequireAuthenticatedUser")]`.
- Usuarios de prueba (definidos en `AccountController`): `admin/password` y `user/password`.

## 2) Cadena de conexión (editar antes de ejecutar)
Archivo: `appsettings.json`

Actualmente el valor por defecto es un ejemplo preparado para SQL Server corriendo en Docker:

```
"DefaultConnection": "Server=localhost,1433;Database=BD_Aguilar_Chufandama_T3;User Id=sa;Password=Your_password123;MultipleActiveResultSets=true"
```

Cambia `User Id` y `Password` por los que uses (ej. la contraseña definida cuando inicias el contenedor Docker).

Si ejecutarás en Windows con LocalDB, puedes usar:

```
"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BD_Aguilar_Chufandama_T3;Trusted_Connection=True;MultipleActiveResultSets=true"
```

## 3) Ejecutar SQL Server en Docker (macOS / Linux)
Comando de ejemplo para levantar SQL Server 2019 en Docker:

```bash
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Your_password123' -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2019-latest
```

- Reemplaza `Your_password123` por una contraseña segura (mínimo 8 caracteres con mayúsculas, minúsculas y números).
- Espera unos segundos hasta que el contenedor esté listo.

## 4) Herramientas .NET / EF Core
Instala `dotnet-ef` si no lo tienes:

```bash
dotnet tool install --global dotnet-ef
```

Si prefieres instalar localmente (opcional):

```bash
dotnet new tool-manifest # si no tienes manifest
dotnet tool install dotnet-ef
```

El proyecto ya tiene referencias a `Microsoft.EntityFrameworkCore.SqlServer` y `Microsoft.EntityFrameworkCore.Design` en el `.csproj`.

## 5) Crear migraciones y aplicar la base de datos
Después de editar `appsettings.json` con la cadena correcta, desde la raíz del proyecto:

```bash
cd /path/to/T3_Aguilar_Chufandama
# Crear migración (ejemplo)
dotnet ef migrations add InitialCreate
# Aplicar migraciones a la BD
dotnet ef database update
```

Nota: `Program.cs` ya ejecuta `db.Database.Migrate()` al iniciar la aplicación, por lo que si prefieres no ejecutar `dotnet ef database update` manualmente, al `dotnet run` la app intentará aplicar migraciones.

## 6) Ejecutar la aplicación

```bash
dotnet build
dotnet run
```

Abre el navegador en la URL indicada (normalmente https://localhost:5001 o http://localhost:5000).

- Ir a `/Account/Login` para autenticarse (usa `admin/password`).
- Visitar `/Libro` para acceder al CRUD (requiere autenticación).
- Ver las dos pestañas nuevas en el menú: `Arquitectura de Software` y `Diseño de Software`.

## 7) Git / Evidencias
Sugerencia de commits mínimos:

1. `Initial project import - base ASP.NET MVC project`
2. `Implement Libro model, ApplicationDbContext and CRUD controller/views`
3. `Fix encoding accents and add Arquitectura/Diseno views + layout nav`

Comandos útiles para evidencias:

```bash
git status
git log --oneline --decorate --graph
git remote -v
```

Una vez empujes los commits a GitHub, la página de commits del repo servirá como evidencia.

## 8) Problemas comunes y soluciones
- Si ves errores de conexión al iniciar, confirma la cadena de conexión y que el servidor SQL esté escuchando en el puerto correcto.
- En macOS, `localdb` no está disponible: usa SQL Server en Docker o una instancia remota.
- Si `dotnet ef migrations add` falla por versión, asegúrate de tener `dotnet-ef` instalado y que la versión del SDK sea compatible con net6.0.

---

Si quieres, puedo:
- generar la primera migración aquí (solo crear archivos de migración), pero no puedo aplicarlas porque no tengo `dotnet` ni acceso a tu máquina desde este entorno; te daré los comandos listos para copiar/pegar.
- o dejar todo tal cual y guiarte paso a paso mientras lo ejecutas localmente.

¿Qué prefieres?