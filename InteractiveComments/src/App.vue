<script setup lang="ts">
import { storeToRefs } from 'pinia'
import { onMounted } from 'vue'
import AddCommnetCard from './components/AddCommnetCard.vue'
import CommentCardHeader from './components/CommentCard/CommentCardHeader.vue'
import CommentCard from './components/CommentCard/index.vue'
import DeleteCard from './components/DeleteCard.vue'
import Typography from './components/Typography.vue'
import { useCommentsStore } from './stores/comments'
import { useDeleteStore } from './stores/delete'
import { useUserStore } from './stores/user'
const commentsStore = useCommentsStore()
const { get } = commentsStore
const { comments, error } = storeToRefs(commentsStore)
const userStore = useUserStore()
const { get: getUser } = userStore
const { user, error: userError } = storeToRefs(userStore)
const { deleteCommentId } = storeToRefs(useDeleteStore())

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
          <CommentCard :comment="comment" :disabled="user?.userId == comment.userId">
            <CommentCardHeader :user-id="user?.userId || 0" />
            <Typography as="p" :preset="3" class="text-grey-500">{{ comment.content }}</Typography>
          </CommentCard>
          <div
            v-if="comment.replies && comment.replies.length > 0"
            class="ms-10 border-l-2 border-grey-100 ps-10 flex flex-col gap-6"
          >
            <CommentCard
              v-for="reply in comment.replies"
              :comment="reply"
              :disabled="user?.userId == reply.userId"
            >
              <CommentCardHeader :user-id="user?.userId || 0" />
              <Typography as="p" :preset="3" class="text-grey-500">
                <span class="text-purple-600 font-medium">@{{ comment.user?.name }}</span>
                {{ reply.content }}
              </Typography>
            </CommentCard>
          </div>
        </div>
      </div>
      <div v-if="user" class="mt-6"><AddCommnetCard /></div>
    </main>
    <div
      v-if="deleteCommentId"
      class="flex justify-center items-center absolute w-full h-full top-0 left-0"
    >
      <div class="absolute w-full h-full opacity-50 bg-black" />
      <DeleteCard :comment-id="deleteCommentId" class="relative rounded-lg" />
    </div>
  </div>
</template>
