<script lang="ts">
import {
  ConsulteGrid,
  ConsulteGridColumnsModel,
  DataSource
} from 'consulte-framework-vue/components/grid'
import { defineComponent } from 'vue'

class UserModel {
  isActive: boolean
  age: number
  eyeColor: string
  name: string

  constructor(isActive: boolean, age: number, eyeColor: string, name: string) {
    this.isActive = isActive
    this.age = age
    this.eyeColor = eyeColor
    this.name = name
  }
}

class CustomDataSource extends DataSource<UserModel> {
  constructor(pageNumber: number, rowsPerPage: number, rowsPageCount: number, totalRowCount: number) {
    super(pageNumber, rowsPerPage, rowsPageCount, totalRowCount, []);
  }

  setRows(users: UserModel[]) {
    for (const user of users) {
      this.rows.push(user)
    }
    this.load()
  }

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
      gridName: 'Treinamento Table',
      columns: [
        { text: 'Active', align: 'center', datafield: 'isActive', filterable: false },
        { text: 'Age', align: 'center', datafield: 'age', filterable: false },
        { text: 'EyeColor', align: 'center', datafield: 'eyeColor', filterable: false },
        { text: 'Name', align: 'center', datafield: 'name', filterable: false }
      ] as ConsulteGridColumnsModel[],
      dataSource: new CustomDataSource(0, 10, 0, 0),
      actions: true
    }
  },
  mounted() {
    this.createUsers()
  },
  methods: {
    createUsers() {
      const arr: UserModel[] = [
        new UserModel(true, 25, 'blue', 'Alice'),
        new UserModel(false, 30, 'green', 'Bob'),
        new UserModel(true, 28, 'brown', 'Charlie'),
        new UserModel(true, 25, 'blue', 'Alice'),
        new UserModel(false, 30, 'green', 'Bob'),
        new UserModel(true, 25, 'blue', 'Alice'),
        new UserModel(false, 30, 'green', 'Bob'),
        new UserModel(true, 28, 'brown', 'Charlie')
      ]
      this.dataSource.setRows(arr)
    }
  }
})
</script>

<template>
  <div class="col-lg-12">
    <ConsulteGrid name="Teste" hideHeader :columns="columns" :data-source="dataSource" :actions="false" :single-page="false"></ConsulteGrid>
  </div>
</template>
