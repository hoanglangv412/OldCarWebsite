export default [
  {
    _name: 'CSidebarNav',
    _children: [
      {
        _name: 'CSidebarNavItem',
        name: 'Dashboard',
        to: '/dashboard',
        icon: 'cil-speedometer',
        badge: {
          color: 'primary',
          text: 'NEW'
        }
      },
      {
        _name: 'CSidebarNavTitle',
        _children: ['Normal User']
      },
      // {
      //   _name: 'CSidebarNavItem',
      //   name: 'Home',
      //   to: '/Home/Home',
      //   icon: 'cil-drop',
      // },
      // {
      //   _name: 'CSidebarNavItem',
      //   name: 'Carversion',
      //   to: '/Carversion/Carversion',
      //   icon: 'cil-drop',
      // },
      // {
      //   _name: 'CSidebarNavItem',
      //   name: 'Post',
      //   to: '/Post/Post',
      //   icon: 'cil-drop',
      // },
      // {
      //   _name: 'CSidebarNavItem',
      //   name: 'Car',
      //   to: '/Car/Car',
      //   icon: 'cil-drop'
      // },
      // {
      //   _name: 'CSidebarNavItem',
      //   name: 'Customer',
      //   to: '/customer/Customer',
      //   icon: 'cil-drop'
      // },
    ]
  }
]
