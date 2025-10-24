<script lang="ts" setup>
import IconMinus from '@/assets/images/icon-minus.vue'
import IconPlus from '@/assets/images/icon-plus.vue'
import { cn } from '../../utils/styleMerge'
import Typography from './Typography.vue'

const props = defineProps<{
  count: number
  disabled?: boolean
}>()

const emit = defineEmits<{
  (e: 'up'): void
  (e: 'down'): void
}>()
</script>

<template>
  <div
    class="rounded-[10px] bg-grey-50 flex flex-col p gap-200 text-purple-600 w-10 h-[100px] items-center justify-center"
  >
    <IconPlus
      @click="!disabled && emit('up')"
      :class="
        cn('w-2.5 fill-purple-600 cursor-pointer', { 'fill-purple-200 cursor-default': disabled })
      "
    />
    <Typography :preset="2">{{ count }}</Typography>
    <IconMinus
      @click="!disabled && emit('down')"
      :class="
        cn('w-2.5 fill-purple-600 cursor-pointer', { 'fill-purple-200 cursor-default': disabled })
      "
    />
  </div>
</template>
