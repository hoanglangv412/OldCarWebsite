export default [
    {
      _name: 'CSidebarNav',
      _children: [
        {
          _name: 'CSidebarNavTitle',
          _children: ['Admin']
        },
        {
          _name: 'CSidebarNavItem',
          name: 'Carversion',
          to: '/Carversion/Carversion',
          icon: 'cil-drop',
        },
        {
          _name: 'CSidebarNavItem',
          name: 'Car',
          to: '/Car/Car',
          icon: 'cil-drop',
        },
        {
          _name: 'CSidebarNavItem',
          name: 'Customer',
          to: '/customer/Customer',
          icon: 'cil-drop'
        },
      ]
    }
  ]
  