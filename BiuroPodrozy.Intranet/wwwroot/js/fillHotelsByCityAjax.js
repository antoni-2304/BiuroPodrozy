$(document).ready(function () {
    $('.fillHotelsByCityAjax').on('change', function () {
        $.ajax({
            type: "GET",
            url: '/Trips/UpdateHotelsByCity/',
            data: { cityId: this.value },
            success: function (data) {
                var markup;
                for (var i = 0; i < data.length; i++) {
                    markup += "<option value=" + data[i].value + ">" + data[i].text + "</option>";
                }
                $(".fillHotelsAjax").html(markup).show();
            }
        });
   
    });
});