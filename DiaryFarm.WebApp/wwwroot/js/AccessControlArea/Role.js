$(document).ready(function () {

    //define all global vriables
    //#region
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: "btn btn-success",
            cancelButton: "btn btn-danger"
        },
        buttonsStyling: false
    });
    var EditId = null;
    //#endregion





    //all load events code here
    //#region

    LoadAllRoles();

    //#endregion




    //Events code here
    //#region

    $('#btnAddRole').click(function (e) {
        e.preventDefault();
        showModal();
    });

    $('.close').click(function (e) {
        e.preventDefault();
        hideModal();
    });

    $('#btnSaveRole').click(function (e) {
        e.preventDefault();
        var role = $('#txtRole').val();
        if (role == null || role == undefined || role == "") {
            showMessage('Role Is Required', 'error');
            return;
        }
        showspinner();
        SaveRecord(role);
    });

    $('#tblRoles').on('click','.btnedit',function (e) {
        e.preventDefault();
        var Id = $(this).attr('data-Id');
        var role = $(this).attr('data-role');
        $('#txtRole').val(role);
        EditId = Id;
        showModal();

    });

    $('#tblRoles').on('click', '.btndelete', function (e) {
        e.preventDefault();
        var Id = $(this).attr('data-Id');
        var row = $(this).closest('tr');
        deleteRecord(Id);

    });


    //#endregion



    //define all functions here
    //#region
    function showspinner() {
        $('#btnSaveRole').html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>Loading...').prop('disabled', true);
    }
    function hidespinner() {
        $('#btnSaveRole').html('Save changes').prop('disabled', true);
    }
    function showModal() {
        $('#RoleModal').modal('show');
    }
    function hideModal(name) {
        $('#RoleModal').modal('hide');
    }

    function LoadAllRoles() {
        if ($.fn.DataTable.isDataTable('#tblRoles')) {
            $('#tblRoles').DataTable().destroy();
        }
        $.ajax({
            type: "Get",
            url: "/Admin/Role/ViewAllRoles",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                $('#tblRoles').DataTable({
                    data: response,
                    columns: [
                        { data: 'id' },
                        { data: 'role' },
                        {
                            data: null,
                            render: function (data) {
                                return '<button class="btn btn-warning me-1 btnedit" data-Id="' + data.id + '" data-role="' + data.role + '"><i class="bi bi-pencil-square"></i></button><button class="btn btn-danger btndelete" data-Id="' + data.id + '"><i class="bi bi-trash"></i></button>';
                            }
                        }
                    ],
                    columnDefs: [
                        {
                            targets: [0],
                            visible: false,
                        },
                        {
                            targets: [],
                            orderable: false,
                        }
                    ],
                    responsive: true
                });
            },
            failure: function (response) {
                showMessage(response.d,'error');
            }
        });
    }

    function SaveRecord(role) {
        if (EditId == null) {
            var data = {
                Role: role
            };
            $.ajax({
                url: '/Admin/Role/SaveRole',
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(data),
                success: function (response) {
                    debugger;
                    if (response.isSuccess) {
                        showMessage(response.message, 'success');
                        hideModal();
                        hidespinner();
                        clear();
                        LoadAllRoles();
                    } else {
                        showMessage(response.message, 'error');
                        hideModal();
                        clear();
                        hidespinner();

                    }
                },
                error: function (xhr, textStatus, errorThrown) {
                    showMessage(xhr.responseText, 'error');
                    hideModal();
                    hidespinner();
                    clear();
                }
            });
        } else {
            var data = {
                Id: EditId,
                Role: role
            };
            $.ajax({
                url: '/Admin/Role/UpdateRole',
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(data),
                success: function (response) {
                    debugger;
                    if (response.isSuccess) {
                        showMessage(response.message, 'success');
                        hideModal();
                        hidespinner();
                        clear();
                        LoadAllRoles();
                    } else {
                        showMessage(response.message, 'error');
                        hideModal();
                        clear();
                        hidespinner();

                    }
                },
                error: function (xhr, textStatus, errorThrown) {
                    showMessage(xhr.responseText, 'error');
                    hideModal();
                    hidespinner();
                    clear();
                }
            });
        }
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


    function deleteRecord(Id) {
        swalWithBootstrapButtons.fire({
            title: "Are you sure?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes, delete it!",
            cancelButtonText: "No, cancel!",
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: '/Admin/Role/DeleteRole',
                    type: 'POST',
                    contentType: 'application/json',
                    data: JSON.stringify(Id),
                    success: function (response) {
                        debugger;
                        if (response.isSuccess) {
                            swalWithBootstrapButtons.fire({
                                title: "Deleted!",
                                text: "Your file has been deleted.",
                                icon: "success"
                            });
                            LoadAllRoles();
                        } else {
                            swalWithBootstrapButtons.fire({
                                title: "Error",
                                text: "An error occurred while deleting the file.",
                                icon: "error"
                            });

                        }
                    },
                    error: function (xhr, textStatus, errorThrown) {
                        swalWithBootstrapButtons.fire({
                            title: "Error",
                            text: "An error occurred while deleting the file.",
                            icon: "error"
                        });
                    }
                });
            } else if (
                result.dismiss === Swal.DismissReason.cancel
            ) {
                swalWithBootstrapButtons.fire({
                    title: "Cancelled",
                    text: "Your imaginary file is safe :)",
                    icon: "error"
                });
            }
        });
    }


    function clear() {
        $('#txtRole').val('');
        EditId = null;
    }

    //#endregion


});