/*global angular*/
(function () {
    angular
        .module('simplAdmin.core')
        .controller('CustomerGroupFormCtrl', ['$state', '$stateParams', 'customergroupService', 'translateService', CustomerGroupFormCtrl]);

    function CustomerGroupFormCtrl($state, $stateParams, customergroupService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.customergroup = {};
        vm.customergroupId = $stateParams.id;
        vm.isEditMode = vm.customergroupId > 0;

        vm.save = function save() {
            var promise;
            if (vm.isEditMode) {
                promise = customergroupService.editCustomerGroup(vm.customergroup);
            } else {
                promise = customergroupService.createCustomerGroup(vm.customergroup);
            }

            promise
                .then(function (result) {
                    $state.go('customergroups');
                })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not add customer group.');
                    }
                });
        };

        function init() {
            if (vm.isEditMode) {
                customergroupService.getCustomerGroup(vm.customergroupId).then(function (result) {
                    vm.customergroup = result.data;
                });
            }
        }

        init();
    }
})();
