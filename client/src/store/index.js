import { reactive } from 'vue';

// store
const store = reactive({
  boards: [],
});

// mutations
const SET_BOARDS = (boards) => store.boards = boards;
const SET_THREADS = (boardID, threads) => {
  store.boards.forEach(b => {
    if (b.boardID == boardID) {
      b.threads = threads;
    }
  });
};

const SET_POSTS = (boardID, threadID, posts) => {
  store.boards.forEach(b => {
    if (b.boardID == boardID) {
      b.threads.forEach(t => {
        if (t.threadID == threadID) {
          t.posts = posts;
        }
      })
    }
  });
};

// actions
async function setBoards() {
  const response = await fetch('https://localhost:5001/api/boards');

  if (response.ok) {
    const data = await response.json();

    SET_BOARDS(data);
  }
}

async function setThreads(boardID) {
  const response = await fetch('https://localhost:5001/api/threads');

  if (response.ok) {
    const data = await response.json();
    const threads = data.filter(t => t.boardID == boardID);

    SET_THREADS(boardID, threads);
  }
}

async function setPosts(boardID, threadID) {
  const response = await fetch('https://localhost:5001/api/posts');

  if (response.ok) {
    const data = await response.json();
    const posts = data.filter(p => p.threadID == threadID);

    SET_POSTS(boardID, threadID, posts);
  }
}

// getters
function getThreads(boardID) {
  const board = store.boards.find(b => b.boardID == boardID);

  return board.threads;
}

function getPosts(boardID, threadID) {
  const board = store.boards.find(b => b.boardID == boardID);
  const thread = board.threads.find(t => t.threadID == threadID);

  return thread.posts;
}

export {
  store,
  setBoards,
  setThreads,
  setPosts,
  getThreads,
  getPosts
}
