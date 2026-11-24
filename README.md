# ByteLab · Tienda de Hardware

Proyecto final (20 %) de Programación de Software – ITM.
**Equipo:** Mathiu Osorio Echeverri · Samuel Tabares Parra · Juan David Cano

Aplicación web completa en .NET 10 / C# con la misma arquitectura del ejemplo `horarios` del profe:

```
ByteLab.slnx
├── lib_bytelab              → entidades, interfaces, repositorios (Entity Framework), auditoría, Script.sql
├── servicio_bytelab         → API REST (ASP.NET Core)  ·  http://localhost:5210
├── presentaciones_bytelab   → comunicación front → API (HttpClient + Newtonsoft.Json)
├── front_bytelab            → presentación (ASP.NET Core Razor Pages, sesiones, CSS, imágenes)  ·  http://localhost:5180
└── pruebas_bytelab          → pruebas unitarias (MSTest): repositorios, comunicaciones y reglas de negocio
```

---

## 1. Cómo correrlo (primera vez)

1. **Base de datos.** Abra `lib_bytelab/Script.sql` en SQL Server Management Studio y ejecútelo completo.
   Crea `db_bytelab` con las 25 tablas y datos de prueba. *(Si la base ya existe, el script la borra y la vuelve a crear.)*
2. **Cadena de conexión.** Si su servidor no es `localhost` (por ejemplo `localhost\SQLEXPRESS`), cámbielo en:
   - `servicio_bytelab/appsettings.json` → `ConnectionStrings:ByteLab`
   - `lib_bytelab/nucleo/DatosGenerales.cs` → `StringConexion()` (lo usan las pruebas)
3. **Abrir** `ByteLab.slnx` en Visual Studio 2026 (o 2022 17.14+ con .NET 10).
4. **Arrancar los dos proyectos a la vez:** clic derecho en la solución → *Configurar proyectos de inicio* → *Varios proyectos de inicio* → `servicio_bytelab` y `front_bytelab` en **Iniciar**.
5. Entre a http://localhost:5180 con alguno de estos usuarios:

| Correo | Contraseña | Rol | Qué ve |
|---|---|---|---|
| admin@bytelab.com | Admin.123 | Administrador | Todo |
| vendedor@bytelab.com | Vendedor.123 | Vendedor | Clientes, catálogo, ventas, pagos, envíos, garantías, reportes |
| bodega@bytelab.com | Bodega.123 | Bodeguero | Productos, inventarios, proveedores, órdenes de compra, reportes |
| laura@correo.com | Cliente.123 | Cliente | Reseñas y mapa |

> Para revisar que la API está viva: http://localhost:5210/salud (dice si la base de datos conecta).

---

## 2. Cómo cumple cada punto del enunciado

