<script setup lang="ts">
import { ref } from 'vue'
import Counter from './components/Counter.vue'
import DeleteCard from './components/DeleteCard.vue'
import IconButton from './components/IconButton.vue'
import MainButton from './components/MainButton.vue'
import Typography from './components/Typography.vue'

const firstCounter = ref(30)

const increase = () => firstCounter.value++
const decrease = () => firstCounter.value--
</script>

<template>
  <main class="p-10 flex flex-col gap-200">
    <Typography as="h1" :preset="1">Hello here</Typography>
    <Typography as="h2" :preset="2">Hello here</Typography>
    <Typography as="h3" :preset="3">Hello here</Typography>
    <Typography as="label" :preset="4">Hello here</Typography>
    <Typography as="p">Hello here</Typography>

    <div class="flex gap-300">
      <Counter :count="firstCounter" @up="increase" @down="decrease" />
      <Counter :count="firstCounter" @up="increase" @down="decrease" disabled />
    </div>

    <div class="grid gap-300 grid-cols-3 w-1/3">
      <IconButton type="reply" />
      <IconButton type="delete" />
      <IconButton type="edit" />
      <IconButton type="reply" disabled />
      <IconButton type="delete" disabled />
      <IconButton type="edit" disabled />
    </div>

    <div class="flex gap-300">
      <MainButton>reply</MainButton>
      <MainButton disabled>reply</MainButton>
    </div>

    <DeleteCard />
  </main>
</template>
