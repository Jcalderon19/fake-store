<template>
  <div class="container">
    <h1 class="title">Lista de Productos</h1>
    <div class="container-seachs">
      <label class="descripcion">Busca tus productos</label>
      <input placeholder="Coca-Cola" class="input-seach"></input>
      <label class="descripcion">Busca por categoria</label>
      <input placeholder="Bebidas" class="input-categoria"></input>
    </div>
    <div class="productos-grid">
      <div v-for="producto in productos" :key="producto.id" class="producto-card">
        <router-link to="/VerProducto/{{producto.id}}">
          {{producto.nombre}}
        </router-link>
        <p>{{ producto.detalle }}</p>
        <p><strong>Precio:</strong> ${{ producto.precio }}</p>
        <p><strong>Categoría:</strong> {{ producto.categoria }}</p>
      </div>
      
    </div>
  </div>
</template>

<script>
import api from "../services/api";

export default {
  data() {
    return {
      productos: [],
      loading:true
    };
  },
  async created() {
    try {
      this.productos = await api.getProductos();
    } catch (error) {
      console.error("Error cargando productos:", error);
    } finally {
      this.loading = false;
    }
  },
};
</script>

<style scoped>
.container {
  max-width: 1200px;
  margin: 0 auto;
  padding: 20px;
  background-color: #222;
}

/* Título */
.title {
  text-align: center;
  font-size: 24px;
  font-weight: bold;
  margin-bottom: 20px;
  color: beige;
}
.container-seachs{
  display: flex;
  flex-direction: initial;
  padding: 20px;
}
.descripcion{
  padding: 10px;
  color:beige;
  font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
  font-size: 20px;
}
.input-seach,.input-categoria{
  border-radius: 10px;
  font-family: system-ui;
  font-size: 20px;
}
/* Grid de productos */
.productos-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
  gap: 20px;
}

/* Tarjeta de producto */
.producto-card {
  background: #fff;
  border: 1px solid #ddd;
  border-radius: 10px;
  padding: 15px;
  box-shadow: 2px 2px 10px rgba(0, 0, 0, 0.1);
  transition: transform 0.2s ease, box-shadow 0.2s ease;
}

.producto-card:hover {
  transform: translateY(-5px);
  box-shadow: 4px 4px 15px rgba(0, 0, 0, 0.2);
}

h2 {
  font-size: 18px;
  font-weight: bold;
  margin-bottom: 10px;
}

p {
  font-size: 14px;
  margin: 5px 0;
}
</style>
