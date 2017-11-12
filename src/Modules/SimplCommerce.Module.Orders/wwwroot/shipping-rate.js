$(function () {

    var $districtSelect = $("#shippingproviderlist");
    var $addressList = $('#addresslist');
    var shippingmethodid = $("#shippingproviderid");
    var shippingproviderlisturl = "/Shipping/GetShippingProviders";
    var GetShippingRateurl = "/Shipping/GetShippingRate";
    var countryaddreurl = "/Shipping/GetConutryByName";
    var shippingaddressurl = "/Shipping/GetShippingAddress";
    

    //list of providers
    loadProviders()

    providerEvents();

    
    function loadProviders() {
        $districtSelect.empty();
        $.getJSON(shippingproviderlisturl, function (data) {
            $.each(data, function (index, element) {
                var radioBtn = $('<input type="radio" shippingproviderid="' + index + '" name ="radioshipping" id ="radioshipping" value="' + element.id + '"  required/>' + element.name + '<p class="text-primary">' + + '</p><br>');
                  radioBtn.appendTo('#shippingproviderlist');
            });
        });
    }
   
    //get address 
    function getaddress(callback)
    {
        
        var shippingradiovalue = $("input[name='shippingAddressId']:checked").val();
        
        $.get(shippingaddressurl, { id: shippingradiovalue }, function (data, status) {
                address = new Address(data[0].countryid, data[0].provinceid, data[0].line1)
                callback(address);
            });
       
    }
    //get new address
    function getnewaddress(callback)
    {
        var countryname = $("#countryname").val();
            $.get(countryaddreurl, { name: countryname }, function (data, status) {
                address = new Address(data[0].id, $('#NewAddressForm_StateOrProvinceId').val(), $('#NewAddressForm_AddressLine1').val())
                callback(address);

            });

        
    }
    function getamount() {
        return  $('#ordersummary #subtotal').text();
    }

    function Address(countryid, provinceid, addressline)
    {
            this.CountryId = countryid,
            this.StateOrProvinceId = provinceid,
            this.AddressLine1 = addressline
    }
    function providerEvents() {
        $($districtSelect).on('change', 'input[name=radioshipping]:radio', function () {
            var radioValue = $("input[name='shippingAddressId']:checked").val();

            if (radioValue == 0) {

                var addressline = $('#NewAddressForm_AddressLine1').val()
                if (addressline == "") {
                    //some jquery validation 
                    alert("put some address in address line")
                    $('#radioshipping').attr('checked', false)
                }
                else
                {
                    var amount = getamount();
                    getnewaddress(function (address) {
                        var data = { OrderAmount: amount, CountryId: address.CountryId, StateOrProvinceId: address.StateOrProvinceId, AddressLine1: address.AddressLine1 };
                        var json = JSON.stringify(data);
                        console.log(json);
                        $.ajax({
                            type: "POST",
                            url: GetShippingRateurl,
                            data: json,
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (responce) {
                                alert('Responce from GetShippingRateurl' + responce);
                            }
                        });
                    })
                }
            }
            else
            {
                var amount = getamount();
                getaddress(function (address) {

                  
                    var data = { CountryId: address.CountryId, StateOrProvinceId: address.StateOrProvinceId, AddressLine1: address.AddressLine1, OrderAmount: amount };
                    var model = JSON.stringify(data);
                    console.log(model)
                    $.ajax({
                        type: "POST",
                        url: GetShippingRateurl,
                        data: model,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (responce) {
                            alert('Responce from GetShippingRateurl' + responce );
                        }
                    });

                })
                
            }
        })

        $($addressList).on('change', 'input[name=shippingAddressId]:radio', function () {
            $('#radioshipping').attr('checked', false)
        })
    }
});