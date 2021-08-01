<template>
  <div v-for="post in state.posts">
    <p>{{ post.content }}</p>
  </div>
</template>

<script>
  import { reactive, onMounted } from 'vue';
  import { store, getPosts, setPosts } from '../store';

  export default {
    props: {
      id: {
        type: String,
        required: true
      },
      tid: {
        type: String,
        required: true
      }
    },
    setup(props) {
      const state = reactive({ posts: [] });

      onMounted(async () => {
        await setPosts(props.id, props.tid);
        state.posts = getPosts(props.id, props.tid);
      })

      return {
        store,
        props,
        state
      }
    },
  }
</script>
