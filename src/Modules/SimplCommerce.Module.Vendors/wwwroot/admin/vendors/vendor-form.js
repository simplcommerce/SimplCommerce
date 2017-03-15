 /*global angular*/
(function () {
    angular
        .module('simplAdmin.vendors')
        .controller('VendorFormCtrl', VendorFormCtrl);

    /* @ngInject */
    function VendorFormCtrl($state, $stateParams, vendorService) {
        var vm = this;
        vm.vendor = {};
        vm.vendorId = $stateParams.id;
        vm.isEditMode = vm.vendorId > 0;

        vm.save = function save() {
            var promise;
            if (vm.isEditMode) {
                promise = vendorService.editVendor(vm.vendor);
            } else {
                promise = vendorService.createVendor(vm.vendor);
            }

            promise
                .then(function (result) {
                    $state.go('vendors');
                })
                .catch(function (error) {
                    vm.validationErrors = [];
                    if (error.data && angular.isObject(error.data)) {
                        for (var key in error.data) {
                            vm.validationErrors.push(error.data[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not add vendor.');
                    }
                });
        };

        function init() {
            if (vm.isEditMode) {
                vendorService.getVendor(vm.vendorId).then(function (result) {
                    vm.vendor = result.data;
                });
            }
        }

        init();
    }
})();