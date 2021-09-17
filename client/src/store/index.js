import { createPinia, defineStore } from 'pinia'
import axios from 'axios';

export const store = createPinia();

// useStore could be anything like useUser, useCart
// the first argument is a unique id of the store across your application
export const useStore = defineStore('main', {
  state: () => {
    return {
      // all these properties will have their type inferred automatically
      boards: {},
      errors: false,
    }
  },
  actions: {
    async setBoards() {
      const { data } = await axios.get('https://localhost:5001/api/boards');

      data.forEach(board => {
        this.boards[board.name] = board;
      });

      if (!data) {
        this.setErrors(true)
      }
    },
    async setThreads(boardID) {
      if (!Object.keys(this.boards).length) {
        await this.setBoards(boardID);
      }

      const { data } = await axios.get(`https://localhost:5001/api/threads/${boardID}`);

      for (const board in this.boards) {
        if (Object.hasOwnProperty.call(this.boards, board)) {
          this.boards[boardID].threads = data.threads;
        }
      };

      if (!data) {
        this.setErrors(true)
      }
    },
    setErrors(errors) {
      this.errors = errors;
    }
  }
})
