(function() {
    angular.module('hvAdmin.user')
        .controller('userListCtrl', [
            'userService', function (userService) {

                var ctrl = this;
                this.displayed = [];

                this.callServer = function callServer(tableState) {

                    ctrl.isLoading = true;

                    userService.getUsers(tableState).then(function (result) {
                        ctrl.displayed = result.data.items;
                        tableState.pagination.totalItemCount = result.data.numberOfPages;
                        ctrl.isLoading = false;
                    });
                };
            }
        ]);
})()