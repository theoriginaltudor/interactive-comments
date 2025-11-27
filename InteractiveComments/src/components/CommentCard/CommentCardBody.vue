<script lang="ts" setup>
import { computed, inject, ref, type ComputedRef, type Ref } from 'vue'
import type { Comment } from '../../../utils/apiCall'

import MainButton from '../MainButton.vue'
import Typography from '../Typography.vue'
const props = defineProps<{
  userName?: string
}>()
const editMode = inject<Ref<boolean>>('edit-mode')
const comment = inject<ComputedRef<Comment>>('card-context')
const textAreaValue = computed(() =>
  props.userName ? `@${props.userName} ${comment?.value.content}` : comment?.value.content,
)
const localContent = ref<string | undefined>(textAreaValue.value)
const updateHandler = () => {
  console.log(localContent.value)
  if (editMode) editMode.value = false
}
</script>
<template>
  <div v-if="editMode" class="flex flex-col items-end gap-6">
    <textarea
      v-model="localContent"
      class="border border-purple-600 rounded-lg p-4 w-full field-sizing-content"
    />
    <MainButton @click="updateHandler">Update</MainButton>
  </div>
  <Typography v-else as="p" :preset="3" class="text-grey-500">
    <span v-if="userName" class="text-purple-600 font-medium">@{{ userName }}</span>
    {{ comment?.content }}
  </Typography>
</template>
