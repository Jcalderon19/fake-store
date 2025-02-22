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

## Conexión con la API
Para interactuar con la API, puedes usar herramientas como Postman.
Si deseas agregar imágenes de Postman, súbelas a una carpeta dentro del proyecto y agrégalas en el README con:
```md
![Descripción de la imagen](ruta/imagen.png)
```

## Licencia
Este proyecto está bajo la licencia MIT.

