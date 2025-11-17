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
  <div class="p-10 bg-grey-50 min-h-dvh">
    <main class="max-w-4xl mx-auto">
      <p v-if="error" class="text-red-600">{{ error }}</p>
      <component v-if="comments && comments.length > 0">
        <component v-for="comment in comments" class="flex flex-col gap-200">
          <CommentCard :comment="comment" @remove="remove" @update="update" />
          <div
            v-if="comment.replies && comment.replies.length > 0"
            class="ms-200 border-l-2 border-grey-500 ps-200 flex flex-col gap-200 py-200"
          >
            <CommentCard
              v-for="reply in comment.replies"
              :comment="reply"
              @remove="remove"
              @update="update"
            />
          </div>
        </component>
      </component>
    </main>
  </div>
</template>
