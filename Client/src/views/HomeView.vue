<template>
<content-header title="Dashboard"/>
<content>
  <div class="container">
    <h3><b>Wellcome {{ name }}</b></h3>
  </div>
</content>
</template>

<script>
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
};
</script>