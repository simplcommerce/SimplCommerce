$(function () {
    var $districtSelect = $("#shippingmethod");
    var shippingmethodid = $("#shippingmethodid");

    $districtSelect.empty();
    $.getJSON("/api/shippingmethod", function (data) {
        $.each(data, function (index, element) {
            var radioBtn = $('<input type="radio" shippingmethodid="' + index + '" name="radio2" value="' + element.id + '"  required/>' + element.name + '<p class="text-primary">' + element.dec + '</p><br>');
            radioBtn.appendTo('#shippingmethod');
        });
    });

   

    $($districtSelect).on('change', 'input[name=radio2]:radio', function () {
        var radioValue = $("input[name='radio']:checked").val();
        shippingmethodid.val(radioValue);

        if (radioValue != "") {
            AddPaypalCost(this.value)
        }
        else {
            alert("Please Enter Some Valid Value");
        }
    })

    function AddPaypalCost(value) {
        $.get("/cart/addshippingcost", { shippingid: value }, function (data, status) {
            //todos ??
        });


        var container = $("#myComponentContainer");
        container.empty();
        var refreshComponent = function () {
            $.get("/cart/OrderSummaryViewComponent", function (data) { container.html(data); });
        };

        $(function () { window.setInterval(refreshComponent, 1000); });

    }



});