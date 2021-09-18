<template>
  <div class="post-list">
    <div class="post-wrapper">
      <div class="op post">
        <p class="op__title">
          {{ state.thread.title }}
        </p>

        <p class="op__desc">
          {{ state.thread.description }}
        </p>
      </div>

      <div v-if="!state.thread.posts.length" class="post">
        Nothing here... yet.
      </div>

      <div v-for="post in state.thread.posts" class="post" :id="post.postID">
        <span>
          Anon -
          <a :href="`#${post.postID}`">{{ post.postID }}</a>
        </span>

        <p>{{ post.content }}</p>
      </div>
    </div>
  </div>
</template>

<style scoped>
  .post-list {
    border: solid 2px var(--drc-selection);
  }

  .post-wrapper {
    width: 50%;
    margin: auto;
  }

  .post {
    margin: 8px;
    padding: 8px;
    background-color: var(--drc-comment);
  }

  .op {
    background-color: var(--drc-selection);
  }

  .op__title {
    font-weight: 700;
    font-size: 18px;
  }
</style>

<script setup>
  import { reactive, onMounted } from 'vue';

  const props = defineProps({
    id: {
      type: String,
      required: true
    },
    tid: {
      type: String,
      required: true
    }
  });

  const state = reactive({
    thread: {
      title: "",
      description: "",
      posts: []
    }
  });

  onMounted(async () => {
    const response = await fetch(`https://localhost:5001/api/posts/${props.tid}`);

    if (response.ok) {
      const responseJson = await response.json();

      state.thread.title = responseJson.threadTitle;
      state.thread.description = responseJson.threadDescription;
      state.thread.posts = responseJson.posts;
    }

    if (!response.status == 200) {
      setErrors(true)
    }
  })
</script>
