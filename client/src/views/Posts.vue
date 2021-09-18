<template>
  <div class="border-2 border-dracula-selection">
    <div class="w-1/2 mx-auto">
      <div class="m-2 p-2 bg-dracula-selection">
        <p class="font-semibold text-lg">
          {{ state.thread.title }}
        </p>

        <p>
          {{ state.thread.description }}
        </p>
      </div>

      <div v-if="!state.thread.posts.length" class="m-2 p-2 bg-dracula-comment">
        Nothing here... yet.
      </div>

      <div v-for="post in state.thread.posts" class="m-2 p-2 bg-dracula-comment" :id="post.postID">
        <span>
          Anon -
          <a :href="`#${post.postID}`">{{ post.postID }}</a>
        </span>

        <p>{{ post.content }}</p>
      </div>
    </div>
  </div>
</template>

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
