<script lang="ts" setup>
import { useCommentsStore } from '@/stores/comments'
import { useDeleteStore } from '@/stores/delete'
import MainButton from './MainButton.vue'
import Typography from './Typography.vue'
const props = defineProps<{
  commentId: number
}>()
const { remove } = useCommentsStore()
const { emptyDeletion } = useDeleteStore()

const deleteHandler = async () => {
  await remove(props.commentId)
  emptyDeletion()
}
</script>

<template>
  <div class="bg-white w-[404px] p-8 gap-300 flex flex-col">
    <Typography :preset="1" as="h3"> Delete comment </Typography>
    <Typography :preset="3" as="p" class="text-grey-500">
      Are you sure you want to delete this comment? This will remove the comment and can’t be
      undone.
    </Typography>
    <div class="flex justify-between">
      <MainButton class="bg-grey-500" @click="() => emptyDeletion()">No, cancel</MainButton>
      <MainButton class="bg-pink-400" @click="deleteHandler">Yes, delete</MainButton>
    </div>
  </div>
</template>
