/*global angular, confirm*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .controller('BrandListCtrl', ['brandService', 'translateService', BrandListCtrl]);

    function BrandListCtrl(brandService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.brands = [];

        vm.getBrands = function getBrands() {
            brandService.getBrands().then(function (result) {
                vm.brands = result.data;
            });
        };

        vm.deleteBrand = function deleteBrand(brand) {
            bootbox.confirm('Are you sure you want to delete this brand: ' + brand.name, function (result) {
                if (result) {
                    brandService.deleteBrand(brand)
                       .then(function (result) {
                           vm.getBrands();
                           toastr.success(brand.name + ' has been deleted');
                       })
                       .catch(function (response) {
                           toastr.error(response.data.error);
                       });
                }
            });
        };

        vm.getBrands();
    }
})();
