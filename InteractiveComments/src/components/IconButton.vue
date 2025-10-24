<script setup lang="ts">
import IconDelete from '@/assets/images/icon-delete.vue'
import IconEdit from '@/assets/images/icon-edit.vue'
import IconReply from '@/assets/images/icon-reply.vue'
import { cn } from '../../utils/styleMerge'
import Typography from './Typography.vue'

const props = defineProps<{
  type: 'reply' | 'delete' | 'edit'
  disabled?: boolean
}>()
</script>

<template>
  <button
    :class="
      cn('flex gap-100 text-purple-600 fill-purple-600 items-center cursor-pointer', {
        'text-pink-400 fill-pink-400': type == 'delete',
        'cursor-default text-purple-200 fill-purple-200': disabled,
        'text-pink-200 fill-pink-200': type == 'delete' && disabled,
      })
    "
  >
    <IconDelete v-if="type == 'delete'" />
    <IconEdit v-else-if="type == 'edit'" />
    <IconReply v-else-if="type == 'reply'" />
    <Typography :preset="2" class="capitalize">
      {{ type }}
    </Typography>
  </button>
</template>
