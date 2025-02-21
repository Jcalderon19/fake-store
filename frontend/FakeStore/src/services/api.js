const API_URL = "http://localhost:5291/FakeApi";

export default {
  sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
},
  async getProductos() {
    const response = await fetch(`${API_URL}/ObtenerPoductos`);
    return response.json();
  },
  async consultarProducto(){
    const response = await fetch(`${API_URL}/CrearProductos`, {
      method: "",
      body: JSON.stringify(producto),
      headers: { "Content-Type": "application/json" },
    });
    return response.json();
  },

  async addProducto(producto) {
    const response = await fetch(`${API_URL}/CrearProductos`, {
      method: "POST",
      body: JSON.stringify(producto),
      headers: { "Content-Type": "application/json" },
    });
    return response.json();
  },

  async addProducto(producto) {
    const response = await fetch(`${API_URL}/CrearProductosMasivos`, {
      method: "POST",
      body: JSON.stringify(producto),
      headers: { "Content-Type": "application/json" },
    });
    return response.json();
  },


  async updateProducto(id, producto) {
    const response = await fetch(`${API_URL}/ActualizarProducto`, {
      method: "PUT",
      body: JSON.stringify({ id, ...producto }),
      headers: { "Content-Type": "application/json" },
    });
    return response.json();
  },

  async deleteProducto(id) {
    const response = await fetch(`${API_URL}/EliminarProductos`, {
      method: "DELETE",
      body: JSON.stringify({ id }),
      headers: { "Content-Type": "application/json" },
    });
    return response.json();
  }
};