<script setup lang="ts">
import { cn } from '../../utils/styleMerge'
import Typography from './Typography.vue'
const props = defineProps<{ disabled?: boolean }>()
</script>

<template>
  <button
    :class="
      cn('text-white bg-purple-600 cursor-pointer rounded-lg px-[27px] py-3 uppercase', {
        'bg-purple-200 cursor-default': disabled,
      })
    "
  >
    <Typography :preset="2">
      <slot />
    </Typography>
  </button>
</template>
