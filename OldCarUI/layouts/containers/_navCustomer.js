export default [
  {
    _name: 'CSidebarNav',
    _children: [
      {
        _name: 'CSidebarNavTitle',
        _children: ['Customer']
      },
      {
        _name: 'CSidebarNavItem',
        name: 'Home',
        to: '/Home/Home',
        icon: 'cil-drop',
      },
      {
        _name: 'CSidebarNavItem',
        name: 'Post',
        to: '/Post/Post',
        icon: 'cil-drop',
      },
    ]
  }
]
