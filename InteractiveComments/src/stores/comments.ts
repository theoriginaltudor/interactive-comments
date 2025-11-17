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
      if (comments.value !== null) {
        if (data.parentCommentId) comments.value[data.parentCommentId]?.replies?.push(data)
        else comments.value.push(data)
      } else comments.value = [data]
    }
  }

  const remove = async (id: number) => {
    const { error: deleteError } = await deleteComment(id)
    if (deleteError) {
      error.value = 'Delete error:' + deleteError.message
      return
    }
    const [firstIndex, secondIndex] = getPathIndexes(comments.value!, id)
    if (!comments.value) return
    if (firstIndex !== undefined) {
      if (secondIndex !== undefined) {
        comments.value[firstIndex]!.replies!.splice(secondIndex, 1)
      } else comments.value.splice(firstIndex, 1)
    } else error.value = 'Remove error client'
  }

  const update = async (comment: Comment) => {
    const { data, error: updateError } = await updateComment(comment)
    if (updateError) {
      error.value = 'Update error:' + updateError.message
      return
    }
    if (data) {
      const [firstIndex, secondIndex] = getPathIndexes(comments.value!, comment.commentId!)
      if (!comments.value) return
      if (firstIndex !== undefined) {
        if (secondIndex !== undefined) {
          comments.value[firstIndex]!.replies![secondIndex] = comment
        } else comments.value[firstIndex] = comment
      } else error.value = 'Update error client'
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

const getPathIndexes = (list: Comment[], searchId: number): number[] => {
  if (list.length == 0) return []

  const index = list.findIndex((item) => item.commentId == searchId)
  if (index != -1) {
    return [index]
  }
  const indexList: number[] = []
  for (let i = 0; i < list.length; i++) {
    if (!list[i]?.replies) continue
    const result = getPathIndexes(list[i]!.replies!, searchId)
    if (result.length == 0) continue
    indexList.push(i, ...result)
  }
  return indexList
}