| Requisito | Dónde está |
|---|---|
| **20 entidades + Usuarios, Roles, Auditorías** | 25 tablas: las 21 del modelo de BityLap + `Categorias` (antes era un número suelto en Productos) + **módulo de roles** (`Roles`, `Permisos`, `RolesPermisos`) + `Usuarios` + `Auditorias` |
| **Auditoría para todas las entidades** | `lib_bytelab/implementaciones/Conexion.cs` → `SaveChanges()` guarda automáticamente quién, qué, cuándo y los datos de cada Insertar/Actualizar/Borrar, en cualquier tabla. También se audita cada Login. Ventana de solo lectura: *Seguridad → Auditorías* |
| **POO** | `EntidadBase` (clase abstracta, herencia), `Validar()` y `ToString()` sobrescritos en cada entidad (polimorfismo), `IConImagen` (interfaz), `AplicacionBase<T>`, `ControladorBase<T>`, `PresentacionBase<T>`, `VentanaBase<T>` (genéricos + herencia), métodos plantilla `AntesDeGuardar/DespuesDeGuardar` |
| **ORM** | Entity Framework Core (SQL Server) en `lib_bytelab` |
| **WebAPI RESTful** | `servicio_bytelab/Controllers` – un controlador por entidad: `Entidad/Consultar`, `Buscar`, `Insertar`, `Actualizar`, `Borrar` (+ `Usuarios/Login`) |
| **Para cada entidad API y presentación** | 25 controladores, 25 presentaciones y 25 ventanas Razor (`front_bytelab/Pages/Ventanas`) |
| **Sesiones** | Login contra la tabla Usuarios (contraseña cifrada SHA-256), la sesión guarda usuario, rol y permisos. Cada ventana revisa sesión y permiso (`PaginaSegura`) y el menú solo muestra lo que el rol puede ver |
| **CSS / imágenes** | Bootstrap + `wwwroot/css/site.css`, logo en `wwwroot/img`, foto de cada producto subida desde el formulario (se guarda en base64 como en el ejemplo del profe) |
| **Pruebas unitarias** | `pruebas_bytelab`: `Repositorios/` (CRUD real contra la base, una por entidad), `Comunicaciones/` (presentación + API), `Unitarias/` (reglas de negocio sin base de datos) |
| **Reportes PDF / Excel** (investigativo) | Botones **PDF** y **Excel** en todas las ventanas + página *Herramientas → Reportes* (ventas por sucursal, bajo stock, más vendidos). Librerías: QuestPDF y ClosedXML |
| **Aplicación específica** (investigativo) | **Mapa** de sucursales (*Herramientas → Mapa*, librería Leaflet + OpenStreetMap) e **impresión** de la factura de cada venta (botón *Factura* en Ventas → *Imprimir*) |
| **Publicación local IIS** | Sección 5 + `publicar-iis.ps1` |
| **Nube y monitoreo** | Sección 6 |
| **Git y branches** | Sección 7 |

### Lógica de negocio que vale la pena mostrar en la sustentación
- **Venta:** al agregar un detalle se calcula el subtotal, se **descuenta el inventario** de la sucursal de la venta (y si no hay stock, no deja), y se **recalcula el total** de la venta aplicando el % de la promoción. Al borrar el detalle, el inventario se devuelve.
- **Orden de compra:** el subtotal de cada línea y el total estimado de la orden se calculan solos.
- **Inventario:** marca automáticamente los productos por debajo del stock mínimo (reporte "Bajo stock").
- **Validaciones:** precio no negativo, calificación 1-5, descuento 0-100 %, fecha fin ≥ inicio, cantidad ≤ capacidad de bodega, correo válido, contraseña mínima de 6 caracteres, valores únicos (cédula, correo, NIT, cupón, guía).
- **Usuarios:** la contraseña nunca se guarda ni viaja de vuelta en texto plano; al editar, si se deja vacía se conserva la anterior.

---

## 3. Cómo funciona (para que todos lo puedan explicar)

Recorrido de un clic en **Guardar** en la ventana Productos:

```
Productos.cshtml  ──POST──►  ProductosModel (hereda VentanaBase<Productos>)
                                 │ OnPostBtGuardar()
                                 ▼
                       ProductosPresentacion (hereda PresentacionBase<Productos>)
                                 │ valida con entidad.Validar() y llama
                                 ▼
                       Comunicaciones  ──HTTP POST JSON──►  "Productos/Insertar"
                                                                   │
                                                                   ▼
                                                  ProductosController (hereda ControladorBase<Productos>)
                                                                   │
                                                                   ▼
                                                  ProductosAplicacion (hereda AplicacionBase<Productos>)
                                                     Validar → AntesDeGuardar → EF Core
                                                                   │
                                                                   ▼
                                                  Conexion.SaveChanges() → SQL Server + Auditorias
```

**¿Por qué clases base genéricas?** Las 25 entidades hacen lo mismo (consultar, buscar, insertar, actualizar, borrar). En vez de copiar 25 veces el mismo código, está escrito **una vez** en la clase base y cada entidad hereda y solo agrega lo propio:

- `ProductosAplicacion` → qué tablas incluir (`Include`), por qué campo buscar, y conservar la imagen al editar.
- `ProductosModel` → qué listas desplegables cargar (categorías y marcas).
- `Productos` → qué campos son obligatorios (`Validar`) y cómo se muestra (`ToString`).

