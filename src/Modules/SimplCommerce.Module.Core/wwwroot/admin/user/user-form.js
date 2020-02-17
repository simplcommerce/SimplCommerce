 /*global angular*/
(function () {
    angular
        .module('simplAdmin.core')
        .controller('UserFormCtrl', ['$state', '$stateParams', 'userService', 'translateService', UserFormCtrl]);

    function UserFormCtrl($state, $stateParams, userService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.user = { roleIds: [], customerGroupIds: [] };
        vm.vendors = [];
        vm.roles = [];
        vm.customerGroups = [];
        vm.userId = $stateParams.id;
        vm.isEditMode = vm.userId > 0;

        vm.toggleRoles = function toggleRoles(roleId) {
            var index = vm.user.roleIds.indexOf(roleId);
            if (index > -1) {
                vm.user.roleIds.splice(index, 1);
            } else {
                vm.user.roleIds.push(roleId);
            }
        };

        vm.toggleCustomerGroups = function toggleCustomerGroups(customergroupId) {
            var index = vm.user.customerGroupIds.indexOf(customergroupId);
            if (index > -1) {
                vm.user.customerGroupIds.splice(index, 1);
            } else {
                vm.user.customerGroupIds.push(customergroupId);
            }
        };

        vm.save = function save() {
            var promise;
            if (vm.isEditMode) {
                promise = userService.editUser(vm.user);
            } else {
                promise = userService.createUser(vm.user);
            }

            promise
                .then(function (result) {
                    $state.go('users');
                })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not add user.');
                    }
                });
        };

        function getVendors() {
            userService.getVendors().then(function (result) {
                vm.vendors = result.data;
            });
        }

        function getRoles() {
            userService.getRoles().then(function (result) {
                vm.roles = result.data;
            });
        }

        function getCustomerGroups() {
            userService.getCustomerGroups().then(function (result) {
                vm.customerGroups = result.data;
            });
        }

        function init() {
            if (vm.isEditMode) {
                userService.getUser(vm.userId).then(function (result) {
                    vm.user = result.data;
                });
            }

            getVendors();
            getRoles();
            getCustomerGroups();
        }

        init();
    }
})();
