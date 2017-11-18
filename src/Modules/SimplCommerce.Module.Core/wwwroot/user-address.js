$(function () {
    function resetSelect($select) {
        var $defaultOption = $select.find("option:first-child");
        $select.empty();
        $select.append($defaultOption);
    }

    $('#CountryId').on('change', function () {
        var selectedCountryId = this.value;
        if (!selectedCountryId) {
            return;
        }

        $.getJSON('/api/countries/' + selectedCountryId + '/states-provinces', function (data) {
            var $stateOrProvinceSelect = $("#StateOrProvinceId");
            resetSelect($stateOrProvinceSelect);

            var $districtSelect = $("#DistrictId");
            resetSelect($districtSelect);

            $.each(data, function (index, option) {
                $stateOrProvinceSelect.append($("<option></option>").attr("value", option.id).text(option.name));
            });
        });
    });

    $('#StateOrProvinceId').on('change', function () {
        var selectedStateOrProvinceId = this.value;
        if (!selectedStateOrProvinceId) {
            return;
        }

        $.getJSON("/Location/GetDistricts/" + selectedStateOrProvinceId, function (data) {
            var $districtSelect = $("#DistrictId");
            resetSelect($districtSelect);

            $.each(data, function (index, option) {
                $districtSelect.append($("<option></option>").attr("value", option.value).text(option.text));
            });
        });
    });
});