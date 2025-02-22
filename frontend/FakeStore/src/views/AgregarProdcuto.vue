<template>
  <div>
    <h1>Agregar Producto</h1>
    <form>
      <label>Nombre:</label>
      <input type="text" v-model="newproduct.Nombre" required />

      <label>Detalle </label>
      <input type="text" v-model="newproduct.Detalle" required />

      <label>Precio</label>
      <input type="number" v-model="newproduct.Precio" required />

      <label>Categoria</label>
      <input type="text" v-model="newproduct.Categoria" required />

      <button type="submit" @click="agregarProducto">Agregar</button>
    </form>
  </div>
</template>

<script>
import api from "../services/api";

export default {
  data() {
    return {
      newproduct: {
        Nombre: "",
        Detalle: "",
        Precio: 0,
        Categoria: "",
      },
    };
  },
  methods: {
    async agregarProducto() {
      try {
        const response = await api.CreateProduct(this.newproduct);
        alert(response.message || "Se agregó el producto");
      } catch (error) {
        alert("No se pudo crear el producto");
        console.error("Error agregando producto:", error);
      }
    },
  },
};
</script>

<style scoped>
h1{
  color: beige;
}
input {
  display: block;
  margin-bottom: 10px;
}
label{
  color: beige;
}
</style>
