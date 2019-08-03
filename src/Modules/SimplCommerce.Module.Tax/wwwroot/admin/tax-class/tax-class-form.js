/*global angular, jQuery*/
(function ($) {
    angular
        .module('simplAdmin.tax')
        .controller('TaxClassFormCtrl', ['$state', '$stateParams', 'taxClassService', 'translateService', TaxClassFormCtrl]);

    function TaxClassFormCtrl($state, $stateParams, taxClassService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.taxClass = {};
        vm.taxClassId = $stateParams.id;
        vm.isEditMode = vm.taxClassId > 0;

        vm.save = function save() {
            var promise;
            if (vm.isEditMode) {
                promise = taxClassService.editTaxClass(vm.taxClass);
            } else {
                promise = taxClassService.createTaxClass(vm.taxClass);
            }

            promise
                .then(function (result) {
                    $state.go('tax-classes');
                })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not add/update tax class.');
                    }
                });
        };

        function init() {
            if (vm.isEditMode) {
                taxClassService.getTaxClass(vm.taxClassId).then(function (result) {
                    vm.taxClass = result.data;
                });
            }
        }

        init();
    }
})(jQuery);
