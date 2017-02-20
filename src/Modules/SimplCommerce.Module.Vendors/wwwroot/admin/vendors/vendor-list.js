/*global angular*/
(function () {
    angular
        .module('simplAdmin.vendors')
        .controller('VendorListCtrl', VendorListCtrl);

    /* @ngInject */
    function VendorListCtrl(vendorService, translateService) {
        var vm = this;
        vm.vendors = [];
        vm.translate = translateService;

        vm.getVendors = function getVendors(tableState) {
            vm.isLoading = true;
            vendorService.getVendors(tableState).then(function (result) {
                vm.vendors = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                vm.isLoading = false;
            });
        };
    }
})();