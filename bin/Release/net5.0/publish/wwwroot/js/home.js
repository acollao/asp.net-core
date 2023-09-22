function DisplayProgressMessage() {

	$("#submitButton").prop('disabled', true);
	$("#submitButton").attr('value', "Uploading...");
	$("#loader").show();
	var form = $("#frmTransaction");
	form.submit();
}

//function checkLock(fileName, controller, isLocked) {

//    $("#loader").show();
//    var filename = fileName;
//    var controllerName = controller;
//    var isLock = isLocked;

//    $.ajax({
//        type: "POST",
//        url: "/Home/CheckLock",
//        data: {
//            controllerName: controllerName,
//            isLocked: isLock
//        },
//        success: function (canAllow) {

//            if (canAllow == "true") {
//                lockAsync(filename, isLocked);
//            }
//            else
//            {
//                $("#loader").hide();
//                alert('File is locked by another user.');
//            }

//        },
//        error: function (xhr, ajaxOptions, thrownError) {
//            $("#loader").hide();
//            alert('An error occurred. Please contact an admin.');
//        }
//    });
//}


//function lockAsync(filename, controller, isLocked) {

//    $("#loader").show();

//    $.ajax({
//        type: "POST",
//        url: "/Home/LockAsync",
//        data: {
//            filename: filename,
//            controller: controller,
//            isLocked: isLocked
//        },
//        success: function (status) {
//            $("#loader").hide();

//            /*alert(status);*/
//            returnHome(status);
//            //location.reload(true); 
//        },
//        error: function (xhr, ajaxOptions, thrownError) {
//            $("#loader").hide();
//            alert('An error occurred. Please contact an admin.');
//        }
//    });
//}


//function returnHome(status) {

//    $.ajax({
//        /*type: "Get",*/
//        url: "/Home/Index",
//        success: function () {
//            alert(status);
//        },
//        error: function (xhr, ajaxOptions, thrownError) {
//            $("#loader").hide();
//            alert('An error occurred. Please contact an admin.');
//        }
//    });
//}