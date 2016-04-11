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
            manufacturerService.editManufacturer(vm.manufacturer)
                .success(function (result) {
                    $state.go('manufacturer');
                })
                .error(function (error) {
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not add manufacturer.');
                    }
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