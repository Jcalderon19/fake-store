<template>
  <div>
    <h1>Actualizar productos</h1>
    <form>
      <label for="producto">Selecciona un producto:</label>
      <select id="producto" v-model="selectedId" @change="loadProduct">
        <option value="" disabled>Seleccione un producto</option>
        <option v-for="producto in productos" :key="producto.id" :value="producto.id">
          {{ producto.nombre }}
        </option>
      </select>
      <div v-if="selectedId">
        <input type="hidden" v-model="newproduct.id" />

        <label>Nombre:</label>
        <input type="text" v-model="newproduct.nombre" required />

        <label>Detalle:</label>
        <input type="text" v-model="newproduct.detalle" required />

        <label>Precio:</label>
        <input type="number" v-model="newproduct.precio" required />

        <label>Categoría:</label>
        <input type="text" v-model="newproduct.categoria" required />

        <button type="submit" @click="UpdateProduct">Actualizar</button>
      </div>

    </form>
  </div>
</template>

<script>
import api from "../services/api";

export default {
  data() {
    return {
      selectedId: "", 
      productos: [], 
      newproduct: {
        id: "",
        nombre: "",
        detalle: "",
        precio: 0,
        categoria: "",
      },
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
    loadProduct() {
      const producto = this.productos.find(p => p.id === this.selectedId);
      if (producto) {
        this.newproduct = { ...producto }; 
      }
    },
    async UpdateProduct() {
      if (!this.newproduct.id) {
        alert("Selecciona un producto primero.");
        return;
      }
      try {
        await api.UpdateProduct(this.newproduct);
        alert(response.message || "Se Actualizo el producto");
      } catch (error) {
        alert("No se pudo Actualizar el producto");
        console.error("Error Actualizando producto:", error);
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
  border-radius: 10px;
  width: 300px;
  height: 50px;
}
select{
  width: 300px;
  height: 50px;
  border-radius: 10px;
}
label{
  color: beige;
  margin: 10px;
  font-size: 20px;
}
button{
  border-radius: 10px;
  width: 100px;
  height: 50px;
}
</style>
