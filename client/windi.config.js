// @ts-check - enable TS check for js file
import { defineConfig } from 'windicss/helpers'

export default defineConfig({
  theme: {
    container: {
      center: true,
      padding: '2rem'
    },
    extend: {
      colors: {
        dracula: {
          bg: '#282a36',
          comment: '#6272a4',
          selection: '#44475a'
        }
      }
    },
    extract: {
      include: [
        './src/**/*.{vue}',
      ],
    },
  }
})
