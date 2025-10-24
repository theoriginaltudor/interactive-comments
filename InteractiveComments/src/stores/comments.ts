import { defineStore } from 'pinia'
import { ref } from 'vue'
import {
  createComment,
  deleteComment,
  getComments,
  updateComment,
  type Comment,
} from '../../utils/apiCall'

export const useCommentsStore = defineStore('comments', () => {
  const comments = ref<Comment[] | null>(null)
  const error = ref<string | undefined>()

  const add = async (comment: Comment) => {
    const { data, error: createError } = await createComment(comment)
    if (createError) {
      error.value = 'Create error:' + createError.message
      return
    }
    if (data) {
      if (comments.value !== null) comments.value.push(data)
      else comments.value = [data]
    }
  }

  const remove = async (id: number) => {
    const { error: deleteError } = await deleteComment(id)
    if (deleteError) {
      error.value = 'Delete error:' + deleteError.message
      return
    }
  }

  const update = async (id: number, comment: Comment) => {
    const { data, error: updateError } = await updateComment(id, comment)
    if (updateError) {
      error.value = 'Update error:' + updateError.message
      return
    }
    if (data) {
      const index = comments.value?.findIndex((comment) => comment.commentId == id)
      if (index && index > -1) {
        comments.value![index]!.content = comment.content
        comments.value![index]!.score = comment.score
      }
    }
  }

  const get = async () => {
    const { data, error: getError } = await getComments()
    if (getError) {
      error.value = 'Get error:' + getError.message
      return
    }
    if (data) {
      comments.value = data
    }
  }

  return { error, comments, add, remove, get, update }
})
