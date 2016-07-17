$(document).ready(function () {
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
        var image = e.originalEvent.dataTransfer.files;
        var filename = image[0].name;
        if (ImageNameValid(filename) == false) {
            alert('Upload Error this file extension is not allowed. You can only upload JPG, JPEG, PNG, GIF files. ')
            $(this).css('background', '#ffffff');
            return;
        }

        createFormData(image);
    });

    DisplayImage(1);
});

function createFormData(image) {

    var formImage = new FormData();

    formImage.append('UploadedImage', image[0]);

    uploadFormData(formImage);
}

function InnitDropArea() {
    var bar = $('.bar');
    var percent = $('.percent');
    var status = $('#status');
    $('#drop-area').css('background', '#ffffff');
    status.empty();
    var percentVal = '0%';
    bar.width(percentVal)
    percent.html(percentVal);
}

function uploadFormData(formData,fnAjaxImage) {

    var bar = $('.bar');
    var percent = $('.percent');
    var status = $('#status');
    fnAjaxImage.UploadFile();
    //$.ajax({
    //    url: "api/CatImageController/UploadFile/1",
    //    type: "POST",
    //    data: formData,
    //    contentType: false,
    //    cache: false,
    //    processData: false,
    //    beforeSend: function () {

    //        InnitDropArea();
    //    },
    //    xhr: function () {
    //        var xhr = new window.XMLHttpRequest();

    //        xhr.upload.addEventListener("progress", function (evt) {
    //            if (evt.lengthComputable) {
    //                var percentComplete = evt.loaded / evt.total;
    //                percentComplete = parseInt(percentComplete * 100);

    //                var percentVal = percentComplete + '%';
    //                console.log(percentVal);
    //                bar.width(percentVal)
    //                percent.html(percentVal);

    //                if (percentComplete === 100) {
    //                    var percentVal = '100%';
    //                    bar.width(percentVal)
    //                    percent.html(percentVal);
    //                }

    //            }
    //        }, false);

    //        return xhr;
    //    },
    //    //uploadProgress: function (event, position, total, percentComplete) {
    //    //    var percentVal = percentComplete + '%';
    //    //     console.log(percentVal);
    //    //    bar.width(percentVal)
    //    //    percent.html(percentVal);
    //    //},
    //    success: function (data) {
    //        //$('#drop-area').append(data);
    //        var imgFile = formData.get('UploadedImage');
    //        $('#drop-area-preview').show();
    //        $('#drop-area-detail').hide();

    //        previewFile(imgFile);

    //        DeleteEvent();

    //    },
    //    complete: function (xhr) {
    //        // status.html(xhr.responseText);
    //    }
    //});

}
function DeleteEvent()
{
    $('#imgRemove').click(function () {

        DeleteFileUpload(1);

    });

}

function DeleteFileUpload(id) {

    $.ajax({
        url: "api/CatImageController/Delete/1",
        type: "POST",
        data: "{}",
        contentType: false,
        cache: false,
        processData: false,
        beforeSend: function () {

        },
        success: function (data) {
            //$('#drop-area').append(data);

            $('#drop-area-preview').hide();
            $('#drop-area-detail').show();

            InnitDropArea();

        },
        complete: function (xhr) {
            // status.html(xhr.responseText);
        }
    });
}

function DisplayImage(id) {

    var imgUrl = "ImageHandler.ashx?Q=1";
    $.ajax({
        url: imgUrl,
        type: "POST",
        data: "{}",
        contentType: false,
        cache: false,
        processData: false,

        success: function (data) {

            $("#drop-area-preview").show();
            $("#drop-area-detail").hide();

            $("#imgPreview").attr("src", imgUrl);

           
            DeleteEvent();
        },
        complete: function (xhr) {
            // status.html(xhr.responseText);
        }
    });

}

function previewFile(imageJs) {

    var file = imageJs;

    var reader = new FileReader();

    reader.addEventListener("load", function () {

        $("#imgPreview").attr("src", reader.result);
    }, false);

    if (file) {
        reader.readAsDataURL(file);

    }
}