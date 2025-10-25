<script lang="ts" setup></script>

<template>
  <div class="flex gap-200 p-12 rounded-lg bg-white">
    <slot name="left"></slot>
    <slot class="flex-1"></slot>
    <slot name="right"></slot>
  </div>
</template>
