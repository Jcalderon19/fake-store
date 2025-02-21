using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

[ApiController]
[Route("api/products")]
public class FakeStoreController : ControllerBase
{

    [HttpGet]
    public IActionResult Products()
    {
        ProductsDatabase productsDatabase = new ProductsDatabase();
        List<Producto> allProduct = new List<Producto>();
        try
        {
            allProduct = productsDatabase.GetProducts();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
        return Ok(allProduct);
    }


    [HttpGet("category/{Categoria}")]
    public IActionResult ProductByCategory([FromQuery] string category)
    {
        ProductsDatabase productsDatabase = new ProductsDatabase();
        List<Producto> productByCategory = new List<Producto>();
        try
        {
           productByCategory =productsDatabase.GetByCategory(category);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error en el servidor: " + ex.Message);
        }
        return Ok(productByCategory);
    }


    [HttpGet("name/{Nombre}")]
    public IActionResult ProductsByName(string name)
    {
        ProductsDatabase productsDatabase = new ProductsDatabase();
        List<Producto> productosByName = new List<Producto>();
        try
        {
            productosByName = productsDatabase.GetByName(name);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
        return Ok(productosByName);
    }


    [HttpPost]
    public IActionResult CreateProduct([FromBody] Producto product)
    {
        ProductsDatabase productsDatabase = new ProductsDatabase();
        try
        {
            productsDatabase.CreateProduct(product);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
        return Ok("Producto insertado correctamente");
    }


    [HttpPost("masive")]
    public IActionResult CreateProducts([FromBody] List<Producto> products)
    {
        if (products == null || products.Count == 0)
        {
            return BadRequest("La lista de productos está vacía.");
        }
         ProductsDatabase productsDatabase = new ProductsDatabase();
        try
        {
            productsDatabase.CreateProducts(products);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error en el servidor: " + ex.Message);
        }
         return Ok("Productos insertados correctamente");
    }


    [HttpPut("{id}")]
    public IActionResult ActualizarProductos([FromBody] Producto producto)
    {
         ProductsDatabase productsDatabase = new ProductsDatabase();
        try
        {
            productsDatabase.UpdateProduct(producto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error en el servidor: " + ex.Message);
        }
        return Ok("Producto actualizado");
    }


    [HttpDelete("{id}")]
    public IActionResult BorrarProductos([FromRoute] string id)
    {
        ProductsDatabase productsDatabase = new ProductsDatabase();
        try
        {
           productsDatabase.DeleteProduct(id);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error en el servidor: " + ex.Message);
        }
         return Ok("Productos eliminado Correctamente");
    }
}