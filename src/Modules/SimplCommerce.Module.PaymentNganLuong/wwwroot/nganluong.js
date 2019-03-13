/*global $ */
$(function () {
    $('body').on('click', '#nganluongPayment', function () {
      $.ajax({
            type: 'GET',
            url: '/ngan-luong/payment-methods'
        }).done(function (data) {
            $('#shopModal').find('.modal-content').html(data);
            $('#shopModal').modal('show');
        });
    });
});
