/*global jQuery, window*/
$(document).ready(function () {
    $('#addreview').on('click', '#btn-addreview', function (e) {
        e.preventDefault();
        var $form = $('#form-addreview');
        if (!$form.valid || $form.valid()) {
            $.post($form.attr('action'), $form.serializeArray())
                .done(function (result) {
                    $('#addreview').html(result);
                    $('input.rating-loading').rating({
                        language: window.simplGlobalSetting.lang,
                        filledStar: '<i class="fa fa-star"></i>',
                        emptyStar: '<i class="fa fa-star-o"></i>'
                    });
                });
        }
    });

    $('#reviews').on('click', '.btn-submit-review-reply', function (e) {
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

    $('#reviews').on('click', '.btn-view-review-replies', function (e) {
        var $parent = $(this).parent();
        $(this).addClass('d-none');
        $parent.find('.review-replies').removeClass('d-none');
        $parent.find('.btn-hide-review-replies').removeClass('d-none');
    });

    $('#reviews').on('click', '.btn-hide-review-replies', function (e) {
        var $parent = $(this).parent();
        $(this).addClass('d-none');
        $parent.find('.review-replies').addClass('d-none');
        $parent.find('.btn-view-review-replies').removeClass('d-none');
    });

    $('#reviews').on('click', '.btn-add-review-reply', function (e) {
        $('.add-review-reply').addClass('d-none');
        $(this).parent().find('.add-review-reply').removeClass('d-none');
    });
});
