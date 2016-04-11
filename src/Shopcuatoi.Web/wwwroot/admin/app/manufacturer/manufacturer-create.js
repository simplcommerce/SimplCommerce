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
            manufacturerService.createManufacturer(vm.manufacturer)
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
    }
})();