/*global angular*/
(function () {
    angular
        .module('shopAdmin.manufacturer')
        .controller('ManufacturerEditCtrl', ManufacturerEditCtrl);

    /* @ngInject */
    function ManufacturerEditCtrl($state, $stateParams, manufacturerService) {
        var vm = this;
        vm.manufacturer = {};
        vm.isEditMode = true;

        vm.save = function save() {
            manufacturerService.editManufacturer(vm.manufacturer).then(function (result) {
                $state.go('manufacturer');
            });
        };

        function init() {
            manufacturerService.getManufacturer($stateParams.id).then(function (result) {
                vm.manufacturer = result.data;
            });
        }

        init();
    }
})();