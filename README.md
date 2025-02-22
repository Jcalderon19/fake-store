# Fake-Store

## Descripción
Fake-Store es una aplicación construida con Vue.js para el frontend y C# (.NET) para la API, utilizando SQL Server como base de datos.

### Características:
- Listado de productos con paginación.
- Filtros de búsqueda por nombre y categoría.
- Vistas para agregar, eliminar y actualizar productos.
- Vista de detalles del producto al hacer clic en uno.

## Tecnologías Utilizadas
- Vue 3
- JavaScript
- .NET 8
- SQL Server
- HTML
- CSS

## Instalación y Configuración
### Prerrequisitos
Asegúrate de tener instalado lo siguiente:
- [Node.js](https://nodejs.org/)
- [.NET 8](https://dotnet.microsoft.com/)
- SQL Server con el puerto TCP habilitado para permitir la conexión.

### Instalación
1. Clona el repositorio:
   ```sh
   git clone https://github.com/usuario/fake-store.git
   ```
2. Accede al directorio del proyecto y configura las dependencias:
   - **Frontend:**
     ```sh
     cd frontend
     npm install
     ```
   - **Backend:**
     ```sh
     cd backend
     dotnet build
     ```
3. Configura las cadenas de conexión en el backend según tu entorno (local o en servicio).

## Ejecución
- **Frontend:**
  ```sh
  npm run dev
  ```
- **Backend:**
  ```sh
  dotnet run
  ```

## Estructura del Proyecto
```
fake-store/
│── frontend/
│   │── src/
│   │── public/
│   └── package.json
│── backend/
│   │── Controllers/
│   │── Models/
│   │── Services/
│   └── appsettings.json
└── README.md
```

## Uso
1. Inicia la API con `.NET run`.
2. Ejecuta el frontend con `npm run dev`.
3. Configura las cadenas de conexión en `appsettings.json`.
4. Accede a la aplicación desde el navegador.
5. Usa los filtros para buscar productos o accede a sus detalles.

## Endpoints de la API

-Obtener todos los productos

Método: GET
-URL: /api/products
-Descripción: Retorna una lista con todos los productos almacenados en la base de datos.

## Obtener productos por categoría

Método: GET
-URL: /api/products/category/{category}
-Parámetros: category (string) → Nombre de la categoría
-Descripción: Devuelve todos los productos que pertenecen a una categoría específica.

## Obtener productos por nombre

Método: GET
-URL: /api/products/name/{name}
-Parámetros: name (string) → Nombre del producto
-Descripción: Filtra y devuelve productos cuyo nombre coincide con el valor proporcionado.

## Crear un producto

Método: POST
-URL: /api/products
-Cuerpo: Objeto Producto en formato JSON
-Descripción: Agrega un nuevo producto a la base de datos.

## Crear múltiples productos

Método: POST
-URL: /api/products/masive
-Cuerpo: Lista de objetos Producto en formato JSON
-Descripción: Inserta varios productos a la vez en la base de datos. Si algunos fallan, devuelve un mensaje con los errores.

## Actualizar un producto

Método: PUT
-URL: /api/products/{id}
-Cuerpo: Objeto Producto en formato JSON
-Descripción: Modifica los datos de un producto existente en la base de datos.

## Eliminar un producto

Método: DELETE
-URL: /api/products/{id}
-Parámetros: id (string) → Identificador único del producto
-Descripción: Elimina un producto de la base de datos según su ID.

## Licencia
Este proyecto está bajo la licencia MIT.

