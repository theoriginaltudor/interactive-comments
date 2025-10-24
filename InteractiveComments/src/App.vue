<script setup lang="ts">
import Typography from './components/Typography.vue'
</script>

<template>
  <main class="p-10 flex flex-col gap-200">
    <Typography as="h1" :preset="1">Hello here</Typography>
    <Typography as="h2" :preset="2">Hello here</Typography>
    <Typography as="h3" :preset="3">Hello here</Typography>
    <Typography as="label" :preset="4">Hello here</Typography>
    <Typography as="p">Hello here</Typography>
  </main>
</template>
