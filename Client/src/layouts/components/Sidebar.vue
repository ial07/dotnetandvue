<template>
    <aside class="main-sidebar sidebar-dark-primary elevation-4">

        <a href="/" class="brand-link">
            <img src="/adminlte/dist/img/AdminLTELogo.png" :alt="$store.state.app.name"
                class="brand-image img-circle elevation-3" style="opacity: .8">
            <span class="brand-text font-weight-light">{{ $store.state.app.name }}</span>
        </a>

        <div class="sidebar">

            <div class="user-panel mt-3 pb-3 mb-3 d-flex">
                <div class="image">
                    <img src="/adminlte/dist/img/user2-160x160.jpg" class="img-circle elevation-2" alt="User Image">
                </div>
                <div class="info">
                    <a href="#" class="d-block">{{ name }}</a>
                </div>
            </div>


            <nav class="mt-2">
                <ul class="nav nav-pills nav-sidebar flex-column" data-widget="treeview" role="menu" data-accordion="false">
                    <nav-item icon="fas fa-home" link="/">
                        Home
                    </nav-item>
                    <nav-item icon="fas fa-info-circle" link="/vendor">
                        Vendor
                    </nav-item>
                </ul>
            </nav>

        </div>

    </aside>
</template>

<script>
import NavItem from './NavItem.vue'
export default {
     data() {
        return {
            name: '',
        };
    },
    mounted() {
        const data = JSON.parse(localStorage.getItem('token'));
        this.name = data["userName"];
    },
    components: {
        NavItem
    },
       
    
}
</script>