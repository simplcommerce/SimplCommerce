/*global angular*/
(function () {
    angular
        .module('shopAdmin.brand')
        .factory('brandService', brandService);

    /* @ngInject */
    function brandService($http) {
        var service = {
            getBrand: getBrand,
            createBrand: createBrand,
            editBrand: editBrand,
            deleteBrand: deleteBrand,
            getBrands: getBrands
        };
        return service;

        function getBrand(id) {
            return $http.get('Admin/Brand/Get/' + id);
        }

        function getBrands() {
            return $http.get('Admin/Brand/List');
        }

        function createBrand(brand) {
            return $http.post('Admin/Brand/Create', brand);
        }

        function editBrand(brand) {
            return $http.post('Admin/Brand/Edit/' + brand.id, brand);
        }

        function deleteBrand(brand) {
            return $http.post('Admin/Brand/Delete/' + brand.id, null);
        }
    }
})();