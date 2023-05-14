import { createRouter, createWebHistory } from "vue-router";
import MainLayout from "../layouts/MainLayout.vue";
import HomeView from "../views/HomeView.vue";
import VendorView from '../views/Vendor/VendorView.vue'
import AddVendor from '../views/Vendor/AddVendor.vue'
import LoginView from '../views/LoginView.vue'

const routes = [
  {
    path: "/",
    component: MainLayout,
    children: [
      {
        path: "",
        name: "home",
        component: HomeView,
      },
      {
        path: "/vendor",
        name: "vendor",
        component: VendorView,
      },
      {
        path: "/add-vendor",
        name: "add vendor",
        component: AddVendor,
      },
    ],
  },
  {
    path: "/login",
    name: "login",
    component: LoginView,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
