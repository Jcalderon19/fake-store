using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

[ApiController]
[Route("FakeApi")]
public class FakeStoreController : ControllerBase
{
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