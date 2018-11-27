/*global $ */
$(function () {
    $('body').on('click', '.add-to-comparison', function (e) {
        $('#productOverview').modal('hide');
        var productId = $(this).closest("form").find('input[name=productId]').val();
        e.preventDefault();

        $.ajax({
            type: 'POST',
            url: '/comparing-product/addto-comparison',
            data: JSON.stringify({ productId: productId }),
            contentType: "application/json"  
        }).done(function (data) {
            $('#shopModal').find('.modal-content').html(data);
            $('#shopModal').modal('show');
        }).fail(function () {
            /*jshint multistr: true */
            $('#shopModal').find('.modal-content').html(' \
                <div class="modal-header"> \
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button> \
                    <h4 class="modal-title" id="myModalLabel">Opps</h4> \
                </div> \
                <div class="modal-body"> \
                    Something went wrong. \
                </div>');
            $('#shopModal').modal('show');
        });
    });

    $('body').on('click', '.remove-item-comparison', function (e) {
        var $row = $(this).closest(".row"),
            productId = $(this).attr("data-product-id"),
            reload = $(this).attr("data-reload");
        e.preventDefault();

        $.ajax({
            type: 'DELETE',
            url: '/comparing-product/remove?id=' + productId,
            contentType: 'application/json; charset=utf-8'
        }).done(function () {
            if (reload) {
                window.location.reload();
            } else {
                $row.remove();
            }
        });
    });
});
