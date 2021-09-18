<template>
  <div class="border-2 border-dracula-selection p-4 mb-2">
    <p>VASPChan is a simple, text-based bulletin board where anyone can post comments.</p>
    <p>There are dedicated boards for various topics and no registration is required to participate.</p>
    <p>Browse boards below and join the fun!</p>
  </div>

  <div class="border-2 border-dracula-selection p-4">
    <p v-if="store.errors">
      Oops... something went wrong! Try again later, maybe.
    </p>

    <content-loader height="130" v-if="!store.errors && state.loading">
      <rect x="0" y="15" rx="5" ry="5" width="115" height="10" />
      <rect x="0" y="45" rx="5" ry="5" width="115" height="10" />
      <rect x="0" y="75" rx="5" ry="5" width="115" height="10" />
      <rect x="0" y="105" rx="5" ry="5" width="115" height="10" />
    </content-loader>

    <ul v-if="!store.errors">
      <li v-for="board in store.boards" class="mb-2">
        <router-link
          :to="{ name: 'threads', params: { id: board.name }}"
          class="board__link"
        >
          {{ board.description }} - /{{ board.name }}/
        </router-link>
      </li>
    </ul>
  </div>
</template>

<script setup>
  import { reactive, onMounted } from 'vue';
  import { useStore } from '../store';
  import { ContentLoader } from 'vue-content-loader'

  const store = useStore();
  const state = reactive({ loading: true });

  onMounted(async () => {
    if (Object.keys(store.boards).length) {
      state.loading = false;
      return;
    }

    await store.setBoards();
    state.loading = false;
  })
</script>
