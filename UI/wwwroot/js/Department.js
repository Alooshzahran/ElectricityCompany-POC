//$(document).on("change", "#SectionID", function (SectionID) {

//    //debugger;
//    $.ajax({
//        url: "/Department/GetDepartmentsBySectionID",
//        data: { SectionID: SectionID.target.value },
//        type: "GET",
//        success: function (result) {

//            //debugger;
//            $("#DepartmentID").empty();

//            $.each(result, function (index, value) {


//                $("#DepartmentID").append($('<option/>', {

//                    value: value.id,
//                    text: value.name
//                }));
//            });

//        }
//    });
//});

//$(document).ready(function () {
//    //debugger;
//    var SectionID = $("#SectionID").val();
//    $.ajax({
//        url: "/Department/GetDepartmentsBySectionID",
//        data: { SectionID: SectionID },
//        type: "GET",
//        success: function (result) {

//            //debugger;
//            $("#DepartmentID").empty();

//            $.each(result, function (index, value) {


//                $("#DepartmentID").append($('<option/>', {

//                    value: value.id,
//                    text: value.name
//                }));
//            });

//        }
//    });
//});
