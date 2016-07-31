/*global angular, confirm*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .controller('BrandListCtrl', BrandListCtrl);

    /* @ngInject */
    function BrandListCtrl(brandService) {
        var vm = this;
        vm.brands = [];

        vm.getBrands = function getBrands() {
            brandService.getBrands().then(function (result) {
                vm.brands = result.data;
            });
        };

        vm.deleteBrand = function deleteBrand(brand) {
            if (confirm("Are you sure?")) {
                brandService.deleteBrand(brand).then(function (result) {
                    vm.getBrands();
                });
            }
        };

        vm.getBrands();
    }
})();