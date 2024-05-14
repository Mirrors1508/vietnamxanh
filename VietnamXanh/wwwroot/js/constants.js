var CONSTANTS = {
    APIs: {
        UserLogin:'/api/user/login'
    },
    DomainURLs: {
        Dashboard:'/Dashboard'
    },
    ReponseStatus: {
         SUCCESS : 0,
        FAILED : 1,
         EMPTY : 2,
         ERROR : 3,
    },
    Notification: {
        IncorrectUsername: `Tên tài khoản không được bỏ trống`,
        IncorrectPassword: `Mật khẩu không được bỏ trống`,
        SpecialCharacter: `Tên tài khoản không được chứa ký tự đặc biệt (ngoại trừ [_] , [@] , [.])`,
        LoginSuccessful: `Đăng nhập thành công, đang chuyển hướng`,
        OnLogging: `Đang đăng nhập, vui lòng chờ`
    },
}