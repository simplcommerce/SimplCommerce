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
});
