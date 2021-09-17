<template>
  <div class="container">
    <h1 class="main-title">
      VASPChan
    </h1>

    <router-view></router-view>
  </div>
</template>

<style>
  @import './assets/normalize.css';
  @import './assets/grid.css';

  :root {
    --drc-bg: #282a36;
    --drc-comment: #6272a4;
    --drc-selection: #44475a;
  }

  * {
    color: #f8f8f2;
  }

  html {
    font-size: 16px;
    background-color: var(--drc-bg);
  }

  p:first-child {
    margin-top: 0;
  }

  p:last-child {
    margin-bottom: 0;
  }

  .main-title {
    text-align: center;
  }
</style>
