//uSe
//var apiService = "api/AccountRegistrationImageController/";
//var handlerService = "AccountRegistrationImageHandler.ashx";

//$(document).ready(function () {

//InnitDropArea(apiService, handlerService);
//====================================================================
var file;
var url;
var bar;
var percent;
var id;
var status = $('#status');
function DropArea(idDb, apiService, handlerService) {
    $('#drop-area').show();

    DisplayImage(id);
    id = idDb;
    //var url = "api/CatImageController/";
    url = apiService;
    bar = $('.bar');

    percent = $('.percent');

    status = $('#status');

    //$("#drop-area-preview").hide();

    //$("#drop-area").on('dragenter', function (e) {
    //    e.preventDefault();
    //    $(this).css('background', '#BBD5B8');
    //});

    //$("#drop-area").on('dragover', function (e) {
    //    e.preventDefault();
    //});

    //$("#drop-area").on('drop', function (e) {
    //    $(this).css('background', '#D8F9D3');
    //    e.preventDefault();
    //    //var file = e.originalEvent.dataTransfer.files[0];
    //    file = e.originalEvent.dataTransfer.files[0];
    //    var filename = file.name;
    //    if (ImageNameValid(filename) == false) {
    //        //alert('Upload Error this file extension is not allowed. You can only upload JPG, JPEG, PNG, GIF files. ')
    //        Materialize.toast('Upload Error this file extension is not allowed. You can only upload JPG, JPEG, PNG, GIF files. ', 3000, 'toastCss');
    //        $(this).css('background', '#ffffff');
    //        return;
    //    }

    //    UploadFile(id, file);
    //});
}
function ResetStatus()
{

    var bar = $('.bar');
    var percent = $('.percent');
    var status = $('#status');
    $('#drop-area').css('background', '#ffffff');

    var percentVal = '0%';
    bar.width(percentVal)
    percent.html(percentVal);
}

function InnitDropArea(apiService, handlerService) {
    //var bar = $('.bar');
    //var percent = $('.percent');
    //var status = $('#status');
    //$('#drop-area').css('background', '#ffffff');
    url = apiService;
    //var percentVal = '0%';
    //bar.width(percentVal)
    //percent.html(percentVal);

    $("#drop-area-preview").hide();

    $("#drop-area").on('dragenter', function (e) {
        e.preventDefault();
        $(this).css('background', '#BBD5B8');
    });

    $("#drop-area").on('dragover', function (e) {
        e.preventDefault();
    });

    $("#drop-area").on('drop', function (e) {
        $(this).css('background', '#D8F9D3');
        e.preventDefault();
        //var file = e.originalEvent.dataTransfer.files[0];
        file = e.originalEvent.dataTransfer.files[0];
        var filename = file.name;
        if (ImageNameValid(filename) == false) {
            //alert('Upload Error this file extension is not allowed. You can only upload JPG, JPEG, PNG, GIF files. ')
            Materialize.toast('Upload Error this file extension is not allowed. You can only upload JPG, JPEG, PNG, GIF files. ', 3000, 'toastCss');
            $(this).css('background', '#ffffff');
            return;
        }

        $('#drop-area-preview').show();
        $('#drop-area-detail').hide();
        PreviewFile(file);
        EventDelete();
        //UploadFile(id, file);
    });
}

function EventDelete() {
    //file = null;
   // $("#imgPreview").attr("src", imgUrl);
    $('#imgRemove').click(function () {


        $('#drop-area-preview').hide();
        $('#drop-area-detail').show();
        ResetStatus();
        //DeleteFile(id);
        file = null;
    });
}

function PreviewFile(file) {
    var reader = new FileReader();

    reader.onload = function (e) {
        var arrayBuffer = reader.result;
        $("#imgPreview").attr("src", reader.result);
    }
    if (file) {
        reader.readAsDataURL(file);
    }
}

function UploadFile(id, file) {
    var formData = new FormData();

    formData.append('UploadedImage', file);

    $.ajax({
        url: url + "/UploadFile/" + id,
        type: "POST",
        data: formData,
        contentType: false,
        cache: false,
        processData: false,
        beforeSend: function () {
            ResetStatus();
        },
        uploadProgress: function (event, position, total, percentComplete) {
            var percentVal = percentComplete + '%';
            bar.width(percentVal)
            percent.html(percentVal);
            console.log(percentVal, position, total);
        },

        success: function (data) {
            var imgFile = formData.get('UploadedImage');
            $('#drop-area-preview').show();
            $('#drop-area-detail').hide();

            //previewFile(imgFile);
            PreviewFile(file);
            EventDelete();
        }
    });
};

function DeleteFile(id) {
    $.ajax({
        url: url + "/Delete/" + id,
        type: "POST",
        data: "{}",
        contentType: false,
        cache: false,
        processData: false,
        success: function (data) {
            $('#drop-area-preview').hide();
            $('#drop-area-detail').show();
            ResetStatus();
            //InnitDropArea();
        },
        complete: function (xhr) {
            // status.html(xhr.responseText);
        }
    });
};

function DisplayImage(id) {
    //var imgUrl = "ImageHandler.ashx?Q=" + id;
    var imgUrl = handlerService + "?Q=" + id;
    $.ajax({
        url: imgUrl,
        type: "POST",
        data: "{}",
        contentType: 'Blob',
        cache: false,
        processData: false,

        success: function (data) {
            if (data != "") {
                $("#drop-area-preview").show();
                $("#drop-area-detail").hide();

                //previewFile(data);
                $("#imgPreview").attr("src", imgUrl);
                EventDelete();
            }
        },
        complete: function (xhr) {
            // status.html(xhr.responseText);
        }
    });
}

function DropUpload(id) {
    //var file = e.originalEvent.dataTransfer.files[0];
    var filename = file.name;
    if (ImageNameValid(filename) == false) {
        //alert('Upload Error this file extension is not allowed. You can only upload JPG, JPEG, PNG, GIF files. ')
        Materialize.toast('Upload Error this file extension is not allowed. You can only upload JPG, JPEG, PNG, GIF files. ', 3000, 'toastCss');
        $(this).css('background', '#ffffff');
        return;
    }

    UploadFile(id, file);
}

function DropUploadHasFile() {

     
    if ((file == null) || (file == undefined))
    { return false; }
    
    debugger
    var a=$("#imgPreview").attr("src");

    return true;
}