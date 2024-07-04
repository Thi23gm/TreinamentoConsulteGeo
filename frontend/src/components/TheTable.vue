<script lang="ts">
import {
  ConsulteGrid,
  ConsulteGridColumnsModel,
  DataSource
} from 'consulte-framework-vue/components/grid'
import { defineComponent } from 'vue'
import axios from 'axios'

// User Model
class UserModel {
  id: number
  isActive: boolean
  age: number
  eyeColor: string
  name: string

  constructor(id: number, isActive: boolean, age: number, eyeColor: string, name: string) {
    this.id = id
    this.isActive = isActive
    this.age = age
    this.eyeColor = eyeColor
    this.name = name
  }
}

//Data Source for ConsulteGrid
class CustomDataSource extends DataSource<UserModel> {
  constructor(
    pageNumber: number,
    rowsPerPage: number,
    rowsPageCount: number,
    totalRowCount: number
  ) {
    super(pageNumber, rowsPerPage, rowsPageCount, totalRowCount, [])
  }

  setRows(users: UserModel[]) {
    for (const user of users) {
      this.rows.push(user)
    }
    this.load()
  }

  //render on grid
  async load(): Promise<any> {
    this.totalRowCount = this.rows.length
    return super.load()
  }
}

export default defineComponent({
  name: 'TheTable',
  components: { ConsulteGrid },
  data() {
    return {
      //variable for grid
      gridName: 'Treinamento Table',
      dataSource: new CustomDataSource(0, 10, 0, 0),
      actions: true,
      singlePage: false,
      columns: [
        { text: 'Active', align: 'center', datafield: 'isActive', filterable: false },
        { text: 'Age', align: 'center', datafield: 'age', filterable: false },
        { text: 'EyeColor', align: 'center', datafield: 'eyeColor', filterable: false },
        { text: 'Name', align: 'center', datafield: 'name', filterable: false }
      ] as ConsulteGridColumnsModel[]
    }
  },
  mounted() {
    this.fetchUsers()
  },
  methods: {
    async fetchUsers() {
      try {
        const api = axios
        const response = await api.get('https://localhost:7159/api/user')
        const users = response.data.map(
          (user: any) => new UserModel(user.id, user.isActive, user.age, user.eyeColor, user.name)
        )
        this.dataSource.setRows(users)
      } catch (error) {
        console.error('Error fetching users:', error)
      }
    },
    async editar(user: UserModel) {
      localStorage.setItem('userToEdit', JSON.stringify(user))
      this.$router.push('/add')
    },

    async excluir(id: number) {
      try {
        const api = axios
        console.log(id)
        await api.delete('https://localhost:7159/api/user/' + id)
        location.reload()
      } catch (error) {
        console.error('Error fetching users:', error)
      }
    }
  }
})
</script>

<template>
  <div class="col-lg-12">
    <ConsulteGrid
      :name="gridName"
      hideHeader
      :columns="columns"
      :data-source="dataSource"
      :actions="actions"
      :single-page="singlePage"
    >
      <template #actions="context">
        <button
          type="button"
          rel="tooltip"
          style="margin-right: 5px"
          class="btn btn-danger btn-round rounded-pill btn-sm btn-icon"
          @click="excluir(context.row.id)"
        >
          <i>X</i>
        </button>
        <button
          type="button"
          rel="tooltip"
          class="btn btn-primary btn-round rounded-pill btn-sm btn-icon"
          data-original-title="Refresh"
          title=""
          @click="editar(context.row)"
        >
          <i>Editar</i>
        </button>
      </template>
    </ConsulteGrid>
  </div>
</template>
