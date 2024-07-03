<template>
  <form class="container mt-4" @submit.prevent="handleSubmit">
    <div class="mb-3 form-check">
      <input
        type="checkbox"
        id="isActive"
        v-model="checkedNames"
        class="form-check-input"
      />
      <label for="isActive" class="form-check-label">Is Active</label>
    </div>

    <div class="mb-3">
      <label for="age" class="form-label">Age</label>
      <input type="number" id="age" v-model="age" class="form-control" />
    </div>

    <div class="mb-3">
      <label for="eye" class="form-label">Eye Color</label>
      <input type="text" id="eye" v-model="eyeColor" class="form-control" />
    </div>

    <div class="mb-3">
      <label for="name" class="form-label">Name</label>
      <input type="text" id="name" v-model="name" class="form-control" />
    </div>

    <button type="submit" class="btn btn-primary">Submit</button>
  </form>
</template>

<script setup>
  import { ref } from 'vue';
  import { useRouter } from 'vue-router';
  import axios from "axios";

  const router = useRouter();
  const checkedNames = ref(false);
  const age = ref(0);
  const eyeColor = ref('');
  const name = ref('');

  const handleSubmit = () => {
    console.log('Formulário submetido com sucesso!');
    console.log('Is Active:', checkedNames.value);
    console.log('Age:', age.value);
    console.log('Eye Color:', eyeColor.value);
    console.log('Name:', name.value);
    resetForm();
    router.push('/table');
  };

  const resetForm = () => {
    checkedNames.value = false;
    age.value = 0;
    eyeColor.value = '';
    name.value = '';
  };
</script>