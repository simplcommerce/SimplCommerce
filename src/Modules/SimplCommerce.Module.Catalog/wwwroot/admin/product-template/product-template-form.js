/*global angular*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .controller('ProductTemplateFormCtrl', ProductTemplateFormCtrl);

    /* @ngInject */
    function ProductTemplateFormCtrl($state, $stateParams, productTemplateService, productAttributeService) {
        var vm = this;
        vm.productTemplateId = $stateParams.id;
        vm.isEditMode = vm.productTemplateId > 0;
        vm.productTemplate = { attributes : [] };
        vm.attributes = [];
        vm.addingAttribute = null;

        vm.addAttribute = function addAttribute(attr) {
            var index = vm.attributes.indexOf(attr);
            vm.attributes.splice(index, 1);
            vm.productTemplate.attributes.push(attr);
            vm.addingAttribute = null;
        };

        vm.removeAttribute = function removeAttribute(attr) {
            var index = vm.productTemplate.attributes.indexOf(attr);
            vm.productTemplate.attributes.splice(index, 1);
            vm.attributes.push(attr);
        };

        vm.save = function save() {
            var promise;
            if (vm.isEditMode) {
                promise = productTemplateService.editProductTemplate(vm.productTemplate);
            } else {
                promise = productTemplateService.createProductTemplate(vm.productTemplate);
            }

            promise.success(function () {
                    $state.go('product-template');
                })
                .error(function (error) {
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not add product template.');
                    }
                });
        };

        function getProductTemplate() {
            productTemplateService.getProductTemplate(vm.productTemplateId).then(function (result) {
                var i, index, attributeIds;
                vm.productTemplate = result.data;

                attributeIds = vm.attributes.map(function (item) { return item.id; });
                for (i = 0; i < vm.productTemplate.attributes.length; i = i + 1) {
                    index = attributeIds.indexOf(vm.productTemplate.attributes[i].id);
                    attributeIds.splice(index, 1);
                    vm.attributes.splice(index, 1);
                }
            });
        }

        function getProductAttributes() {
            productAttributeService.getProductAttributes().then(function (result) {
                vm.attributes = result.data;
            });
        }

        function init() {
            getProductAttributes();
            if (vm.isEditMode) {
                getProductTemplate();
            }
        }

        init();
    }
})();