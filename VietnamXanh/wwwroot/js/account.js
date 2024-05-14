$(document).ready(function () {
    _account.Initialization()

})
var _account = {
    LoadingLogin: '',
    Loaded: false,
    Success:false,
    Initialization: function () {
        _account.DynamicBind()
    },
    DynamicBind: function () {
        $("body").on('keyup', ".login-input", function () {
            $('.field-validation-valid').html('')
        });
        $("body").on('click', ".btn-login", function () {
            _account.Login()
        });
    },
    Login: function () {
        _account.LoopDisplayLoading()
        $('.btn-login').attr('disabled', true);

        $('.field-validation-valid').html('')
        if (!_account.ValidateLogin()) {
            return
        }
        var usr = $('#user-name').val()
        var pwd = $('#password').val()
        $.when(
            _service.Login(usr, pwd)

        ).done(function (output) {
            if (output != null && output != undefined) {
                if (output.status === CONSTANTS.ReponseStatus.SUCCESS) {
                    _account.Loaded = true
                    _account.Success =true
                    setTimeout(function () {
                        var url = $('#form-login').attr('data-url')
                        if (url == null || url == undefined || url.trim() == '') {
                            window.location.href = CONSTANTS.DomainURLs.Dashboard
                        } else {
                            window.location.href = url
                        }

                    }, 3000);
                }
                else {
                    $('#validate-msg').html(output.msg);
                    _account.StopLoopDisplayLoading()

                }
               
            } else {
                window.location.reload()
            }
        })
    },
    ValidateLogin: function () {
        var usr = $('#user-name').val()
        var pwd = $('#password').val()
        if (usr == null || usr == undefined || usr.trim() == '') {
            $('#validate-username').html(CONSTANTS.Notification.IncorrectUsername)
            _account.StopLoopDisplayLoading()

            return false;
        }
        if (_account.CheckIfSpecialCharracter(usr)) {
            $('#validate-username').html(CONSTANTS.Notification.SpecialCharacter)
            _account.StopLoopDisplayLoading()

            return false;
        }
        if (pwd == null || pwd == undefined || pwd.trim() == '') {
            $('#validate-password').html(CONSTANTS.Notification.IncorrectPassword)
            _account.StopLoopDisplayLoading()
            return false;

        }

        return true;
    },
    CheckIfSpecialCharracter: function (text) {
        if (text == null || text == undefined || text.trim() == '') {
            return false
        }
        return text.match(/[^a-zA-Z0-9_.@]/g) ? true : false;
    },
    LoopDisplayLoading: function () {
        setTimeout(function () {
            if (_account.LoadingLogin.trim() == '...') _account.LoadingLogin = ''
            $('.btn-login').html(CONSTANTS.Notification.OnLogging + _account.LoadingLogin)
            _account.LoadingLogin = _account.LoadingLogin + '.'
            if (!_account.Loaded) _account.LoopDisplayLoading()
            else {
                if (_account.Success) {
                    $('.btn-login').html(CONSTANTS.Notification.LoginSuccessful)
                } else {
                    $('.btn-login').html(`<i class="fa fa-sign-in"></i>Đăng nhập`)
                }
            }

        }, 1000)
    },
    StopLoopDisplayLoading: function () {
        _account.Loaded = true
        _account.Success = false
        $('.btn-login').attr('disabled', false);

    }
}