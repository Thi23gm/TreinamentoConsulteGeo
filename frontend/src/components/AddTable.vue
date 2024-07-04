<template>
  <form class="container mt-4" @submit.prevent="handleSubmit">
    <div class="mb-3 form-check">
      <input type="checkbox" id="isActive" v-model="isActive" class="form-check-input" />
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
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import axios from 'axios'

const router = useRouter()

//Refs for form inputs
const isActive = ref(false)
const age = ref(0)
const eyeColor = ref('')
const name = ref('')

//Handle form submission
const handleSubmit = async () => {
  const resetForm = () => {
    isActive.value = false
    age.value = 0
    eyeColor.value = ''
    name.value = ''
  }

  try {
    //Post data form
    await axios.post('https://localhost:7159/api/user', {
      isActive: isActive.value,
      age: age.value,
      eyeColor: eyeColor.value,
      name: name.value
    })

    //Reset data form
    resetForm()

    //Router back to table
    router.push('/table')
  } catch (error) {
    console.error('Error submitting form:', error)
  }
}
</script>
