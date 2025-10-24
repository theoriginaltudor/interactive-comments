<script setup lang="ts">
import { computed } from 'vue'
import { cn } from '../../utils/styleMerge'

type AllowedElements = 'span' | 'label' | 'h1' | 'h2' | 'h3' | 'h4' | 'h5' | 'h6' | 'p'

interface Props {
  preset?: 1 | 2 | 3 | 4
  as?: AllowedElements
}

const props = defineProps<Props>()

const presetList = [
  'text-2xl leading-[28.8px]',
  '',
  'font-normal',
  'text-[13px] leading-[15.6px]',
] as const

const presetChoice = computed(() => (props.preset ? presetList[props.preset - 1] : presetList[3]))

const El = computed(() => props.as || 'span')
</script>

<template>
  <component
    :is="El"
    :class="cn('font-rubik-medium tracking-normal font-medium leading-normal', presetChoice)"
    v-bind="$attrs"
  >
    <slot />
  </component>
</template>
