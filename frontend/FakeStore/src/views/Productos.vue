<template>
  <div class="container">
    <h1 class="title">Lista de Productos</h1>

    <div class="container-seachs">
      <label class="descripcion">Busca tus productos</label>
      <input 
        placeholder="Coca-Cola" 
        class="input-seach" 
        v-model="nombre"
        @input="buscarPorNombre"
      />

      <label class="descripcion">Busca por categoría</label>
      <input 
        placeholder="Bebidas" 
        class="input-categoria" 
        v-model="categoria"
        @input="buscarPorCategoria"
      />
    </div>

    <div class="productos-grid">
      <div
        v-for="producto in productosPaginados"
        :key="producto.id"
        class="producto-card"
      >
        <router-link
          class="Name-Product" :to="`/detalle/${encodeURIComponent(producto.nombre)}`">
          {{ producto.nombre }}
        </router-link>
        <p><strong>Detalle: </strong>{{ producto.detalle }}</p>
        <p><strong>Precio:</strong> ${{ producto.precio }}</p>
        <p><strong>Categoría:</strong> {{ producto.categoria }}</p>
      </div>
    </div>

    <div class="pagination">
      <button @click="anteriorPagina" :disabled="paginaActual === 1">
        Anterior
      </button>
      <span>Página {{ paginaActual }} de {{ totalPaginas }}</span>
      <button @click="siguientePagina" :disabled="paginaActual === totalPaginas">
        Siguiente
      </button>
    </div>
  </div>
</template>

<script>
import api from "../services/api";

export default {
  data() {
    return {
      productos: [],
      nombre: "",
      categoria: "",
      paginaActual: 1,
      productosPorPagina: 5, 
    };
  },
  computed: {
    productosPaginados() {
      const inicio = (this.paginaActual - 1) * this.productosPorPagina;
      const fin = inicio + this.productosPorPagina;
      return this.productos.slice(inicio, fin);
    },
    totalPaginas() {
      return Math.ceil(this.productos.length / this.productosPorPagina);
    },
  },
  async created() {
    await this.cargarProductos();
  },
  methods: {
    async cargarProductos() {
      try {
        this.productos = await api.GetProductos();
        this.paginaActual = 1; 
      } catch (error) {
        console.error("Error cargando productos:", error);
      }
    },
    async buscarPorNombre() {
      if (this.nombre.trim() === "") {
        await this.cargarProductos();
        return;
      }
      try {
        this.productos = await api.ProductsByName(this.nombre);
        this.paginaActual = 1;
      } catch (error) {
        console.error("Error buscando por nombre:", error);
      }
    },
    async buscarPorCategoria() {
      if (this.categoria.trim() === "") {
        await this.cargarProductos();
        return;
      }
      try {
        this.productos = await api.ProductByCategory(this.categoria);
        this.paginaActual = 1;
      } catch (error) {
        console.error("Error buscando por categoría:", error);
      }
    },
    anteriorPagina() {
      if (this.paginaActual > 1) {
        this.paginaActual--;
      }
    },
    siguientePagina() {
      if (this.paginaActual < this.totalPaginas) {
        this.paginaActual++;
      }
    },
  },
};
</script>

<style scoped>
.container {
  max-width: 1200px;
  margin: 0 auto;
  padding: 20px;
}

.title {
  text-align: center;
  font-size: 24px;
  font-weight: bold;
  margin-bottom: 20px;
  color: beige;
}
.container-seachs {
  display: flex;
  flex-direction: initial;
  padding: 20px;
}
.descripcion {
  padding: 10px;
  color: beige;
  font-family: "Franklin Gothic Medium", "Arial Narrow", Arial, sans-serif;
  font-size: 20px;
}
.input-seach,
.input-categoria {
  border-radius: 10px;
  font-family: system-ui;
  font-size: 20px;
}

.productos-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
  gap: 20px;
}

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
.Name-Product {
  text-decoration: none;
  font-family: "Franklin Gothic Medium", "Arial Narrow", Arial, sans-serif;
  font-size: 20px;
  color: #222;
}
p {
  font-size: 14px;
  margin: 5px 0;
}
.pagination {
  display: flex;
  justify-content: center;
  align-items: center;
  margin-top: 20px;
}

.pagination button {
  background-color: #4caf50;
  color: white;
  border: none;
  padding: 10px 15px;
  margin: 0 5px;
  cursor: pointer;
  border-radius: 5px;
  font-size: 16px;
}

.pagination button:disabled {
  background-color: #ccc;
  cursor: not-allowed;
}
</style>