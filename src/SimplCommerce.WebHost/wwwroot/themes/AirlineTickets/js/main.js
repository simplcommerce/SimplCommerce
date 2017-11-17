$(document).ready(function() {
    $('#popup-opener').on('click', function() {
        $('.row-passengers').toggle();
    });
    $('.submit-icon').on('click', function() {
        $('.row-passengers').fadeOut(function() {
            $(this).hide();
        });
    });
    $('.btn-tek-yon').on('click', function() {
        $('#donus-tarihi').attr('disabled', 'disabled');
    });
    $('.btn-cift').on('click', function() {
        $('#donus-tarihi').removeAttr('disabled')
    });

    $('.spinner-input, #flight-class').change(function() {
        var ids = ['adult', 'student', 'child', 'baby'];
        var totalCount = ids.reduce((prev, id) => parseInt($(`#${id}-passenger`).val()) + prev, 0);
        var fc = $('#flight-class option:selected').text();

        $('#kisi-sayisi').val(totalCount + ' - ' + fc);
    });
});
