function viewImages(input) {
    debugger;
    var ExistRowCount=$('#AddEditAnnouncementAttachment tbody tr').length;
    var files = input.files;
    $('#imgs img').remove();

    if (files.length > 0) {
        $.each(files, function (index) {
            var reader = new FileReader();
            reader.onload = function (e) {
                debugger;
                $("#imgs").append("<img/>");
                //$("#imgs a:last-child").attr("href", e.target.result);
                //$("#imgs a:last-child").append("<img/>");

                var img = $("#imgs img:last-child");//.find("img");
                $(img).attr('src', e.target.result);
                $(img).width(150);
                $(img).height(200);

                //    $("#imgs").children().last().attr("href", e.target.result);
                //$("#imgs").children().last().append("<img/>");
                //$('#imgs').children().last().Children().first().attr('src', e.target.result)
                //    $('#imgs').children().last().Children().first().width(150)
                //    $('#imgs').children().last().Children().first().height(200);
            };
            //reader.readAsDataURL(input.files[index]);
            debugger;
            $('#URL').text('');


            /*********************************************
                End Of => EMPTY THE ERROR MESSAGES
            *********************************************/

            //var rowCount = index;// $('#AddEditAnnouncementAttachment tbody tr').length;
            var rowCount = index + ExistRowCount;// $('#AddEditAnnouncementAttachment tbody tr').length;
            var AnnouncementAttachment = {};

            var ID = rowCount;// $('#AnnouncementAttachmentID').val();
            //if (ID != "") {
            //    rowCount = ID;
            //}

            var url = URL.createObjectURL(files[index]);// reader.readAsDataURL(input.files[index]);// $('#URL').val();


            AnnouncementAttachment = {
                "ID": ID,
                "URL": url




            }

            $('#AddEditAnnouncementAttachment').css("visibility", "visible");

            $.post('/Announcement/AnnouncementAttachment', { AnnouncementAttachment, rowCount }, function (result) {

                $("#AnnouncementAttachments").append(result);

                //if (AnnouncementAttachment.ID == "") {

                //    $("#AnnouncementAttachments").append(result);
                //} else {
                //    var SelectedRow = $("#AnnouncementAttachment_" + AnnouncementAttachment.ID);
                //    $(SelectedRow).replaceWith(result);

                //}

                $('#RowId').attr('id', 'ROW');
            });
        })
    }



}