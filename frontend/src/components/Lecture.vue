<template>
  <div class="lecture-container" @click="goToLectureDetail"> 
    <div class="image-container">
      <img :src="require('@/assets/class1.jpeg')" class="image" alt="">
    </div>
    <div class="flex">
      <b>{{lecture.teacher}}</b>
    </div>
    <div class="flex">
      {{lecture.name}}
    </div>
  </div>
</template>
<script>
export default {
  name : "Class",
  props : ["lecture"],
  data(){
    return  {
      // lecture : lecture,
    }
  },
  methods : {
    goToLectureDetail(){
      this.$router.push({name :"LectureDetail", params : {"lecture_id" : this.lecture.id} })
    },
  },
}
</script>

<style scoped>
.lecture-container{
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