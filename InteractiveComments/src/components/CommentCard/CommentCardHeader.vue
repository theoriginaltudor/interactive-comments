<script lang="ts" setup>
import { inject, type ComputedRef } from 'vue'
import type { Comment } from '../../../utils/apiCall'
import { formatDate, getAvatarUrl } from '../../../utils/cardUtils'
import IconButton from '../IconButton.vue'
import Typography from '../Typography.vue'
const props = defineProps<{
  userId: number
}>()
const comment = inject<ComputedRef<Comment>>('card-context')
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
      <IconButton type="delete" />
      <IconButton type="edit" />
    </span>
  </div>
  <div v-else>Context missing</div>
</template>
