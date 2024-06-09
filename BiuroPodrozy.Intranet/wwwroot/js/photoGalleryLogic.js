//$(document).ready(function () {
//    $('#deletePhoto').click(function () {

//        alert(m3);
//        $.ajax({
//            url: '@Url.Action("GetPhotoGalleryComponent", "Hotel")',
//            data: JSON.stringify(model),
//        }).success(function (data) {
//            $('#photoGallery').html(data);
//        });

//    });
//});

function deletePhoto(list, element) {

    $.ajax({
        type: "GET",
        url: '/PhotoGallery/DeletePhoto',
        data: {
            photos: list,
            photo: element
        },
        success: function (data) {
            $('#photoGallery').html(data);
        }
    });
}

function addPhoto(name, list) {
    $.ajax({
        type: "GET",
        url: '/PhotoGallery/AddPhoto',
        data: {
            photos: list,
            photo: name.files.item(0).name
        },
        success: function (data) {
            $('#photoGallery').html(data);
        }
    });
}