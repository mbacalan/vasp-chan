<template>
  <h2 class="text-center mb-2 font-bold">
    /{{ state.board.name }}/ - {{ state.board.description }}
  </h2>

  <div class="flex flex-wrap justify-center border border-2 border-dracula-selection">
    <div v-for="thread in state.board.threads" class="p-2 m-2 w-[160px] h-[160px] text-center text-white">
      <router-link
        :to="{ name: 'posts', params: { id: state.board.name, tid: thread.threadID }}"
        class="text-lg font-semibold"
      >
        {{ thread.title }}
      </router-link>
      <p>{{ thread.description }}</p>
      <small>R: {{ thread.posts.length }}</small>
    </div>
  </div>
</template>

<script setup>
  import { reactive, onMounted } from 'vue';
  import { useStore } from '../store';

  const props = defineProps({
    id: {
      type: String,
      required: true
    }
  });

  const store = useStore();
  const state = reactive({
    board: {
      name: "",
      description: "",
      threads: []
    }
  });

  onMounted(async () => {
    await store.setThreads(props.id);
    state.board = store.boards[props.id];
  })
</script>
