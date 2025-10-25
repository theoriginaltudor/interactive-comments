<script setup lang="ts">
import { storeToRefs } from 'pinia'
import { onMounted } from 'vue'
import CommentCard from './components/CommentCard.vue'
import { useCommentsStore } from './stores/comments'
const commentsStore = useCommentsStore()
const { add, remove, update, get } = commentsStore
const { comments, error } = storeToRefs(commentsStore)

onMounted(() => get())
</script>

<template>
  <main class="p-10 flex flex-col gap-200 bg-grey-50 min-h-dvh">
    <p>Length of list is {{ comments?.length }}</p>
    <p v-if="error" class="text-red-600">{{ error }}</p>
    <component v-if="comments && comments.length > 0">
      <CommentCard v-for="comment in comments" :comment="comment" />
    </component>
  </main>
</template>
