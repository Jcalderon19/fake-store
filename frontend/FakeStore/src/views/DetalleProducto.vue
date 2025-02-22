<template>
  <div class="container-detail">
    <h1 class="Title-detail">{{ producto.nombre }}</h1>
    <img class="img-product" src="https://plus.unsplash.com/premium_photo-1710965560034-778eedc929ff?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8bXVuZG8lMjBoZXJtb3NvfGVufDB8fDB8fHww" alt="imagende la cocacola">
    <div class="container-descripcion">
      <p>{{ producto.detalle }}</p>
      <p><strong>Precio:</strong> ${{ producto.precio }}</p>
      <p><strong>Categoría:</strong> {{ producto.categoria }}</p>
    </div>
  </div>
</template>

<script>
import api from "../services/api";

export default {
  data() {
    return {
      producto: {} 
    };
  },
  async created() {
     try {
      const nombreProducto = this.$route.params.nombre;
      const productos = await api.ProductsByName(nombreProducto);
      this.producto = productos.length > 0 ? productos[0] : null; 
    } catch (error) {
      console.error("Error cargando producto:", error);
    }
  }
};
</script>

<style scoped>
.container-detail{
  background-color:beige;
  margin: 20px;
  border-radius: 40px;
  display: flex;
  justify-content: flex-start;
  flex-direction: column;
  align-items: center;
  width: 70vw;
  height: 100vh;
}
.Title-detail {
  color: rgba(47, 161, 66, 0.678);
  margin: 10px;
}
.img-product{
  width: 300px;
  height: 300px;
  border-radius: 10px;
}
p{
  font-size: 30px;
  color: rgba(47, 161, 66, 0.678);
}
</style>
