/*global angular*/
(function () {
    angular
        .module('simplAdmin.catalog')
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
            return $http.get('api/brands/' + id);
        }

        function getBrands() {
            return $http.get('api/brands');
        }

        function createBrand(brand) {
            return $http.post('api/brands', brand);
        }

        function editBrand(brand) {
            return $http.put('api/brands/' + brand.id, brand);
        }

        function deleteBrand(brand) {
            return $http.delete('api/brands/' + brand.id, null);
        }
    }
})();