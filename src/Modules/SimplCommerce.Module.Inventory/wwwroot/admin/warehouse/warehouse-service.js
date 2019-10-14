/*global angular*/
(function () {
    angular
        .module('simplAdmin.inventory')
        .factory('warehouseService', ['$http', warehouseService]);

    function warehouseService($http) {
        var service = {
            getWarehouses: getWarehouses,
            getWarehouse: getWarehouse,
            getCountries: getCountries,
            getStatesOrProvinces: getStatesOrProvinces,
            getDistricts: getDistricts,
            editWarehouse: editWarehouse,
            createWarehouse: createWarehouse,
            deleteWarehouse: deleteWarehouse,
            getProducts: getProducts,
            addAllProducts: addAllProducts,
            addSelectedProducts: addSelectedProducts
        };
        return service;

        function getWarehouses(params) {
            return $http.post('api/warehouses/grid', params);
        }

        function getCountries() {
            return $http.get('api/countries');
        }

        function getStatesOrProvinces(countryId) {
            return $http.get('api/countries/' + countryId + '/states-provinces');
        }

        function getDistricts(stateOrProvinceId) {
            return $http.get('api/states-provinces/' + stateOrProvinceId + '/districts');
        }

        function getWarehouse(id) {
            return $http.get('api/warehouses/' + id);
        }

        function editWarehouse(warehouse) {
            return $http.put('api/warehouses/' + warehouse.id, warehouse);
        }

        function createWarehouse(warehouse) {
            return $http.post('api/warehouses/', warehouse);
        }

        function deleteWarehouse(warehouse) {
            return $http.delete('api/warehouses/' + warehouse.id);
        }

        function getProducts(warehouseId, params) {
            return $http.post('api/warehouses/' + warehouseId + '/products', params);
        }

        function addAllProducts(warehouseId) {
            return $http.post('api/warehouses/ ' + warehouseId + '/add-all-products');
        }

        function addSelectedProducts(warehouseId, productIds) {
            return $http.post('api/warehouses/' + warehouseId + '/add-products', productIds);
        }
    }
})();
