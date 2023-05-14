<template>
  <content-header title="Vendor" icon="fas fa-user" />
  <content>
    <div class="container-fluid">
      <div class="row">
        <div class="col-12">
          <div class="card">
            <div class="card-header">
              <h3 class="card-title">
                <button class="btn btn-primary" @click="addVendor()">Add Data</button>
              </h3>
            </div>

            <div class="card-body">
             
              <table id="example2" class="table table-bordered table-hover">
                <thead>
                  <tr>
                    <th>Vendor Id</th>
                    <th>Vendor Name</th>
                  </tr>
                </thead>
                <tbody>
              
                  <tr v-for="item in list" :key="item.id" v-if="list.length > 0">
                    <td>{{ item.id }}</td>
                    <td>{{ item.name }}</td>
                  </tr>
                   <tr v-else>
                      <td colspan="2">Data Is empty</td>
                   </tr>
                </tbody>
              </table>
            </div>

          </div>

        </div>

      </div>

      

    </div>
  </content>
</template>

<script>
import axios from 'axios'

export default {
  name:'VendorList',
  data(){
    return{
      list:[],
    }
  },
  async mounted()
  {
    let result =await axios.get('https://localhost:44361/api/vendor');
    this.list = result.data
  },
  methods:{
        addVendor() {
      window.location.href = '/add-vendor'
    }
  }
}
</script>