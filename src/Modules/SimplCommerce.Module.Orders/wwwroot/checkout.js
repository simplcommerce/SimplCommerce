$(function () {
    function toggleCreateShippingAddress() {
        var shippingAddressId = $('input[name=shippingAddressId]:checked').val(),
            $createShippingAddress = $('.create-shipping-address');

        if (shippingAddressId === "0") {
            $createShippingAddress.show();
        } else {
            $createShippingAddress.hide();
        }
    }

    function updateShippingInfo() {
        if ($('input[name=shippingAddressId]:checked').val() === "0" && !$('#NewAddressForm_StateOrProvinceId').val()) {
            return;
        }
        var postData = {
            existingShippingAddressId: $('input[name=shippingAddressId]:checked').val(),
            orderAmount: $('#orderSubtotal').val(),
            newShippingAddress: {
                countryId: $('#NewAddressForm_CountryId').val() || 0,
                stateOrProvinceId: $('#NewAddressForm_StateOrProvinceId').val() || 0,
            }
        };

        $.ajax({
            type: "POST",
            url: "/Checkout/GetTaxAndShippingPrice",
            data: JSON.stringify(postData),
            contentType: "application/json",
            success: function (data) {
                var $shippingMethods = $('#shippingMethods');
                $shippingMethods.empty();
                if (data.shippingPrices.length > 0) {
                    $.each(data.shippingPrices, function (index, value) {
                        $shippingMethods.append('<div class="radio"> \
                        <label> \
                        <input type="radio" name="shippingMethod" data-price ="'+ value.priceText + '" value="' + value.name + '"> \
                            <strong> ' + value.name + ' (' + value.priceText + ')</strong> \
                        </label> \
                       </div>')
                    });
                } else {
                    $shippingMethods.append("Sorry, this items can't be shipped to your selected address");
                }

                $shippingMethods.find('label:first > input').prop('checked', true);
                updateSelectedShippingPrice();
            }
        });
    }

    function updateSelectedShippingPrice() {
        $('#orderSummaryShipping').text($('#shippingMethods label > input:checked').attr('data-price'));
    }

    $('input[name=shippingAddressId]').on('change', function () {
        toggleCreateShippingAddress();
    });

    $(document).on('change', 'input[name=shippingAddressId], #NewAddressForm_StateOrProvinceId', function () {
        updateShippingInfo();
    });

    $(document).on('change', '#shippingMethods label > input', function () {
        updateSelectedShippingPrice();
    });

    function resetSelect($select) {
        var $defaultOption = $select.find("option:first-child");
        $select.empty();
        $select.append($defaultOption);
    }

    $('#NewAddressForm_CountryId').on('change', function () {
        var countryId = this.value;

        $.getJSON('/api/countries/' + countryId + '/states-provinces', function (data) {
            var $stateOrProvinceSelect = $("#NewAddressForm_StateOrProvinceId");
            resetSelect($stateOrProvinceSelect);

            var $districtSelect = $("#NewAddressForm_DistrictId");
            resetSelect($districtSelect);

            $.each(data, function (index, option) {
                $stateOrProvinceSelect.append($("<option></option>").attr("value", option.id).text(option.name));
            });
        });
    });

    $('#NewAddressForm_StateOrProvinceId').on('change', function () {
        var selectedStateOrProvinceId = this.value;

        $.getJSON("/Location/GetDistricts/" + selectedStateOrProvinceId, function (data) {
            var $districtSelect = $("#NewAddressForm_DistrictId");
            resetSelect($districtSelect);

            $.each(data, function (index, option) {
                $districtSelect.append($("<option></option>").attr("value", option.value).text(option.text));
            });
        });
    });

    toggleCreateShippingAddress();
    updateShippingInfo();
});