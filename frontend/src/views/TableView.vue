<template>
  <div class="table">
    <h1 class="green">Table</h1>
    <TheTable></TheTable>
  </div>
</template>

<script>
import { defineComponent } from 'vue';
import TheTable from '../components/TheTable.vue';

export default defineComponent({
  components: {
    TheTable: TheTable
  }
})
</script>

<style scoped>
@media (min-width: 1024px) {
  .table {
    min-height: 100vh;
    display: flex;
    align-items: center;
    justify-content: center;
    flex-direction: column;
  }
}
</style>
