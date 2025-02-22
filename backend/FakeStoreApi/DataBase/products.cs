using Microsoft.Data.SqlClient;

public class ProductsDatabase
{
    public List<Producto> GetProducts()
    {
        try
        {

            using (SqlConnection connection = new SqlConnection("Server=localhost;Database=FakeStore;Trusted_Connection=True;TrustServerCertificate=True"))
            {
                connection.Open();
                string query = "SELECT * FROM Producto";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                List<Producto> products = new List<Producto>();

                while (reader.Read())
                {
                    products.Add(new Producto
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Detalle = reader.GetString(2),
                        Precio = reader.GetInt32(3),
                        Categoria = reader.GetString(4),
                    });
                }

                connection.Close();
                return products;

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }
    public List<Producto> GetByName(string name)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection("Server=localhost;Database=FakeStore;Trusted_Connection=True;TrustServerCertificate=True"))
            {
                connection.Open();
                string query = "SELECT * FROM Producto WHERE Nombre = @nombre";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", name);
                SqlDataReader reader = command.ExecuteReader();
                List<Producto> products = new List<Producto>();

                while (reader.Read())
                {
                    products.Add(new Producto
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Detalle = reader.GetString(2),
                        Precio = reader.GetInt32(3),
                        Categoria = reader.GetString(4),
                    });
                }

                connection.Close();
                return products;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public List<Producto> GetByCategory(string category)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection("Server=localhost;Database=FakeStore;Trusted_Connection=True;TrustServerCertificate=True"))
            {
                string query = "SELECT * FROM Producto WHERE Categoria = @categoria";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@categoria", category);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                List<Producto> products = new List<Producto>();

                while (reader.Read())
                {
                    products.Add(new Producto
                    {
                        Nombre = reader.GetString(1),
                        Detalle = reader.GetString(2),
                        Precio = reader.GetInt32(3),
                        Categoria = reader.GetString(4),
                    });
                }

                connection.Close();
                return products;
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en GetByCategory{ex.Message}");
            throw;
        }
    }

    public static bool IsExist(Producto product)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection("Server=localhost;Database=FakeStore;Trusted_Connection=True;TrustServerCertificate=True"))
            {
                connection.Open();
                string verificarQuery = "SELECT COUNT(1) FROM Producto WHERE Nombre = @Nombre";

                using (SqlCommand command = new SqlCommand(verificarQuery, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", product.Nombre);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al verificar producto: {ex.Message}");
            throw new Exception("Ocurrió un error al verificar la existencia del producto.", ex);
        }
    }

    public void CreateProduct(Producto product)
    {
        try
        {
            if (IsExist(product))
            {
                throw new Exception("El producto ya existe en la base de datos.");
            }

            using (SqlConnection connection = new SqlConnection("Server=localhost;Database=FakeStore;Trusted_Connection=True;TrustServerCertificate=True"))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Producto (Nombre, Detalle, Precio, Categoria) VALUES (@Nombre, @Detalle, @Precio, @Categoria)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", product.Nombre);
                    command.Parameters.AddWithValue("@Detalle", product.Detalle);
                    command.Parameters.AddWithValue("@Precio", product.Precio);
                    command.Parameters.AddWithValue("@Categoria", product.Categoria);

                    int filasAfectadas = command.ExecuteNonQuery();
                    if (filasAfectadas == 0)
                    {
                        throw new Exception("No se pudo insertar el producto.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en CreateProduct: {ex.Message}");
            throw;
        }
    }

    public List<string> CreateProducts(List<Producto> products)
    {
        List<string> errores = new List<string>();

        foreach (var producto in products)
        {
            try
            {
                CreateProduct(producto);
            }
            catch (Exception ex)
            {
                errores.Add($"No se pudo agregar '{producto.Nombre}': {ex.Message}");
            }
        }

        return errores;
    }

    public void UpdateProduct(Producto product)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection("Server=localhost;Database=FakeStore;Trusted_Connection=True;TrustServerCertificate=True"))
            {
                connection.Open();
                string updateQuery = "UPDATE Producto SET Nombre = @Nombre, Detalle = @Detalle, Precio = @Precio, Categoria = @Categoria WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", product.Id);
                    command.Parameters.AddWithValue("@Nombre", product.Nombre);
                    command.Parameters.AddWithValue("@Detalle", product.Detalle);
                    command.Parameters.AddWithValue("@Precio", product.Precio);
                    command.Parameters.AddWithValue("@Categoria", product.Categoria);

                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas == 0)
                    {
                        throw new Exception("No se pudo actualizar el producto, es posible que no exista.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en UpdateProduct: {ex.Message}");
            throw;
        }
    }

    public void DeleteProduct(string id)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection("Server=localhost;Database=FakeStore;Trusted_Connection=True;TrustServerCertificate=True"))
            {
                connection.Open();
                string query = "DELETE FROM Producto WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas == 0)
                    {
                        throw new Exception("No se pudo eliminar el producto, es posible que no exista.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en DeleteProduct: {ex.Message}");
            throw;
        }
    }

}