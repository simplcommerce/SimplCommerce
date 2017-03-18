/*global angular*/
(function () {
    angular
        .module('simplAdmin.core')
        .controller('UserListCtrl', UserListCtrl);

    /* @ngInject */
    function UserListCtrl(userService, translateService) {
        var vm = this,
            tableStateRef;
        vm.users = [];
        vm.translate = translateService;

        vm.getUsers = function getUsers(tableState) {
            tableStateRef = tableState;
            vm.isLoading = true;
            userService.getUsers(tableState).then(function (result) {
                vm.users = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                vm.isLoading = false;
            });
        };

        vm.deleteUser = function deleteUser(user) {
            bootbox.confirm('Are you sure you want to delete this user: ' + user.fullName, function (result) {
                if (result) {
                    userService.deleteUser(user)
                        .then(function (result) {
                            vm.getUsers(tableStateRef);
                            toastr.success(user.fullName + ' has been deleted');
                        })
                        .catch(function (response) {
                            toastr.error(response.data.error);
                        });
                }
            });
        };
    }
})();