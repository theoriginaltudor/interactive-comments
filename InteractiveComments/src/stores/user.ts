import { defineStore } from 'pinia'
import { ref } from 'vue'
import { getUser, type User } from '../../utils/apiCall'

export const useUserStore = defineStore('user', () => {
  const user = ref<User | null>(null)
  const error = ref<string | undefined>()

  const get = async () => {
    const { data, error: getError } = await getUser()
    if (getError) {
      error.value = 'Get error:' + getError.message
      return
    }
    if (data) {
      user.value = data
    }
  }

  return { error, user, get }
})
