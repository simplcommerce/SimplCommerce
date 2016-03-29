(function() {
    angular
        .module('shopAdmin.user')
        .controller('userListCtrl', [
            'userService',
            function(userService) {
                var vm = this;
                this.users = [];

                this.getUsers = function getUsers(tableState) {
                    vm.isLoading = true;
                    userService.getUsers(tableState).then(function(result) {
                        vm.users = result.data.items;
                        tableState.pagination.totalItemCount = result.data.numberOfPages;
                        vm.isLoading = false;
                    });
                };
            }
        ]);
})();