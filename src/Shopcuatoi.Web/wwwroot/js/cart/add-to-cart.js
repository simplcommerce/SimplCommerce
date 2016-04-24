$(function () {
    $('body').on('click', '.btn-add-cart', function () {
        var quantity,
            variationNames = [],
            $form = $(this).closest("form"),
            productId = $(this).closest("form").find('input[name=productId]').val(),
            $quantityInput = $form.find('.quantity-field'),
            $attrOptions = $form.find('.product-attr-options');

        quantity = $quantityInput.length === 1 ? $quantityInput.val() : 1;
        if ($attrOptions.length > 0) {
            $attrOptions.each(function () {
                variationNames.push($(this).find('input[type=radio]:checked').val());
            });
        }
        
        $.ajax({
            type: 'POST',
            url: '/cart/addtocart',
            data: JSON.stringify({ productId: productId, variationName: variationNames.join('-'), quantity: quantity }),
            contentType: "application/json"
        }).done(function (data) {
            $('#shopModal').find('.modal-content').html(data);
            $('#shopModal').modal('show');
            $('.cart-badge .badge').text($('#shopModal').find('.cart-item-count').text());
        }).fail(function () {
            $('#shopModal').find('.modal-content').html(`
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">Opps</h4>
                </div>
                <div class="modal-body">
                    Please chooose a variation
                </div>`);
            $('#shopModal').modal('show');
        });
    });
});