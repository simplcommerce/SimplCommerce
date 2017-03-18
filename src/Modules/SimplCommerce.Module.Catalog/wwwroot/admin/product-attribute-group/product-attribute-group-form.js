/*global angular*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .controller('ProductAttributeGroupFormCtrl', ProductAttributeGroupFormCtrl);

    /* @ngInject */
    function ProductAttributeGroupFormCtrl($state, $stateParams, productAttributeGroupService) {
        var vm = this;
        vm.productAttributeGroupId = $stateParams.id;
        vm.isEditMode = vm.productAttributeGroupId > 0;

        vm.productAttributeGroup = {};

        vm.save = function save() {
            var promise;
            if (vm.isEditMode) {
                promise = productAttributeGroupService.editProductAttributeGroup(vm.productAttributeGroup);
            } else {
                promise = productAttributeGroupService.createProductAttributeGroup(vm.productAttributeGroup);
            }

            promise
                .then(function (result) {
                    $state.go('product-attribute-group');
                })
                .catch(function (response) {
                    var error = response.data;
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

        function getProductAttributeGroup() {
            productAttributeGroupService.getProductAttributeGroup(vm.productAttributeGroupId).then(function (result) {
                vm.productAttributeGroup = result.data;
            });
        }

        function init() {
            if (vm.isEditMode) {
                getProductAttributeGroup();
            }
        }

        init();
    }
})();