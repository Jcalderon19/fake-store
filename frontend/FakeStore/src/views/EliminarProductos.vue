<template>
  <div>
    <h1>Eliminar Productos</h1>
    <form>
      <label for="producto">Selecciona un producto:</label>
      <select id="producto" v-model="id">
        <option value="" disabled>Seleccione un producto</option>
        <option v-for="producto in productos" :key="producto.id" :value="producto.id">
          {{ producto.nombre }}
        </option>
      </select>
      <button type="submit" @click="deleteProduct">Eliminar</button>
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
    deleteProduct(){
      try {
         api.DeleteProduct(this.id);  
       alert(response.message || "Se elimino el producto");
      } catch (error) {
        alert("No se pudo eliminar el producto");
        console.error("Error eliminar producto:", error);
      }
    },
  },
};
</script>

<style scoped>
h1{
  color: beige;
}
select, button {
  display: block;
  margin-bottom: 10px;
}
label{
  color: beige;
}
</style>
