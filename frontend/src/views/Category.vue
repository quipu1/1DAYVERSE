<template>
  <div class="warp">
    <Navbar/>
    <main>
      <Class
        v-for="(cls,idx) in classes"
        :key="idx"
        :cls="cls"
      />
    </main>
  </div>
</template>

<script>
import Navbar from '@/components/Navbar.vue'
import Class from '@/components/Class.vue'

export default {
  name : "Category",
  props : ["category"],
  components : {
    Navbar,
    Class,
  },
  data(){
    return {
      classes : [
        {name : "1번강의", teacher : "티모"},
        {name : "2번강의", teacher : "가렌"},
        {name : "3번강의", teacher : "샤코"},
        {name : "엄청나게 긴 강 오버플로우", teacher : "오리아나"},
        {name : "5번강의", teacher : "오리아나"},
      ]
    }
  },
  created(){
    console.log(this.params)
  },

}
</script>

<style scoped>
.warp{
  position: relative;
  width: 100%;
  height: 100%;
}
main{
  display: grid;
  grid-template-columns: repeat(4, 1fr);
  justify-content:center;
  align-items: center;
  justify-items: center;
  gap: 2.5%;
  padding: 0 5%;
  height: 100%;
  margin-top: 5%;
}
</style>