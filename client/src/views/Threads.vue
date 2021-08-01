<template>
  <div v-for="thread in state.threads" class="thread">
    <router-link
      :to="{ name: 'posts', params: { id: thread.boardID, tid: thread.threadID }}"
      class="thread__link"
    >
      {{ thread.title }}
    </router-link>
    <p>{{ thread.description }}</p>
  </div>
</template>

<style scoped>
  .thread__link {
    font-size: 18px;
    color: #fff;
  }
</style>

<script>
  import { reactive, onMounted } from 'vue';
  import { store, setThreads, getThreads } from '../store';

  export default {
    props: {
      id: {
        type: String,
        required: true
      }
    },
    setup(props) {
      const state = reactive({ threads: [] });

      onMounted(async () => {
        await setThreads(props.id);
        state.threads = getThreads(props.id)
      })

      return {
        store,
        props,
        state
      }
    },
  }
</script>
