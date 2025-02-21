using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

[ApiController]
[Route("FakeApi")]
public class FakeStoreController : ControllerBase
{
    /// <summary>
    /// Metodo para obtener todos los productos
    /// </summary>
    /// <returns></returns>
    [HttpGet("ObtenerPoductos")]
    public IActionResult ObtenerTodoslosProductos()
    {
        try
        {

            using (SqlConnection conexion = new SqlConnection("Server=localhost;Database=FakeStore;Trusted_Connection=True;TrustServerCertificate=True"))
            {
                string query = "SELECT * FROM Producto";
                SqlCommand comando = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader reader = comando.ExecuteReader();
                List<Producto> productos = new List<Producto>();

                while (reader.Read())
                {
                    productos.Add(new Producto
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Detalle = reader.GetString(2),
                        Precio = reader.GetInt32(3),
                        Categoria = reader.GetString(4),
                    });
                }

                conexion.Close();
                return Ok(productos);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error en el servidor: " + ex.Message);
        }
    }
   
    /// <summary>
    /// Medoto para Consultar producto por categoria
    /// </summary>
    /// <param name="categoria"></param>
    /// <returns></returns>
    [HttpGet("ConsultarCategoria")]
    public IActionResult ConsultarProductoCategoria([FromQuery] string categoria)
    {
        try
        {
            using (SqlConnection conexion = new SqlConnection("Server=localhost;Database=FakeStore;Trusted_Connection=True;TrustServerCertificate=True"))
            {
                string query = "SELECT * FROM Producto WHERE Categoria = @categoria";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@categoria", categoria);
                conexion.Open();

                SqlDataReader reader = comando.ExecuteReader();
                List<Producto> productos = new List<Producto>();

                while (reader.Read())
                {
                    productos.Add(new Producto
                    {
                        Nombre = reader.GetString(1),
                        Detalle = reader.GetString(2),
                        Precio = reader.GetInt32(3),
                        Categoria = reader.GetString(4),
                    });
                }

                conexion.Close();
                return Ok(productos);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error en el servidor: " + ex.Message);
        }
    }

    /// <summary>
    /// Consultar producto por nombre
    /// </summary>
    /// <param name="nombre"></param>
    /// <returns></returns>
    [HttpGet("ConsultarProdcuto")]
    public IActionResult ConsultarProducto([FromQuery] string nombre)
    {
        try
        {
            using (SqlConnection conexion = new SqlConnection("Server=localhost;Database=FakeStore;Trusted_Connection=True;TrustServerCertificate=True"))
            {
                string query = "SELECT * FROM Producto WHERE Nombre = @nombre";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@nombre", nombre);
                conexion.Open();

                SqlDataReader reader = comando.ExecuteReader();
                List<Producto> productos = new List<Producto>();

                while (reader.Read())
                {
                    productos.Add(new Producto
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Detalle = reader.GetString(2),
                        Precio = reader.GetInt32(3),
                        Categoria = reader.GetString(4),
                    });
                }

                conexion.Close();
                return Ok(productos);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error en el servidor: " + ex.Message);
        }
    }

    /// <summary>
    /// Crear productos unitarios
    /// </summary>
    /// <param name="producto"></param>
    /// <returns></returns>
    [HttpPost("CrearProductos")]
    public IActionResult InsertarProducto([FromBody] Producto producto)
    {
        try
        {
            using (SqlConnection conexion = new SqlConnection("Server=localhost;Database=FakeStore;Trusted_Connection=True;TrustServerCertificate=True"))
            {
                conexion.Open();
                string verificarQuery = "SELECT COUNT(*) FROM Producto WHERE Nombre = @Nombre";
                SqlCommand verificarComando = new SqlCommand(verificarQuery, conexion);
                verificarComando.Parameters.AddWithValue("@Nombre", producto.Nombre);

                int count = (int)verificarComando.ExecuteScalar();
                if (count > 0)
                {
                    return BadRequest("El producto ya existe.");
                }

                string insertQuery = "INSERT INTO Producto (Nombre, Detalle, Precio, Categoria) VALUES (@Nombre, @Detalle, @Precio, @Categoria)";
                SqlCommand insertComando = new SqlCommand(insertQuery, conexion);
                insertComando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                insertComando.Parameters.AddWithValue("@Detalle", producto.Detalle);
                insertComando.Parameters.AddWithValue("@Precio", producto.Precio);
                insertComando.Parameters.AddWithValue("@Categoria", producto.Categoria);

                int filasAfectadas = insertComando.ExecuteNonQuery();
                return filasAfectadas > 0 ? Ok("Producto agregado correctamente.") : StatusCode(500, "No se pudo insertar el producto.");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error en el servidor: " + ex.Message);
        }
    }

    /// <summary>
    /// Crear productos masivos
    /// </summary>
    /// <param name="productos"></param>
    /// <returns></returns>
    [HttpPost("CrearProductosMasivos")]
    public IActionResult InsertarProductosMasivos([FromBody] List<Producto> productos)
    {
        if (productos == null || productos.Count == 0)
        {
            return BadRequest("La lista de productos está vacía.");
        }

        try
        {
            using (SqlConnection conexion = new SqlConnection("Server=localhost;Database=FakeStore;Trusted_Connection=True;TrustServerCertificate=True"))
            {
                conexion.Open();

                using (SqlTransaction transaction = conexion.BeginTransaction())
                {
                    try
                    {
                        foreach (var producto in productos)
                        {
                            string verificarQuery = "SELECT COUNT(*) FROM Producto WHERE Nombre = @Nombre";
                            SqlCommand verificarComando = new SqlCommand(verificarQuery, conexion, transaction);
                            verificarComando.Parameters.AddWithValue("@Nombre", producto.Nombre);

                            int count = (int)verificarComando.ExecuteScalar();
                            if (count > 0)
                            {
                                return BadRequest($"El producto '{producto.Nombre}' ya existe.");
                            }

                            string insertQuery = "INSERT INTO Producto (Nombre, Detalle, Precio, Categoria) VALUES (@Nombre, @Detalle, @Precio, @Categoria)";
                            SqlCommand insertComando = new SqlCommand(insertQuery, conexion, transaction);
                            insertComando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                            insertComando.Parameters.AddWithValue("@Detalle", producto.Detalle);
                            insertComando.Parameters.AddWithValue("@Precio", producto.Precio);
                            insertComando.Parameters.AddWithValue("@Categoria", producto.Categoria);

                            insertComando.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return Ok("Productos agregados correctamente.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return StatusCode(500, "Error al insertar productos: " + ex.Message);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error en el servidor: " + ex.Message);
        }
    }

    /// <summary>
    /// Actualizar productos
    /// </summary>
    /// <param name="producto"></param>
    /// <returns></returns>
    [HttpPut("ActualizarProducto")]
    public IActionResult ActualizarProductos([FromBody] Producto producto)
    {
        try
        {
            using (SqlConnection conexion = new SqlConnection("Server=localhost;Database=FakeStore;Trusted_Connection=True;TrustServerCertificate=True"))
            {
                conexion.Open();
                string insertQuery = "UPDATE Producto SET Nombre = @Nombre, Detalle = @Detalle, Precio = @Precio, Categoria = @Categoria WHERE Id = @id";
                SqlCommand insertComando = new SqlCommand(insertQuery, conexion);
                insertComando.Parameters.AddWithValue("@id", producto.Id);
                insertComando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                insertComando.Parameters.AddWithValue("@Detalle", producto.Detalle);
                insertComando.Parameters.AddWithValue("@Precio", producto.Precio);
                insertComando.Parameters.AddWithValue("@Categoria", producto.Categoria);

                int filasAfectadas = insertComando.ExecuteNonQuery();
                return filasAfectadas > 0 ? Ok("Producto actualizado correctamente.") : StatusCode(500, "No se pudo actualizar el producto.");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error en el servidor: " + ex.Message);
        }
    }

    /// <summary>
    /// Eliminar productos 
    /// </summary>
    /// <param name="nombre"></param>
    /// <returns></returns>
    [HttpDelete("EliminarProductos")]
    public IActionResult BorrarProductos([FromQuery] string nombre)
    {
        try
        {
            using (SqlConnection conexion = new SqlConnection("Server=localhost;Database=FakeStore;Trusted_Connection=True;TrustServerCertificate=True"))
            {
                string query = "DELETE FROM Producto WHERE Nombre = @nombre";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@nombre", nombre);

                conexion.Open();
                int filasAfectadas = comando.ExecuteNonQuery();
                conexion.Close();

                if (filasAfectadas > 0)
                    return Ok("Producto eliminado Correctamente");
                else
                    return BadRequest("No se encontro el el producto a eliminar");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error en el servidor: " + ex.Message);
        }
    }
}