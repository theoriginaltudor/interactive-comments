<script lang="ts" setup>
import MainButton from './MainButton.vue'
import Typography from './Typography.vue'
</script>

<template>
  <div class="bg-white w-[404px] p-8 gap-300 flex flex-col">
    <Typography :preset="1" as="h3"> Delete comment </Typography>
    <Typography :preset="3" as="p" class="text-grey-500">
      Are you sure you want to delete this comment? This will remove the comment and can’t be
      undone.
    </Typography>
    <div class="flex justify-between">
      <MainButton class="bg-grey-500">No, cancel</MainButton>
      <MainButton class="bg-pink-400">Yes, delete</MainButton>
    </div>
  </div>
</template>
