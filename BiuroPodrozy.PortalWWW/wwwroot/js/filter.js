function filter(element) {

    $.ajax({
        type: "GET",
        url: '/Search/Filter',
        data: {
            element: element.value,
            column: element.name,
            _checked: element.checked
        },
        success: function (data) {
            $('#searchCards').html(data);
        }
    });
}