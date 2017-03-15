/*global angular*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .controller('ProductAttributeFormCtrl', ProductAttributeFormCtrl);

    /* @ngInject */
    function ProductAttributeFormCtrl($state, $stateParams, productAttributeGroupService, productAttributeService) {
        var vm = this;
        vm.productAttributeId = $stateParams.id;
        vm.isEditMode = vm.productAttributeId > 0;
        vm.productAttribute = {};
        vm.productAttributeGroups = [];

        vm.save = function save() {
            var promise;
            if (vm.isEditMode) {
                promise = productAttributeService.editProductAttribute(vm.productAttribute);
            } else {
                promise = productAttributeService.createProductAttribute(vm.productAttribute);
            }

            promise
                .then(function (result) {
                    $state.go('product-attribute');
                })
                .catch(function (error) {
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not add create product option.');
                    }
                });
        };

        function getProductAttribute() {
            productAttributeService.getProductAttribute(vm.productAttributeId).then(function (result) {
                vm.productAttribute = result.data;
            });
        }

        function getProductAttributeGroups() {
            productAttributeGroupService.getProductAttributeGroups().then(function (result) {
                vm.productAttributeGroups = result.data;
            })
        }

        function init() {
            getProductAttributeGroups();
            if (vm.isEditMode) {
                getProductAttribute();
            }
        }

        init();
    }
})();