/*global $ */
$(function () {
    $('body').on('click', '.add-to-comparison', function () {
        var productId = $(this).closest("form").find('input[name=productId]').val();

        $.ajax({
            type: 'POST',
            url: '/productcomparison/addtocomparison',
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

    $('body').on('click', '.remove-item-comparison', function () {
        var row = $(this).closest(".row"),
            id = $(this).closest(".row").find('input[name=productId]').val();
        
        $.ajax({
            type: 'POST',
            url: '/productcomparison/remove',
            data: JSON.stringify({ id: id }),
            contentType: 'application/json; charset=utf-8'
        }).done(function (data) {
            row.remove();
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