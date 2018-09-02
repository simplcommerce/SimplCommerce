/*global jQuery, window*/
$(document).ready(function () {
    $('#addcomment').on('click', '#btn-addcomment', function (e) {
        e.preventDefault();
        var $form = $(this).closest('form');
        if (!$form.valid || $form.valid()) {
            $.post($form.attr('action'), $form.serializeArray())
                .done(function (result) {
                    $form.parent().html(result);
                });
        }
    });

    $('#comments').on('click', '.btn-submit-review-reply', function (e) {
        e.preventDefault();
        var $form = $(this).closest('.form-add-review-reply');
        var that = this;
        if (!$form.valid || $form.valid()) {
            $.post($form.attr('action'), $form.serializeArray())
                .done(function (result) {
                    $(that).closest('.add-review-reply').html(result);
                });
        }
    });

    $('#comments').on('click', '.btn-view-review-replies', function (e) {
        var $parent = $(this).parent();
        $(this).addClass('d-none');
        $parent.find('.review-replies').removeClass('d-none');
        $parent.find('.btn-hide-review-replies').removeClass('d-none');
    });

    $('#comments').on('click', '.btn-hide-review-replies', function (e) {
        var $parent = $(this).parent();
        $(this).addClass('d-none');
        $parent.find('.review-replies').addClass('d-none');
        $parent.find('.btn-view-review-replies').removeClass('d-none');
    });

    $('#comments').on('click', '.btn-add-review-reply', function (e) {
        $('.add-review-reply').addClass('d-none');
        $(this).parent().find('.add-review-reply').removeClass('d-none');
    });
});
