/*global angular*/
(function () {
    angular
        .module('simplAdmin.core')
        .controller('UserListCtrl', ['userService', 'translateService', UserListCtrl]);

    function UserListCtrl(userService, translateService) {
        var vm = this;
        vm.tableStateRef = {};
        vm.users = [];
        vm.roles = [];
        vm.customerGroups = [];
        vm.translate = translateService;

        vm.getUsers = function getUsers(tableState) {
            vm.tableStateRef = tableState;
            vm.isLoading = true;
            userService.getUsers(tableState).then(function (result) {
                vm.users = result.data.items;
                tableState.pagination.totalItemCount = result.data.totalRecord;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                vm.isLoading = false;
            });
        };

        vm.deleteUser = function deleteUser(user) {
            bootbox.confirm('Are you sure you want to delete this user: ' + simplUtil.escapeHtml(user.fullName), function (result) {
                if (result) {
                    userService.deleteUser(user)
                        .then(function (result) {
                            vm.getUsers(vm.tableStateRef);
                            toastr.success(user.fullName + ' has been deleted');
                        })
                        .catch(function (response) {
                            toastr.error(response.data.error);
                        });
                }
            });
        };

        function init() {
            userService.getRoles().then(function (result) {
                vm.roles = result.data;
            });

            userService.getCustomerGroups().then(function (result) {
                vm.getCustomerGroups = result.data;
            });
        }

        init();
    }
})();
