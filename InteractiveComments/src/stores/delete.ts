import { defineStore } from 'pinia'
import { ref } from 'vue'

export const useDeleteStore = defineStore('delete', () => {
  const deleteCommentId = ref<number | null>(null)

  const markForDeletion = (id: number) => (deleteCommentId.value = id)
  const emptyDeletion = () => (deleteCommentId.value = null)

  return { deleteCommentId, markForDeletion, emptyDeletion }
})
