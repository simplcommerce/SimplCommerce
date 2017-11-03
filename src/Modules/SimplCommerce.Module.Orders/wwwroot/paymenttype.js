$(function () {
    var $districtSelect = $("#paymenttype");
    var paymentmethodid = $("#paymentmethodid");

    $districtSelect.empty();
    $.getJSON("/api/paymenttype", function (data) {
        $.each(data, function (index, element) {
            var radioBtn = $('<input type="radio" paymentmethodid="' + index + '" name="radio" value="' + element.id + '"  required/>' + element.paymentTypeName + '<p style="text-decoration: underline">' + element.paymentTypeDec + '</p><br>');
            radioBtn.appendTo('#paymenttype');
        });
    });


    $($districtSelect).on('change', 'input[name=radio]:radio', function () {
        var radioValue = $("input[name='radio']:checked").val();
        paymentmethodid.val(radioValue);
       
        if (radioValue != "") {
            AddPaypalCost(this.value)
        }
        else
        {
            alert("Please Enter Some Valid Value");
        }
    })

    function AddPaypalCost(value )
    {
        $.get("/cart/addpaymentcost", { paymentid: value }, function (data, status) {
            //some todos in responce
        });
        //make it empty and reload
        var container = $("#myComponentContainer");
        container.empty();
        var refreshComponent = function () {
            $.get("/cart/OrderSummaryViewComponent", function (data) { container.html(data); });
        };

        $(function () { window.setInterval(refreshComponent, 1000); });
        
    }



});