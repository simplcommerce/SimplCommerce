/*global angular, confirm*/
(function () {
    angular
        .module('shopAdmin.manufacturer')
        .controller('ManufacturerListCtrl', ManufacturerListCtrl);

    /* @ngInject */
    function ManufacturerListCtrl(manufacturerService) {
        var vm = this;
        vm.manufacturers = [];

        vm.getManufacturers = function getManufacturers() {
            manufacturerService.getManufacturers().then(function (result) {
                vm.manufacturers = result.data;
            });
        };

        vm.deleteManufacturer = function deleteManufacturer(manufacturer) {
            if (confirm("Are you sure?")) {
                manufacturerService.deleteManufacturer(manufacturer).then(function (result) {
                    vm.getManufacturers();
                });
            }
        };

        vm.getManufacturers();
    }
})();