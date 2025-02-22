import { createRouter, createWebHistory } from 'vue-router';
import Productos from '../views/Productos.vue';
import AgregarProducto from '../views/AgregarProdcuto.vue'; 
import DetalleProducto from '../views/DetalleProducto.vue';
import ActualizarProductos from '../views/ActualizarProductos.vue';
import EliminarProductos from '../views/EliminarProductos.vue';

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
  },
  {
    path:'/detalle/:nombre',
    component:DetalleProducto,
    props: true
  },
  {
    path:'/actualizar',
    component:ActualizarProductos,
    props: true
  },
  {
    path:'/eliminar',
    component:EliminarProductos,
    props: true
  }  
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;
