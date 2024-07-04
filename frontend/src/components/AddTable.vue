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

    <button type="submit" class="btn btn-success btn-round rounded-pill btn-sm btn-icon">
      Submit
    </button>

  </form>
</template>

<script lang="ts">
import { ref, defineComponent, onMounted } from 'vue'
import { useRouter } from 'vue-router'
import axios from 'axios'

export default defineComponent({
  name: 'AddUser',
  setup() {
    const router = useRouter()
    const isActive = ref(false)
    const age = ref(0)
    const eyeColor = ref('')
    const name = ref('')
    const userId = ref<number | null>(null)

    onMounted(() => {
      const userToEdit = localStorage.getItem('userToEdit')
      if (userToEdit) {
        const user = JSON.parse(userToEdit)
        userId.value = user.id
        isActive.value = user.isActive
        age.value = user.age
        eyeColor.value = user.eyeColor
        name.value = user.name
      }
    })

    const handleSubmit = async () => {
      const user = {
        isActive: isActive.value,
        age: age.value,
        eyeColor: eyeColor.value,
        name: name.value
      }

      try {
        if (userId.value !== null) {
          // Update existing user
          await axios.put('https://localhost:7159/api/user/' + userId.value, user)
          userId.value = null
          localStorage.clear()
        } else {
          // Create new user
          await axios.post('https://localhost:7159/api/user', user)
        }

        // Clear form and localStorage
        isActive.value = false
        age.value = 0
        eyeColor.value = ''
        name.value = ''
        localStorage.removeItem('userToEdit')

        // Navigate back to table
        router.push('/table')
      } catch (error) {
        console.error('Error submitting form:', error)
      }
    }

    return {
      isActive,
      age,
      eyeColor,
      name,
      handleSubmit
    }
  }
})
</script>