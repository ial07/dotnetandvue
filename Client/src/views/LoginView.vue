<template>
    <div class="login-box">
        <div class="login-logo">
            <a href="/"><b>{{ $store.state.app.name }}</b></a>
        </div>

        <div class="card">
            <div class="card-body login-card-body">
                <p class="login-box-msg">Sign in to start your session</p>
                <form action="/login" method="post" @submit.prevent="loginSubmit()">
                    <div class="input-group mb-3">
                        <input type="text" class="form-control" placeholder="Input yout Username" v-model="userName">
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <span class="fas fa-envelope"></span>
                            </div>
                        </div>
                    </div>
                    <div class="input-group mb-3">
                        <input type="password" class="form-control" placeholder="Input your Password" v-model="password">
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <span class="fas fa-lock"></span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        

                        <div class="col-12">
                            <button type="submit" class="btn btn-primary btn-block">Sign In</button>
                        </div>

                    </div>
                </form>

            
            </div>

        </div>
    </div>
</template>

<script>

import { mapActions } from 'vuex'

export default {
     name: 'Login',
    data() {
        return {
            userName: '',
            password: ''
        }
    },
    beforeMount(){
        $('body').remove('sidebar-mini').addClass('login-page')
        $('title').html(`Login | ${this.$store.state.app.name}`)
    },
    methods:{
        ...mapActions(['login']),
         loginSubmit(){
            const credentials = {
                userName: this.userName,
                password: this.password,
            }
          this.login(credentials)
                .then((res) => {
                    if (res) {
                        if(res.status ==200){
                            window.location.href = '/'
                        }
                    }
                })
        }
    }
}
</script>