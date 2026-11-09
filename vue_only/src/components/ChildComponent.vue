<script setup>
  const props = defineProps({
    msg: String
  })

  const emit = defineEmits(['reponse'])
  emit('response', 'msg from emit reponse')


</script>

<template>
  <h3>Child Component</h3>
  <h4> {{ msg || 'No props' }} </h4>
  <slot>Child Slot</slot>
</template>
