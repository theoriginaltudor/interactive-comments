<script setup lang="ts">
import { storeToRefs } from 'pinia'
import { onMounted } from 'vue'
import CommentCard from './components/CommentCard.vue'
import { useCommentsStore } from './stores/comments'
import { useUserStore } from './stores/user'
const commentsStore = useCommentsStore()
const { add, remove, update, get } = commentsStore
const { comments, error } = storeToRefs(commentsStore)
const userStore = useUserStore()
const { get: getUser } = userStore
const { user, error: userError } = storeToRefs(userStore)

onMounted(() => {
  get()
  getUser()
})
</script>

<template>
  <div class="p-10 bg-grey-50 min-h-dvh">
    <main class="max-w-4xl mx-auto">
      <p v-if="error" class="text-red-600">{{ error }}</p>
      <p v-if="userError" class="text-red-600">{{ userError }}</p>
      <div v-if="comments && comments.length > 0" class="flex flex-col gap-6">
        <div v-for="comment in comments" class="flex flex-col gap-6">
          <CommentCard
            :comment="comment"
            :owned="user?.userId == comment.userId"
            :disabled="user?.userId == comment.userId"
            @remove="remove"
            @update="update"
          />
          <div
            v-if="comment.replies && comment.replies.length > 0"
            class="ms-10 border-l-2 border-grey-100 ps-10 flex flex-col gap-6"
          >
            <CommentCard
              v-for="reply in comment.replies"
              :comment="reply"
              :owned="user?.userId == reply.userId"
              :disabled="user?.userId == reply.userId"
              @remove="remove"
              @update="update"
            />
          </div>
        </div>
      </div>
    </main>
  </div>
</template>
