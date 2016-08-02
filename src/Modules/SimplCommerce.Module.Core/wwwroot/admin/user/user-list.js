/*global angular*/
(function () {
    angular
        .module('simplAdmin.core')
        .controller('UserListCtrl', UserListCtrl);

    /* @ngInject */
    function UserListCtrl(userService, translateService) {
        var vm = this;
        vm.users = [];
        vm.translate = translateService;

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