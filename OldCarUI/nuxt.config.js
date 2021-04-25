
export default {
  mode: 'spa',
  /*
  ** Headers of the page
  */
  head: {
    title: process.env.npm_package_name || '',
    meta: [
      { charset: 'utf-8' },
      { name: 'viewport', content: 'width=device-width, initial-scale=1' },
      { hid: 'description', name: 'description', content: process.env.npm_package_description || '' }
    ],
    link: [
      { rel: 'icon', type: 'image/x-icon', href: '/favicon.ico' },
      {
        rel: "stylesheet",
        type: "text/css",
        href:
          "https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"
      }
    ],
    script: [
      {
        src: "https://code.jquery.com/jquery-3.6.0.js",
        type: "text/javascript"
      },
      {
        src:
          "https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js",
        type: "text/javascript"
      },
      {
        src:
          "https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js",
        type: "text/javascript"
      },
      {
        src:
          "https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js",
        type: "text/javascript"
      }
    ]
  },
  /*
  ** Customize the progress-bar color
  */
  loading: { color: '#fff' },
  /*
  ** Global CSS
  */
  css: [
    { src: '~/assets/scss/style.scss', lang: 'scss' }
  ],

  styleResources: {
    scss: [
      '~/assets/scss/_variables.scss',
      '~/assets/scss/_mixins.scss'
    ]
  },
  /*
  ** Plugins to load before mounting the App
  */
  plugins: [
    { src: '~/plugins/coreui' }
  ],
  /*
  ** Nuxt.js dev-modules
  */
  buildModules: [
    // Doc: https://github.com/nuxt-community/eslint-module
    // '@nuxtjs/eslint-module'
    // Simple usage
    '@nuxtjs/vuetify',
  ],
  /*
  ** Nuxt.js modules
  */
  modules: [
    // https://go.nuxtjs.dev/bootstrap
    "bootstrap-vue/nuxt",
    //auth nuxtjs
    "@nuxtjs/axios",
    "@nuxtjs/auth",
    '@nuxtjs/auth-next',
  ],
  /*
  ** Axios module configuration
  ** See https://axios.nuxtjs.org/options
  */
  axios: {
  },
  /*
  ** Build configuration
  */
  build: {
  },

  //set base url
  axios: {
    baseURL: "https://localhost:44343/api/"
  },
  // router: {
  //   middleware: ['auth']
  // },
  auth: {
    strategies: {
      local: {
        token: {
          property: "access_token",
          required: true,
          type: "Bearer"
        },
        // user: {
        //   property: "user"
        //   // autoFetch: true
        // },
        endpoints: {
          login: {
            url: "/login",
            method: "post",
            propertyName: "access_token"
          },
          logout: true,
          user: {
            url: "/user",
            method: "get",
            propertyName: "data"
          }
        }
      }
    }
  }
}
