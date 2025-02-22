const API_URL = "http://localhost:5291/api/products";

export default {
  
  async GetProductos() {
    const response = await fetch(`${API_URL}`);
    return response.json();
  },

  async ProductByCategory(category) {
    const response = await fetch(`${API_URL}/category/${category}`, {
      method: "GET",
      headers: { "Content-Type": "application/json" },
    });
    return response.json();
  },

  async ProductsByName(name) {
    const response = await fetch(`${API_URL}/name/${name}`, {
      method: "GET",
      headers: { "Content-Type": "application/json" },
    });
    return response.json();
  },

  async CreateProduct(producto) {
    const response = await fetch(`${API_URL}`, {
      method: "POST",
      body: JSON.stringify(producto),
      headers: { "Content-Type": "application/json" },
    });
    return response.json();
  },

  async CreateProducts(products) {
    const response = await fetch(`${API_URL}/masive`, {  
      method: "POST",
      body: JSON.stringify(products),
      headers: { "Content-Type": "application/json" },
    });
    return response.json();
  },

  async UpdateProduct(producto) {
    const response = await fetch(`${API_URL}/${producto.id}`, {
      method: "PUT",
      body: JSON.stringify(producto),
      headers: { "Content-Type": "application/json" },
    });
    return response.json();
  },

  async DeleteProduct(id) {
    const response = await fetch(`${API_URL}/${id}`, {
      method: "DELETE",
      headers: { "Content-Type": "application/json" },
    });
    return response.json();
  }
};
