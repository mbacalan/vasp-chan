import { createRouter, createWebHistory } from 'vue-router'
import Boards from './views/Boards.vue'
import Threads from './views/Threads.vue'
import Posts from './views/Posts.vue'

const routes = [
  { path: '/', name: 'boards', component: Boards },
  { path: '/:id', name: 'threads', component: Threads, props: true },
  { path: '/:id/:tid', name: 'posts', component: Posts, props: true },
]

export const router = createRouter({
  history: createWebHistory(),
  routes,
})
