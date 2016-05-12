/*global angular, confirm*/
(function () {
    angular
        .module('shopAdmin.resource')
        .controller('ResourceListCtrl', ResourceListCtrl);

    /* @ngInject */
    function ResourceListCtrl(resourceService) {
        var vm = this;
        vm.resources = [];

        vm.getResources = function getResources(tableState) {
            vm.isLoading = true;

            resourceService.getResources(tableState).then(function (result) {
                vm.resources = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                vm.isLoading = false;
            });
        };
    }
})();