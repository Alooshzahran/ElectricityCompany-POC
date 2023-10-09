

//$(document).on('click', '.EditAnnouncementAttachment', function (sender) {
//    //  debugger;
//    var ID = $(this).attr("data-value");
//    var URL = $("#Announcement_AnnouncementAttachment_" + ID + "__URL").val();
    


//    $('#AnnouncementAttachmentID').val(ID);
//    $('#URL').val(FirstName);
  

//});



//$(document).on('click', '.DeleteAnnouncementAttachment', function (sender) {
//     debugger;
//    var ID = $(this).attr("data-value");

//    function Delete(ID)
//    $("#AnnouncementAttachment_" + ID).remove();

//    $("#TableAnnouncementAttachments tbody tr").each(function (index) {
//        $(this).attr("id", "AnnouncementAttachment_" + index);
//        var inputs = $(this).find("td").first().find("input");

//        debugger;
//        $(inputs[0]).attr("id", "Announcement_AnnouncementAttachment_" + index + "__ID");
//        $(inputs[0]).attr("name", "customerInfo.AnnouncementAttachment[" + index + "].ID");

//        $(inputs[1]).attr("id", "Announcement_AnnouncementAttachment_" + index + "__URL");
//        $(inputs[1]).attr("name", "Announcement.AnnouncementAttachment[" + index + "].URL");

       



//    });


//});


function DeleteAttachment(id) {
    swal({
        title: "Are you sure?",
        text: "You will not be able to recover this imaginary file!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        cancelButtonText: "No, cancel !",
        closeOnConfirm: false,
        closeOnCancel: false
    },
        function (isConfirm) {
            if (isConfirm) {
                {
                    //debugger;
                    $.ajax({
                        url: "/AnnouncementAttachment/DeleteAttachment",

                        type: 'DELETE',
                        data: {
                            ID: id
                        },
                        success: function (result) {
                            debugger;
                            // Do something
                            swal("Deleted!", "Your imaginary file has been deleted.", "success");

                            /*
                            jQuery(document).ready(function(){
                                jQuery('tbody > tr:first > td:nth-child(6) > input').prop("checked", true);
                            }); 
                            */
                            $("[data-value*='"+id+"']").closest("tr").remove();

                            //$('#tr_' + id).remove();
                            //$('tbody > tr:first > td > input[type=checkbox]').prop("checked", true);


                            //$('#DataTables_Table_0').load(' #DataTables_Table_0');

                            //    $('#tr_' + id).remove();
                            //setInterval('location.reload()', 500);
                        },

                        error: function (result) {
                            debugger;
                            swal("Error Occurred While Operation!", {
                                icon: "error",
                            });
                        }
                    });
                }
            } else {
                swal("Cancelled", "Your imaginary file is safe :)", "error");
            }
        });
}
///////////////////////////////////////// YourWork
//$(document).ready(function () {


//    $('#OneMoreAnnouncementAttachment').on("click", function (e) {
//        e.preventDefault();

//        debugger;
//        /*********************************************
//                EMPTY THE ERROR MESSAGES
//        *********************************************/
//        $('#URL').text('');
      
       
//        /*********************************************
//            End Of => EMPTY THE ERROR MESSAGES
//        *********************************************/

//        var rowCount = $('#AddEditAnnouncementAttachment tbody tr').length;

//        var AnnouncementAttachment = {};

//        var ID = $('#AnnouncementAttachmentID').val();
//        if (ID != "") {
//            rowCount = ID;
//        }

//        var URL = $('#URL').val();


//        AnnouncementAttachment = {
//            "ID": ID,
//            "URL": URL
          



//        }
     
//        $('#AddEditAnnouncementAttachment').css("visibility", "visible");

//        $.post('/CustomerInfo/ContactInfo', { AnnouncementAttachment, rowCount }, function (result) {



//            if (AnnouncementAttachment.ID == "") {

//                $("#AnnouncementAttachments").append(result);
//            } else {
//                var SelectedRow = $("#AnnouncementAttachment_" + AnnouncementAttachment.ID);
//                $(SelectedRow).replaceWith(result);

//            }

//            $('#RowId').attr('id', 'ROW');
//        };
        //     else {
        //       result.errors

        //        debugger;
        //        PrintErrorsInContactInfo(ErrorMessages);
        //     }



        //});
        // } else {
        //     //debugger;
        //     
        //  }

//    });
//});

//function PrintErrorsInContactInfo(ErrorMessages) {
//    console.log(ErrorMessages);
//    //debugger;
//    $.each(ErrorMessages, function (key, value) {
//        //debugger;
//        var index = ErrorMessages[key]["name"];
//        var error = ErrorMessages[key]["error"];
//        switch (index) {
//            case "PrefixID":
//                $('#ErrPrefixID').text(error);
//                break;
//            case "FirstName":
//                $('#ErrFirstName').text(error);
//                break;
//            case "LastName":
//                $('#ErrLastName').text(error);
//                break;
//            case "Email":
//                $('#ErrEmail').text(error);
//                break;
//            case "CountryKey":
//                $('#ErrCountryKey').text(error);
//                break;
//            case "Mobile":
//                $('#ErrMobile').text(error);
//                break;
//            case "Phone":
//                $('#ErrPhone').text(error);
//                break;
//            case "ExtensionNo":
//                $('#ErrExtensionNo').text(error);
//                break;
//            case "DirectPhone":
//                $('#ErrDirectPhone').text(error);
//                break;
//            case "DepartmentID":
//                $('#ErrDepartmentID').text(error);
//                break;
//            case "Position":
//                $('#ErrPosition').text(error);
//                break;
//            case "SeniorityID":
//                $('#ErrSeniorityID').text(error);
//                break;
//            case "RoleID":
//                $('#ErrRoleID').text(error);
//                break;
//        }


//    });


//    return ErrorMessages;
//}





