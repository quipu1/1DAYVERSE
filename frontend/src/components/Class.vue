<template>
  <div class="cls-container" @click="goToClassDetail"> 
    <div class="image-container">
      <img :src="require('@/assets/class1.jpeg')" class="image" alt="">
    </div>
    <div class="flex">
      <b>{{cls.teacher}}</b>
    </div>
    <div class="flex">
      {{cls.name}}
    </div>
  </div>
</template>

<script>
export default {
  name : "Class",
  props : ["cls"],
  methods : {
    goToClassDetail(){
      alert(`${this.cls.name}로 이동`)
    },
  },

}
</script>

<style scoped>
.cls-container{
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  cursor: pointer;
  box-sizing: border-box;
  height: 20%;

}
.image-container{
  width: 100%;
}
.image{
  width: 100%;
}
.flex{
  width: 100%;
  display: flex;
  margin: 2.5% 0;
  text-align: start;

}

</style>