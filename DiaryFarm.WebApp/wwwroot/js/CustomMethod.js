$(document).ready(function () {

    //define all global vriables
    //#region


    //#endregion





    //all load events code here
    //#region



    //#endregion




    //Events code here
    //#region


    //#endregion



    //define all functions here
    //#region

    function showMessage(Message, type) {
        toastr.options = {
            positionClass: 'toast-top-full-width',
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