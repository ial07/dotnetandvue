<template>
    <content-header title="Add Vendor" icon="fas fa-plus" />
    <content>
        <form @submit.prevent="onSubmit">
        <div class="form-group">
          <label for="idVendor">Vendor ID:</label>
          <input type="text" class="form-control" id="idVendor" v-model="idVendor" readonly>
        </div>
        <div class="form-group">
          <label for="nameVendor">Vendor Name:</label>
          <input type="text" class="form-control" id="nameVendor" v-model="nameVendor">
        </div>
        <button type="submit" class="btn btn-primary">Submit</button>
      </form>
    </content>
</template>

<script>
import axios from 'axios'

export default {
    name: 'VendorAdd',
    data() {
        return {
            idVendor: '',
            nameVendor: ''
        }
    },
    async mounted() {
        let result = await axios.get('https://localhost:44361/api/vendor');
        this.idVendor = result.data.length +1
    },
    methods: {
        async onSubmit() {
             await axios.post('https://localhost:44361/api/vendor',{
                name:this.nameVendor
             }).then(res => {
                if (res.status == 200) {
                    alert(res.data)
                    this.$router.push('/vendor');
                }
            })
                .catch(error => {
                    alert(error.message);
                });
        }
    }
}
</script>