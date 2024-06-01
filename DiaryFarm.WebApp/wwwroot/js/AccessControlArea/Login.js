$(document).ready(function () {

    //define all global vriables
    //#region


    //#endregion





    //all load events code here
    //#region



    //#endregion




    //Events code here
    //#region

    $('#btnlogin').click(function (e) {
        e.preventDefault();
        debugger;
        var $btn = $(this);
        $btn.prop("disabled", true).text("Please Wait...");

        var username = $('#txtusername').val().trim();
        var password = $('#txtpassword').val().trim();

        if (!username || !password) {
            showMessage("Please Fill Mandatory Fields", "error");
            resetButton($btn);
            return;
        }

        loginUser(username, password);
    });



    //#endregion



    //define all functions here
    //#region


    function resetButton($btn) {
        $btn.prop("disabled", false).text("Login");
    }
    function loginUser(username, password) {
        debugger;
        var model = {
            username: username,
            password: password
        };
        $.ajax({
            url: '/AccessControlArea/AccessControl/Login',
            method: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(model),
            /*data: JSON.stringify({ password: password, username: username}),*/
            success: function (data) {
                if (data.success == true) {
                    window.location.href = '/Admin/Dashboard/Analytics';
                }
                else {
                    showMessage(data.message, "error");
                    resetButton($('#btnlogin'));
                }
            },
            error: function (error) {
                showMessage("An error occurred", "error");
                resetButton($('#btnlogin'));
            }
        });
    }

    function showMessage(Message, type) {
        toastr.options = {
            /*positionClass: 'toast-top-full-width',*/
            toastClass: 'custom-toastr',
            closeMethod: 'fadeout',
            timeOut: 2000
        };
        if (type == "info")
            toastr.info(Message);
        else if (type == "success")
            toastr.success(Message);
        else if (type == "error")
            toastr.error(Message);

    }



    //#endregion


});