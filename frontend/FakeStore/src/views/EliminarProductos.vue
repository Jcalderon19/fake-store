<template>
  <div>
    <h1>Eliminar Productos</h1>
    <form @submit.prevent="DeleteProduct">
      <label for="producto">Selecciona un producto:</label>
      <select id="producto" v-model="id">
        <option value="" disabled>Seleccione un producto</option>
        <option v-for="producto in productos" :key="producto.id" :value="producto.id">
          {{ producto.nombre }}
        </option>
      </select>
      <button type="submit">Eliminar</button>
    </form>
  </div>
</template>

<script>
import api from "../services/api";

export default {
  data() {
    return {
      id: "",           
      productos: []     
    };
  },
  async created() {
    try {
      this.productos = await api.GetProductos(); 
    } catch (error) {
      console.error("Error cargando productos:", error);
    }
  },
  methods: {
    async DeleteProducto() {
      if (!this.id) {
        alert("Selecciona un producto antes de eliminar.");
        return;
      }

      try {
        await api.DeleteProduct(this.id);  
        alert("Producto Eliminado");
      } catch (error) {
        console.error("Error eliminando el producto:", error);
      }
    },
  },
};
</script>

<style scoped>
select, button {
  display: block;
  margin-bottom: 10px;
}
</style>
