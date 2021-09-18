<template>
  <h2 class="thread-title">
    /{{ state.board.name }}/ - {{ state.board.description }}
  </h2>

  <div class="thread-list">
    <div v-for="thread in state.board.threads" class="thread">
      <router-link
        :to="{ name: 'posts', params: { id: state.board.name, tid: thread.threadID }}"
        class="thread__link"
      >
        {{ thread.title }}
      </router-link>
      <p>{{ thread.description }}</p>
      <small>R: {{ thread.posts.length }}</small>
    </div>
  </div>
</template>

<style scoped>
  .thread-title {
    text-align: center;
  }

  .thread-list {
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
    border: solid 2px var(--drc-selection);
  }

  .thread {
    padding: 8px;
    margin: 8px;
    width: 160px;
    height: 160px;
    text-align: center;
    color: #fff;
  }

  .thread__link {
    font-size: 18px;
  }
</style>

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