**Convenciones del profe que se respetan:** clases en plural con mayúscula y propiedad `Id`; llave foránea como `int` con el nombre de la entidad (`Categoria`) y su objeto con guion bajo (`_Categoria`); botones `BtConsultar / BtNuevo / BtGuardar / BtEditar / BtPregBorrar / BtBorrar`; `LogConversor` para mostrar errores; `IConexion` para el `DbContext`.

**Para agregar una entidad nueva** (ej. `Cupones`): 1) tabla en `Script.sql`, 2) clase en `entidades`, 3) `DbSet` en `IConexion` y `Conexion`, 4) `ICuponesAplicacion` + `CuponesAplicacion`, 5) `CuponesController`, 6) `ICuponesPresentacion` + `CuponesPresentacion`, 7) registrarlas en los dos `Program.cs`, 8) `Cupones.cshtml` + `.cs`, 9) permiso en la tabla `Permisos`.

---

## 4. Pruebas

En Visual Studio: *Prueba → Explorador de pruebas → Ejecutar todas*.

- `Unitarias/ReglasPrueba` → no necesitan nada (cálculos, validaciones, cifrado).
- `Comunicaciones/*` → `ArmaLaRutaDelServicio` y `NoEnviaSiFaltaInformacion` usan una comunicación falsa; `ConsultarDesdeLaApi` necesita la API encendida (si está apagada sale *Inconclusa*).
- `Repositorios/*` → necesitan la base `db_bytelab` creada con el script. Cada una inserta, consulta, modifica y borra un registro. `AuditoriasPrueba` comprueba que el cambio quedó auditado.

Por consola: `dotnet test` (o sin las de integración: `dotnet test --filter TestCategory!=Integracion`).

---

## 5. Publicación local en IIS

1. **Activar IIS:** *Activar o desactivar características de Windows* → *Internet Information Services*.
2. **Instalar el ASP.NET Core Hosting Bundle de .NET 10** (desde dotnet.microsoft.com) y reiniciar.
3. En la carpeta de la solución, ejecutar en PowerShell:
   `powershell -ExecutionPolicy Bypass -File .\publicar-iis.ps1`
   (publica la API en `C:\inetpub\bytelab\api` y el front en `C:\inetpub\bytelab\web`).
4. En el **Administrador de IIS**:
   - *Grupos de aplicaciones* → los dos sitios con **Sin código administrado**.
   - *Agregar sitio web* `bytelab-api` → carpeta `api` → puerto **5210** (apague antes el de Visual Studio).
   - *Agregar sitio web* `bytelab-web` → carpeta `web` → puerto **8080**.
5. **Permiso en SQL Server para IIS** (el sitio corre con otro usuario de Windows). En SSMS:
   ```sql
   CREATE LOGIN [IIS APPPOOL\bytelab-api] FROM WINDOWS;
   USE db_bytelab;
   CREATE USER [IIS APPPOOL\bytelab-api] FOR LOGIN [IIS APPPOOL\bytelab-api];
   ALTER ROLE db_owner ADD MEMBER [IIS APPPOOL\bytelab-api];
   ```
6. Si la API queda en otro puerto, cambie `UrlServicio` en `C:\inetpub\bytelab\web\appsettings.json`.
7. Probar: http://localhost:5210/salud y http://localhost:8080.

---

## 6. Despliegue en la nube y monitoreo

Opción recomendada: **Azure** (con la cuenta *Azure for Students* del correo institucional, sin tarjeta).

1. Crear una **Azure SQL Database** y ejecutar `Script.sql` sobre ella (quitando las líneas de `CREATE/DROP DATABASE` y `USE`). Permitir el acceso desde servicios de Azure en el firewall.
2. Crear **dos App Service** (Windows o Linux, .NET 10): `bytelab-api` y `bytelab-web`.
3. Publicar desde Visual Studio: clic derecho en el proyecto → *Publicar* → *Azure* → *App Service*.
4. Configuración (*Variables de entorno* del App Service):
   - en la API: cadena de conexión `ByteLab` = la de Azure SQL (usuario y contraseña).
   - en el front: `UrlServicio` = `https://bytelab-api.azurewebsites.net/`.
