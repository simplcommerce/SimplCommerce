/*global $ */
$(function () {
    /*jshint multistr: true */
    var generalError = ' \
        <div class="modal-header"> \
            <h4 class="modal-title" id="myModalLabel">Oops</h4> \
            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button> \
        </div> \
        <div class="modal-body">There are something wrong. Please try again</div>';
   
    $('body').on('click', '.btn-add-cart', function () {
        $('#productOverview').modal('hide');
        var quantity,
            $form = $(this).closest("form"),
            productId = $(this).closest("form").find('input[name=productId]').val(),
            $quantityInput = $form.find('.quantity-field');

        quantity = $quantityInput.length === 1 ? $quantityInput.val() : 1;

        $.ajax({
            type: 'POST',
            url: '/cart/add-item',
            data: JSON.stringify({ productId: Number(productId), quantity: Number(quantity) }),
            contentType: "application/json"
        }).done(function (data) {
            if (data.success === false) {
                $('#shopModal').find('.modal-content').html(generalError).find('.modal-body').text(data.errorMessage);
            } else {
                $('#shopModal').find('.modal-content').html(data);
                $('.cart-badge .badge').text($('#shopModal').find('.cart-item-count').text());
            }
            $('#shopModal').modal('show');
        }).fail(function () {
            $('#shopModal').find('.modal-content').html(generalError);
            $('#shopModal').modal('show');
        });
    });
});
