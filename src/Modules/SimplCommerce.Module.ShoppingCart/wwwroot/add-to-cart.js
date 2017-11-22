/*global $ */
$(function () {
    $('body').on('click', '.btn-add-cart', function () {
        var quantity,
            $form = $(this).closest("form"),
            productId = $(this).closest("form").find('input[name=productId]').val(),
            $quantityInput = $form.find('.quantity-field');

        quantity = $quantityInput.length === 1 ? $quantityInput.val() : 1;

        $.ajax({
            type: 'POST',
            url: '/cart/addtocart',
            data: JSON.stringify({ productId: productId, quantity: quantity }),
            contentType: "application/json"
        }).done(function (data) {
            $('#shopModal').find('.modal-content').html(data);
            $('#shopModal').modal('show');
            $('.cart-badge .badge').text($('#shopModal').find('.cart-item-count').text());
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
});