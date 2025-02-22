<template>
  <div class="container-detail">
    <h1 class="Title-detail">{{ producto.nombre }}</h1>
    <div class="image-container">
      <img
        class="img-product-visible"
        src="https://r-charts.com/es/miscelanea/procesamiento-imagenes-magick_files/figure-html/color-fondo-imagen-r.png"
        alt="imagen del producto"
      />
      <img
        class="img-product"
        src="https://plus.unsplash.com/premium_photo-1710965560034-778eedc929ff?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8bXVuZG8lMjBoZXJtb3NvfGVufDB8fDB8fHww"
        alt="imagen del producto"
      />
    </div>
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
      producto: {},
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
  },
};
</script>

<style scoped>
.container-detail {
  background-color: beige;
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
.img-product,
.img-product-visble {
  width: 300px;
  height: 300px;
  border-radius: 10px;
}
p {
  font-size: 30px;
  color: rgba(47, 161, 66, 0.678);
}
.image-container {
  position: relative;
  width: 300px;
  height: 300px;
}

.img-product,
.img-product-visible {
  width: 100%;
  height: 100%;
  border-radius: 10px;
  position: absolute;
  transition: opacity 0.3s ease-in-out;
}

/* Imagen que se muestra primero */
.img-product-visible {
  opacity: 1;
  visibility: visible;
}

/* Imagen oculta por defecto */
.img-product {
  opacity: 0;
  visibility: hidden;
}

/* Cuando el usuario pasa el mouse sobre el contenedor */
.image-container:hover .img-product-visible {
  opacity: 0;
  visibility: hidden;
}

.image-container:hover .img-product {
  opacity: 1;
  visibility: visible;
}
</style>
