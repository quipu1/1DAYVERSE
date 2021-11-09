<template>
  <div id="unity">
    <Navbar />
    <iframe src="unity2/index.html" class="unity-box"></iframe>
  </div>
</template>

<script>
import Navbar from "@/components/Navbar.vue";

export default {
  name: "Study",
  components: {
    Navbar,
  },
  methods: {},
};
</script>

<style scoped>
.unity-box {
  border: none;
  background: none;
  margin-top: 1vh;
  height: 89vh;
  width: 100%;
  display: flex;
  justify-content: center;
}
</style>
