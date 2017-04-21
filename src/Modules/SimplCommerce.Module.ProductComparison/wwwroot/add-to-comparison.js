/*global $ */
$(function () {
    $('body').on('click', '.add-to-comparison', function () {
        var quantity,
            $form = $(this).closest("form"),
            productId = $(this).closest("form").find('input[name=productId]').val(),

        $.ajax({
            type: 'POST',
            url: '/productcomparison/AddToComparison',
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
});