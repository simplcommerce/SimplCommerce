/*global angular*/
(function () {
    angular
        .module('simplAdmin.vendors')
        .controller('VendorListCtrl', ['vendorService', 'translateService', VendorListCtrl]);

    function VendorListCtrl(vendorService, translateService) {
        var vm = this;
        vm.tableStateRef = {};
        vm.vendors = [];
        vm.translate = translateService;

        vm.getVendors = function getVendors(tableState) {
            vm.tableStateRef = tableState;
            vm.isLoading = true;
            vendorService.getVendors(tableState).then(function (result) {
                vm.vendors = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                tableState.pagination.totalItemCount = result.data.totalRecord;
                vm.isLoading = false;
            });
        };

        vm.deleteVendor = function deleteVendor(vendor) {
            bootbox.confirm('Are you sure you want to delete this vendor: ' + simplUtil.escapeHtml(vendor.name), function (result) {
                if (result) {
                    vendorService.deleteVendor(vendor)
                        .then(function (result) {
                            vm.getVendors(vm.tableStateRef);
                            toastr.success(vendor.name + ' has been deleted');
                        })
                        .catch(function (response) {
                            toastr.error(response.data.error);
                        });
                }
            });
        };
    }
})();
