import { defineStore } from 'pinia'
import { ref } from 'vue'
import { getUsers, type User } from '../../utils/apiCall'

export const useUsersStore = defineStore('users', () => {
  const users = ref<User[] | null>(null)
  const error = ref<string | undefined>()

  const get = async () => {
    const { data, error: getError } = await getUsers()
    if (getError) {
      error.value = 'Get error:' + getError.message
      return
    }
    if (data) {
      users.value = data
    }
  }

  return { error, users, get }
})
