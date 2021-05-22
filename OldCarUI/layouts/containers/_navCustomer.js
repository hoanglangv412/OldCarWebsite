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
        name: 'Trang chủ',
        to: '/Home/Home',
        icon: 'cil-drop',
      },
      {
        _name: 'CSidebarNavItem',
        name: 'Quản lí bài đăng',
        to: '/Post/Post',
        icon: 'cil-drop',
      },
      {
        _name: 'CSidebarNavItem',
        name: 'Quản lí dòng xe',
        to: '/Carversion/Carversion',
        icon: 'cil-drop',
      },
      {
        _name: 'CSidebarNavItem',
        name: 'Quản lí xe',
        to: '/Car/Car',
        icon: 'cil-drop',
      },
      {
        _name: 'CSidebarNavItem',
        name: 'Quản lí người dùng',
        to: '/customer/Customer',
        icon: 'cil-drop'
      },
      {
        _name: 'CSidebarNavItem',
        name: 'Danh sách xe',
        to: '/Home/HomeCarForPost',
        icon: 'cil-drop'
      },
      {
        _name: 'CSidebarNavItem',
        name: 'Thống kê',
        to: '/Report/Report',
        icon: 'cil-drop'
      },
    ]
  }
]
