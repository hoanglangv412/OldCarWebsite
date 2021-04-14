<template>
  <div id="TheHome" class="columns">
    <div class="column">
      <button class="is-primary button" @click="shuffle">Shuffle!</button>
      <tweet-component v-for="tweet in tweets" :key="tweet" :tweet="tweet" />
    </div>
  </div>
</template>
<script>
const Vue = window.vue
const tweets = [
  {
    id: 1,
    name: 'James',
    handle: '@jokerjames',
    img: 'https://semantic-ui.com/images/avatar2/large/matthew.png',
    tweet: "If you don't succeed, dust yourself off and try again.",
    likes: 10,
  },
  { 
    id: 2,
    name: 'Fatima',
    handle: '@fantasticfatima',
    img: 'https://semantic-ui.com/images/avatar2/large/molly.png',
    tweet: 'Better late than never but never late is better.',
    likes: 12,
  },
  {
    id: 3,
    name: 'Xin',
    handle: '@xeroxin',
    img: 'https://semantic-ui.com/images/avatar2/large/elyse.png',
    tweet: 'Beauty in the struggle, ugliness in the success.',
    likes: 18,
  }
]
Vue.component('tweet-component', {
  template: `
    <div class="tweet">
      <div class="box">
        <article class="media">
          <div class="media-left">
            <figure class="image is-64x64">
              <img :src="tweet.img" alt="Image">
            </figure>
          </div>
          <div class="media-content">
            <div class="content">
              <p>
                <strong>{{tweet.name}}</strong> <small>{{tweet.handle}}</small>
                <br>
                {{tweet.tweet}}
              </p>
            </div>
              <div class="level-left">
                <a class="level-item">
                  <span class="icon is-small"><i class="fas fa-heart"></i></span>
                  <span class="likes">{{tweet.likes}}</span>
                </a>
              </div>
          </div>
        </article>
      </div>
      <div class="control has-icons-left has-icons-right">
        <input class="input is-small" placeholder="Tweet your reply..." />
        <span class="icon is-small is-left">
          <i class="fas fa-envelope"></i>
        </span>
      </div>
    </div> 
  `,
  props: {
    tweet: Object
  }
});

new Vue({
  el: '#TheHome',
  data: {
    tweets
  },
  methods: {
    shuffle() {
      this.tweets = _.shuffle(this.tweets)
    }
  }
});
</script>

<style>
html, body {
  height: 100%;
  padding-top: 10px;
  background: #e6ecf1;
}

#app {
  height: 100%;
  padding-top: 0px;
  text-align: center;
}

#app .button {
  margin-bottom: 20px;
}

#app .tweet {
  max-width: 500px;
  margin: 0 auto;
  padding-bottom: 15px;
}

#app .box {
  margin-bottom: 0;
  border-radius: 0;
}

#app .content small {
  color: #00d1b2;
}

#app img {
  border-radius: 30px;
}

#app .level-item {
  padding-left: 10px;
  color: #00d1b2;
}

#app input:focus {
  border-color: #00d1b2;  
}

#app .likes {
  padding: 0 7.5px;
}

#app input {
  font-weight: bold;
}

#app .tweets-move {
  transition: transform 1s;
}
</style>