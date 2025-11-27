<script lang="ts" setup>
import { useDeleteStore } from '@/stores/delete'
import { inject, type ComputedRef, type Ref } from 'vue'
import type { Comment } from '../../../utils/apiCall'
import { formatDate, getAvatarUrl } from '../../../utils/cardUtils'
import IconButton from '../IconButton.vue'
import Typography from '../Typography.vue'
const props = defineProps<{
  userId: number
}>()
const emit = defineEmits<{
  (e: 'reply', id: number): void
}>()
const comment = inject<ComputedRef<Comment>>('card-context')
const editMode = inject<Ref<boolean>>('edit-mode')
const { markForDeletion } = useDeleteStore()
</script>
<template>
  <div class="flex gap-200 items-center" v-if="comment">
    <img :src="getAvatarUrl(comment)" alt="" class="rounded-full w-8 aspect-square" />
    <Typography :preset="2">{{ comment?.user?.name }}</Typography>
    <Typography
      :preset="3"
      v-if="userId == comment?.userId"
      class="text-white bg-purple-600 rounded-sm px-1.5"
      >you</Typography
    >
    <Typography :preset="3" class="flex-1 text-grey-500">{{ formatDate(comment) }}</Typography>

    <IconButton type="reply" v-if="userId != comment?.userId" />
    <span v-else class="flex gap-200">
      <IconButton
        type="delete"
        :disabled="editMode"
        @click="() => !editMode && markForDeletion(comment?.commentId!)"
      />
      <IconButton type="edit" :disabled="editMode" @click="() => !editMode && (editMode = true)" />
    </span>
  </div>
  <div v-else>Context missing</div>
</template>
