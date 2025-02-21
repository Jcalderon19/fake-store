<template>
  <div id="app">
    <header>
      <h1>FakeStore</h1>
      <nav>
        <router-link to="/">Inicio</router-link>
        <router-link to="/productos">Productos</router-link>
        <router-link to="/agregar">Gestion de productos</router-link>
      </nav>
    </header>
    <main>
      <router-view></router-view>
    </main>
  </div>
</template>

<script>
export default {
  name: "App",
};
</script>

<style scoped>
/* Estilos generales */
#app {
  font-family: Arial, sans-serif;
  text-align: center;
  margin: 0;
  padding: 0;
}

/* Estilos del encabezado */
header {
  background: #333;
  color: white;
  padding: 15px;
}

/* Estilos de la navegación */
nav {
  display: flex;
  justify-content: center;
  gap: 20px;
  margin-top: 10px;
}

nav a {
  color: white;
  text-decoration: none;
  font-weight: bold;
  padding: 8px 12px;
  border-radius: 5px;
  transition: background 0.3s;
}

nav a:hover {
  background: #555;
}
</style>
