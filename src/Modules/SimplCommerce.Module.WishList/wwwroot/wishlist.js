/*global $ */
$(function () {
    $('body').on('click', '.add-to-wishlist', function (e) {
        $('#productOverview').modal('hide');
        var $form = $(this).closest("form");
        var productId = $form.find('input[name=productId]').val();
        var quantity = $form.find('input[name=qty]').val();
        e.preventDefault();

        $.ajax({
            type: 'POST',
            url: '/wishlist/add-item',
            data: JSON.stringify({ productId: productId, quantity: quantity }),
            contentType: "application/json"  
        }).done(function (data) {
            $('#shopModal').find('.modal-content').html(data);
            $('#shopModal').modal('show');
        }).fail(function () {
            /*jshint multistr: true */
            $('#shopModal').find('.modal-content').html(' \
                <div class="modal-header"> \
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button> \
                    <h4 class="modal-title" id="myModalLabel">Oops</h4> \
                </div> \
                <div class="modal-body"> \
                    Something went wrong. \
                </div>');
            $('#shopModal').modal('show');
        });
    });

    $('body').on('click', '.update-wishlist', function (e) {
        var $form = $(this).closest("form");
        var itemId = $form.find('input[name=itemId]').val();
        var description = $form.find('textarea[name=description]').val();
        var quantity = $form.find('input[name=qty]').val();
        e.preventDefault();

        $.ajax({
            type: 'PATCH',
            url: '/wishlist/update-item',
            data: JSON.stringify({ itemId: itemId, description: description, quantity: quantity }),
            contentType: "application/json"
        }).done(function (data) {
            $('#shopModal').find('.modal-content').html(data);
            $('#shopModal').modal('show');
        }).fail(function () {
            /*jshint multistr: true */
            $('#shopModal').find('.modal-content').html(' \
                <div class="modal-header"> \
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button> \
                    <h4 class="modal-title" id="myModalLabel">Oops</h4> \
                </div> \
                <div class="modal-body"> \
                    Something went wrong. \
                </div>');
            $('#shopModal').modal('show');
        });
    });

    $('body').on('click', '.remove-from-wishlist', function (e) {
        var $item = $(this).closest(".item"),
            itemId = $(this).closest("form").find('input[name=itemId]').val(),
            reload = $(this).attr("data-reload");
        e.preventDefault();

        $.ajax({
            type: 'DELETE',
            url: '/wishlist/remove-item?id=' + itemId,
            contentType: 'application/json; charset=utf-8'
        }).done(function () {
            $item.remove();
            window.location.href = '/user/wishlist';
        });
    });
});
