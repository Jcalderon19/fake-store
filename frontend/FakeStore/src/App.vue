<template>
  <div id="app">
    <header>
      <h1>FakeStore</h1>
      <nav>
        <router-link to="/">Inicio</router-link>
        <router-link to="/productos">Productos</router-link>
        <router-link to="/agregar">Agregar de productos</router-link>
        <router-link to="/actualizar">Actualizar de productos</router-link>
        <router-link to="/eliminar">Eliminar de productos</router-link>
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

header {
  text-align: center;
  background: #333;
  color: white;
  padding: 15px;
  font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
}

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
main{
 display: flex;
 justify-content: center;
 background-color: #222;
 font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
}
</style>
