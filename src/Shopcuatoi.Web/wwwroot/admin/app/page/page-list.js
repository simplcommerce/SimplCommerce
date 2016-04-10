/*global angular, confirm*/
(function () {
    angular
        .module('shopAdmin.page')
        .controller('PageListCtrl', PageListCtrl);

    /* @ngInject */
    function PageListCtrl(pageService) {
        var vm = this;
        vm.pages = [];

        vm.getPages = function getpages() {
            pageService.getPages().then(function (result) {
                vm.pages = result.data;
            });
        };

        vm.deletePage = function deletePage(page) {
            if (confirm("Are you sure?")) {
                pageService.deletePage(page).then(function (result) {
                    vm.getPages();
                });
            }
        };

        vm.getPages();
    }
})();