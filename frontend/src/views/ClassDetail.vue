<template>
  <div class="warp">
    <Navbar/>
    
  </div>  
</template>

<script>
import Navbar from '@/components/Navbar.vue'
import image from '@/assets/drawing_image.jpg'
export default {
  name : "ClassDetail",
  components : {
    Navbar,
  },
  data(){
    return {
      cls : {
        "main_image" : image,
        "name" : "윤소영의 그림 클래스",
        "teacher" : "윤소영",
        "description" : "그림 그리는 거 가르치는 강좌입니다.",
        "price" : 1000000,
        "size" : 20,
        
       }
    }
  },


}
</script>

<style scoped>
.warp{
  position: relative;
  width: 100%;
  height: 100%;
}
</style>