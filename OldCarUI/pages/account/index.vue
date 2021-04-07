<template>
  <div class="index">
      <TheAccount :dataAccounts='dataAccounts' @getListAccounts="getData"/>
  </div>
</template>

<script>
import TheAccount from '~/components/account/TheAccount'
import axios from 'axios';
export default {
  name:'index',
  components: {
    TheAccount
  },
  data(){
    return{
      dataAccounts:[]
    };
  },
  methods:{
    getData(){
      axios.get("https://localhost:44343/OldCar/Account/").then((res)=>{
        this.dataAccounts = res.data;
      });
    }
  },
  mounted(){
    this.getData();
  }
}
</script>

