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
          _children: ['Theme']
        },
        {
          _name: 'CSidebarNavItem',
          name: 'Home',
          to: '/Home/Home',
          icon: 'cil-drop',
        },
        {
          _name: 'CSidebarNavItem',
          name: 'Carversion',
          to: '/Carversion/Carversion',
          icon: 'cil-drop',
        },
        {
          _name: 'CSidebarNavItem',
          name: 'Account',
          to: '/account/Account',
          icon: 'cil-drop'
        },
        {
          _name: 'CSidebarNavItem',
          name: 'Customer',
          to: '/customer/Customer',
          icon: 'cil-drop'
        },
        {
          _name: 'CSidebarNavItem',
          name: 'Login',
          to: '/Login/Login',
          icon: 'cil-drop'
        },
        {
          _name: 'CSidebarNavItem',
          name: 'Typography',
          to: '/theme/typography',
          icon: 'cil-pencil'
        },
      ]
    }
  ]
  