/*global angular*/
(function () {
    angular
        .module('shopAdmin.manufacturer')
        .controller('ManufacturerCreateCtrl', ManufacturerCreateCtrl);

    /* @ngInject */
    function ManufacturerCreateCtrl($state, manufacturerService) {
        var vm = this;

        vm.manufacturer = {};

        vm.save = function save() {
            manufacturerService.createManufacturer(vm.manufacturer).then(function (result) {
                $state.go('manufacturer');
            });
        };
    }
})();