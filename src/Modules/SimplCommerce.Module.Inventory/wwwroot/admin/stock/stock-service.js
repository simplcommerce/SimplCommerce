/*global angular*/
(function () {
    angular
        .module('simplAdmin.inventory')
        .factory('stockService', stockService);

    /* @ngInject */
    function stockService($http) {
        var service = {
            getWarehouses: getWarehouses,
            addAllProducts: addAllProducts,
            getStocks: getStocks,
            updateStocks: updateStocks
        };
        return service;

        function getWarehouses() {
            return $http.get('api/warehouses/');
        }

        function addAllProducts(warehouseId) {
            return $http.post('api/stocks/add-all-product?warehouseId=' + warehouseId);
        }

        function getStocks(warehouseId, params) {
            return $http.post('api/stocks/grid?warehouseId=' + warehouseId, params);
        }

        function updateStocks(warehouseId, stocks) {
            return $http.put('api/stocks?warehouseId=' + warehouseId, stocks);
        }
    }
})();