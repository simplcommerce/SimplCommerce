/*global angular*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .controller('ProductCloneFormCtrl', ProductCloneFormCtrl);

    /* @ngInject */
    function ProductCloneFormCtrl($state, $stateParams, productCloneService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.productId = $stateParams.id;
        vm.productClone = {};

        vm.save = function save() {
            var promise = productCloneService.cloneProduct(vm.productClone);

            promise
                .then(function (result) {
                    $state.go('product');
                })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not clone product.');
                    }
                });
        };

        function getProductName() {
            productCloneService.getProductName(vm.productId).then(function (result) {
                vm.productClone = result.data;
                vm.productClone.name += " - Clone";
            });
        }

        function init() {
            getProductName();
        }

        init();
    }
})();
