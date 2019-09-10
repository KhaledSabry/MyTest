function SetBusy(element, hide) {
    if (hide === true) {
        element.LoadingOverlay("hide");
    } else {
        element.LoadingOverlay("show", {
            image: "",
            fontawesome: "fa fa-spinner fa-spin"
        });
    }
}
function SendGet(url,successFun) {
    
    try {
        $.ajax({
            type: "GET",
            url: url,
            contentType: "application/json;charset=utf-8",
            traditional: true, 
            dataType: "json",
            cache: false, 
            success: function (data, textStatus, xhr) {
                if (xhr.status === 200) {
                    successFun(data);
                }
                else
                    Message("Unknown error occurred.", "err");
            },
            error: errorHandeller
        });
    }
    catch (err) {
        alert(err.message);
    }
}
function SendPost(url, data, successFun) { 
    try {
        $.ajax({
            type: "POST",
            url: url, 
            contentType: "application/json;charset=utf-8",
            traditional: true,
            data: JSON.stringify(data),
            dataType: "json",
            cache: false,
            //beforeSend: function (xhr) {
            //    /* Authorization header */
            //    xhr.setRequestHeader("Authorization", "Basic " + Utils.getUsernamePassword());
            //    xhr.setRequestHeader("X-Mobile", "false");
            //},
            success: function (data, textStatus, xhr) {
                if (xhr.status === 200) {
                    successFun(data);
                }
                else
                    Message("Unknown error occurred.", "err");
            },
            error: errorHandeller
        });
    }
    catch (err) {
        alert(err.message);
    }
}
function SendDelete(url, successFun) { 
    try {
        $.ajax({
            type: "DELETE",
            url: url,
            contentType: "application/json;charset=utf-8",
            traditional: true, 
            dataType: "json",
            cache: false,
            //beforeSend: function (xhr) {
            //    /* Authorization header */
            //    xhr.setRequestHeader("Authorization", "Basic " + Utils.getUsernamePassword());
            //    xhr.setRequestHeader("X-Mobile", "false");
            //},
            success: function (data, textStatus, xhr) {
                if (xhr.status === 200) {
                    successFun(data);
                }
                else
                    Message("Unknown error occurred.", "err");
            },
            error: errorHandeller
        });
    }
    catch (err) {
        alert(err.message);
    }
}
var errorHandeller= function (e, x, settings, exception) {
    var message;
    var statusErrorMap = {
        '400': "Server understood the request, but request content was invalid.",
        '401': "Unauthorized access.",
        '403': "Forbidden resource can't be accessed.",
        '500': "Internal server error.",
        '503': "Service unavailable."
    };
    if (x.status) {
        message = statusErrorMap[x.status];
        if (!message) {
            message = "Unknown Error \n.";
        }
    } else if (exception === 'parsererror') {
        message = "Error.\nParsing JSON Request failed.";
    } else if (exception === 'timeout') {
        message = "Request Time out.";
    } else if (exception === 'abort') {
        message = "Request was aborted by the server";
    } else {
        message = "Unknown Error \n.";
    }

    Message(message, "err");
}
function Confirm(text, ConfirmedFun) {  //https://limonte.github.io/sweetalert2/
    swal({
        title: "Are you sure?",
        text: text,
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: "Yes",
        cancelButtonText: "No"
    }).then(
        ConfirmedFun
        , function (dismiss) {
            // dismiss can be 'cancel', 'overlay',
            // 'close', and 'timer'
            //if (dismiss === 'cancel') {
            //    swal(
            //      'Cancelled',
            //      'Your imaginary file is safe :)',
            //      'error'
            //    )
            //}
        });
}
function Message(txt, MessageType) {
    //    //http://t4t5.github.io/sweetalert/ 
    //    //$("#ErrorDiv").hide();
    //    //$("#WarningDiv").hide();
    //    //$("#InfoDiv").hide();
    //    //$("#SuccessDiv").hide();

    switch (MessageType) {
        case "err":
        case 1:
            swal("Error", txt, "error");
            //$("#ErrorDiv").show();
            //$("#ErrorDiv").text(txt);
            break;
        case 2:
        case "wrn":
            swal("warning", txt, "warning");
            //$("#WarningDiv").show();
            //$("#WarningDiv").text(txt);
            break;
        case "suc":
        case 3:
            swal("success", txt, "success");
            // $("#SuccessDiv").show();
            // $("#SuccessDiv").text(txt);
            break;
        case "inf":
        case 4:
            swal("Info", txt, "info");
            //$("#InfoDiv").show();
            //$("#InfoDiv").text(txt);
            break;
    }
}