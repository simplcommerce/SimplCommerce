/*global angular*/
(function () {
    angular
        .module('simplAdmin.core')
        .controller('OrderFormCtrl', OrderFormCtrl);

    /* @ngInject */
    function OrderFormCtrl($state, $stateParams, orderService, translateService, userService) {
        var vm = this;
        vm.translate = translateService;
        vm.orderId = $stateParams.id;
        vm.isEditMode = vm.orderId > 0;
        vm.users = [];
        vm.searchUsers = [];
        vm.fullName = '';
        vm.focus = false;

        vm.save = function save() {
            var promise;
            if (vm.isEditMode) {
                promise = orderService.editOrder(vm.order);
            } else {
                promise = orderService.createOrder(vm.order);
            }

            promise
                .then(function (result) {
                    $state.go('orders');
                })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not add order.');
                    }
                });
        };

        function getUsers() {
            userService.getAllUsers().then(function (result) {
                vm.users = result.data;
            });
        }

        vm.filterValues = function () {
            if (vm.fullName.length > 2) {
                vm.focus = true;
                vm.searchUsers = vm.users.filter(u => u.fullName.toLowerCase().includes(vm.fullName.toLowerCase())).slice(0,5);
            }
        };

        vm.setQuery = function (fullName) {
            vm.fullName = fullName;
            vm.focus = false;
        };

        function init() {
            if (vm.isEditMode) {
                orderService.getOrder(vm.orderId).then(function (result) {
                    vm.order = result.data;
                });
            }
        }
        init();
        getUsers(); 
    }
})();
