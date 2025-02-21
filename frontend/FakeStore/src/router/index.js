import { createRouter, createWebHistory } from 'vue-router';
import Productos from '../views/Productos.vue';
import AgregarProducto from '../views/AgregarProdcuto.vue'; // Importamos la nueva vista

const routes = [
  { 
    path: '/',
    redirect: '/productos' 
  },
  { 
    path: '/productos', 
    component: Productos 
  },
  { 
    path: '/agregar', 
    component: AgregarProducto 
  } // Nueva ruta para agregar productos
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;
