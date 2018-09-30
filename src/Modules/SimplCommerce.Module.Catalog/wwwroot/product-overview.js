/*global $ */
$(function () {
    $('body').on('click', '.quick-view', function () {
        var productId = $(this).parent().find('#productId').val();
        $.ajax({
            type: 'GET',
            url: '/product/product-overview?id=' + productId,
            contentType: "application/json"
        }).done(function (data) {
            $('#productOverview').find('.modal-content').html(data);
            $('#productOverview').modal('show');
        });
    });
});
