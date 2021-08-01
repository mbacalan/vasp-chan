<template>
  <div v-for="board in store.boards" class="board">
    <router-link
      :to="{ name: 'threads', params: { id: board.boardID }}"
      class="board__link"
    >
      /{{ board.name }}/
    </router-link>

    <p class="board__desc">{{ board.description }}</p>
  </div>
</template>

<style scoped>
  .board__link {
    font-size: 18px;
    color: #fff;
  }
</style>

<script>
  import { onMounted } from 'vue';
  import { store, setBoards } from '../store';

  export default {
    setup() {
      onMounted(async () => {
        if (store.boards.length) {
          return;
        }

        await setBoards();
      })

      return {
        store
      }
    },
  }
</script>