5. **Monitoreo del desempeño:**
   - La API registra cada petición con su tiempo (`GET /Productos/Consultar -> 200 en 35 ms`) → se ve en *Secuencia de registro* del App Service.
   - `/salud` muestra si la base conecta → úsela en *Comprobación de estado* (Health check) del App Service.
   - Active **Application Insights** en ambos App Service: tiempos de respuesta, fallos y dependencias SQL sin tocar código. Para el video, muestre el panel *Rendimiento* después de navegar un rato.

---

## 7. Git: ramas y commits (¡requisito para tener nota!)

Cada integrante debe tener **más de 10 commits con lógica**. **No suban todo en un solo commit**: construyan el repositorio por partes siguiendo este plan.

**Ramas:** `main` (lo que se entrega) ← `develop` (integración) ← `feature/<nombre>` (una por tarea). Cada feature se une a `develop` con *Pull Request*; al final `develop` → `main`.

```bash
git checkout develop
git checkout -b feature/productos
# ... agregar archivos de la entidad, compilar, probar ...
git add . && git commit -m "Productos: entidad, repositorio y validaciones"
git push -u origin feature/productos   # y crear el Pull Request a develop
```

**Reparto sugerido** (un commit por paso = 2-4 commits por entidad → más de 10 cada uno):

| Integrante | Base (primero) | Entidades |
|---|---|---|
| Samuel | Solución, `EntidadBase`, `AplicacionBase`, `Conexion` + auditoría, `ControladorBase`, Script.sql | Roles, Permisos, RolesPermisos, Usuarios (login/sesión), Auditorías, Sucursales, Empleados, Clientes |
| Mathiu | `PresentacionBase`, `Comunicaciones`, `VentanaBase`, `PaginaSegura`, layout y CSS | Categorías, Marcas, Productos (imágenes), Reseñas, Inventarios, Proveedores, ComprasProductos, DetallesOrdenesCompras |
| Juan David | Proyecto de pruebas, `Reportes` (PDF/Excel), Mapa, Factura | Promociones, Ventas, DetallesVentas, MetodosPago, Pagos, Devoluciones, Garantías, EmpresasPaqueteria, Envíos |

Por entidad, un buen ritmo de commits es: *entidad + repositorio* → *controlador API* → *presentación + ventana* → *prueba*.

---

## 8. Guion para el video de sustentación

1. SQL Server: mostrar las 25 tablas y el diagrama (2 min).
2. Visual Studio: las 5 capas y el recorrido de un Guardar (sección 3) (3 min).
3. Login con cada rol → el menú cambia según los permisos (2 min).
4. CRUD completo de Productos con imagen; buscar; error de validación (2 min).
5. Venta: crear venta → agregar detalles → ver que baja el inventario y se recalcula el total con promoción → imprimir factura (3 min).
6. Auditorías: mostrar los registros que dejó lo anterior (1 min).
7. Reportes PDF y Excel + mapa de sucursales + imprimir una factura (2 min).
8. API: `servicio_bytelab.http` o Postman llamando `Productos/Buscar` y `/salud` (1 min).
9. Pruebas unitarias en verde (1 min).
10. Publicación en IIS / nube + Application Insights (2 min).
11. Repositorio: ramas y commits de cada integrante (1 min).

---

## Notas
- `Clientes` ya no repite el nombre completo (en el diccionario de datos estaba marcado como "pendiente"): se toma del usuario asociado.
- `Envios` usa solo la llave foránea a `EmpresasPaqueteria` (antes tenía también el nombre de la transportadora en texto).
- `Sucursales` tiene `Latitud` y `Longitud` para el mapa.
- **Cómo funciona el mapa** (`Pages/Ventanas/Mapa.cshtml` y `.cs`): el `OnGet` pide las sucursales a la API y las convierte a JSON; en la página, Leaflet crea el mapa centrado en Medellín, carga el fondo de OpenStreetMap y pone un marcador por cada sucursal. Leaflet viene dentro del proyecto (`wwwroot/lib/leaflet`); solo el fondo del mapa necesita internet.
- El front usa Bootstrap estándar (el de la plantilla) con los colores de ByteLab en `site.css`.
