(function() {
    angular.module('hvAdmin.user')
        .controller('userListCtrl', [
            'userService', function (userService) {

                var ctrl = this;

                this.displayed = [];
                this.numberOfPages = 0;

                this.callServer = function callServer(tableState) {

                    ctrl.isLoading = true;

                    userService.getUsers(tableState).then(function (result) {
                        ctrl.numberOfPages = result.data.numberOfPages / tableState.pagination.number;
                        ctrl.displayed = result.data.items;
                        tableState.pagination.numberOfPages = ctrl.numberOfPages;
                        ctrl.isLoading = false;
                    });
                };
            }
        ]);
})()