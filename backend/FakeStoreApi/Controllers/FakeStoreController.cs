using Microsoft.AspNetCore.Mvc;

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


    [HttpGet("category/{category}")]
    public IActionResult ProductByCategory(string category)
    {
        ProductsDatabase productsDatabase = new ProductsDatabase();
        List<Producto> productByCategory = new List<Producto>();
        try
        {
            productByCategory = productsDatabase.GetByCategory(category);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error en el servidor: " + ex.Message);
        }
        return Ok(productByCategory);
    }


    [HttpGet("name/{name}")]
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
            return StatusCode(500, ex.Message);
        }
        return Ok(new { message = "Producto insertado correctamente" });
    }


    [HttpPost("masive")]
    public IActionResult CreateProducts([FromBody] List<Producto> products)
    {
        if (products == null || products.Count == 0)
        {
            return BadRequest("La lista de productos está vacía.");
        }

        ProductsDatabase productsDatabase = new ProductsDatabase();
        List<string> errores = productsDatabase.CreateProducts(products); 

        if (errores.Count == 0)
        {
            return Ok("Todos los productos fueron insertados correctamente.");
        }

        return StatusCode(207, new
        {
            Mensaje = "Algunos productos no se insertaron correctamente.",
            Errores = errores
        });
    }


    [HttpPut("{id}")]
    public IActionResult UpdateProduct([FromBody] Producto product)
    {
        ProductsDatabase productsDatabase = new ProductsDatabase();
        try
        {
            productsDatabase.UpdateProduct(product);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error en el servidor: " + ex.Message);
        }
        return Ok(new { message = "Producto actualizado correctamente" });
    }


    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(string id)
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
        return Ok(new { message = "Producto eliminado correctamente" });;
    }
}