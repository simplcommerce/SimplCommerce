/*global angular*/
(function () {
    angular
        .module('shopAdmin.user')
        .controller('UserListCtrl', UserListCtrl);

    /* @ngInject */
    function UserListCtrl(userService) {
        var vm = this;
        vm.users = [];

        vm.getUsers = function getUsers(tableState) {
            vm.isLoading = true;
            userService.getUsers(tableState).then(function (result) {
                vm.users = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                vm.isLoading = false;
            });
        };
    }
})();