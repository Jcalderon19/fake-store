<template>
  <div>
    <h1>Agregar Producto</h1>
    <form>
      <label>Nombre:</label>
      <input type="text" v-model="nuevoProducto.title" required />

      <label>Precio:</label>
      <input type="number" v-model="nuevoProducto.price" required />

      <label>Imagen (URL):</label>
      <input type="text" v-model="nuevoProducto.image" required />

      <button type="submit" @click="agregarProducto">Agregar</button>
    </form>
  </div>
</template>

<script>
import api from "../services/api";

export default {
  data() {
    return {
      nuevoProducto: {
        title: "",
        price: 0,
        image: "",
      },
    };
  },
  methods: {
    async agregarProducto() {
      try {
        await api.addProducto(this.nuevoProducto);
        alert("Producto agregado con éxito");
      this.$router.push('/productos'); 
      } catch (error) {
        console.error("Error agregando producto:", error);
      }
    },
  },
};
</script>

<style scoped>
input {
  display: block;
  margin-bottom: 10px;
}
</style>
