var _service = {
    Login: function (usr,pwd) {
       
        var data = {
            "username": usr,
            "password": pwd,
        }
        return ajaxServices.post(CONSTANTS.APIs.UserLogin, data)

    },
}