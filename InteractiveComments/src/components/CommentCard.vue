<script lang="ts" setup>
import { computed } from 'vue'
import { API_URL, type Comment } from '../../utils/apiCall'
import Counter from './Counter.vue'
import IconButton from './IconButton.vue'
import Typography from './Typography.vue'
const props = defineProps<{
  comment: Comment
}>()
const emit = defineEmits<{
  (e: 'remove', id: number): Promise<void>
  (e: 'update', id: number, comment: Comment): Promise<void>
  (e: 'test'): void
}>()
const comment = computed(() => props.comment)
const avatar = computed(() => {
  const assets = comment.value.user?.assets
  let path = assets?.find((a) => a.path.includes('webp'))?.path
  if (!path) path = assets?.[0]?.path
  return API_URL + path?.substring(1)
})
const formattedDate = computed(() => {
  if (!comment.value.createdAt) return 'today'
  const now = new Date()
  const created = new Date(comment.value.createdAt)
  const diffMs = now.getTime() - created.getTime()
  const diffDays = Math.floor(diffMs / (1000 * 60 * 60 * 24))

  if (diffDays < 1) return 'today'
  if (diffDays < 7) return `${diffDays} day${diffDays > 1 ? 's' : ''} ago`
  if (diffDays < 30)
    return `${Math.floor(diffDays / 7)} week${Math.floor(diffDays / 7) > 1 ? 's' : ''} ago`
  return `${Math.floor(diffDays / 30)} month${Math.floor(diffDays / 30) > 1 ? 's' : ''} ago`
})

const downVote = async () => {
  const newComment = { ...comment.value }
  newComment.score! -= 1
  await emit('update', comment.value.userId!, newComment!)
}

const upVote = async () => {
  const newComment = { ...comment.value }
  newComment.score! += 1
  await emit('update', comment.value.userId!, newComment!)
}
</script>

<template>
  <div class="flex gap-300 p-12 rounded-lg bg-white">
    <Counter :count="comment.score ?? 0" @down="downVote" @up="upVote" />
    <div class="flex flex-col flex-1 gap-200">
      <div class="flex gap-200 items-center">
        <img :src="avatar" alt="" class="rounded-full w-8 aspect-square" />
        <Typography :preset="2">{{ comment.user?.name }}</Typography>
        <Typography :preset="3" class="flex-1 text-grey-500">{{ formattedDate }}</Typography>
        <IconButton type="reply" />
      </div>
      <Typography as="p" :preset="3" class="text-grey-500">{{ comment.content }}</Typography>
    </div>
  </div>
</template>
