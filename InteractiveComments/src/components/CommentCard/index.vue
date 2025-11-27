<script lang="ts" setup>
import { useCommentsStore } from '@/stores/comments'
import { computed, provide, type ComputedRef } from 'vue'
import { type Comment } from '../../../utils/apiCall'
import Counter from '../Counter.vue'
const props = defineProps<{
  comment: Comment
  disabled?: boolean
}>()
const comment = computed(() => props.comment)
const { update } = useCommentsStore()

const downVote = async () => {
  const newComment = { ...comment.value }
  newComment.score! -= 1
  await update(newComment!)
}

const upVote = async () => {
  const newComment = { ...comment.value }
  newComment.score! += 1
  await update(newComment!)
}
provide<ComputedRef<Comment>>('card-context', comment)
</script>

<template>
  <div class="flex gap-300 p-12 rounded-lg bg-white">
    <Counter :count="comment.score ?? 0" @down="downVote" @up="upVote" :disabled="disabled" />
    <div class="flex flex-col flex-1 gap-200">
      <slot></slot>
    </div>
  </div>
</template>
