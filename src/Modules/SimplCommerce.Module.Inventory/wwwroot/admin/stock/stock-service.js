/*global angular*/
(function () {
    angular
        .module('simplAdmin.inventory')
        .factory('stockService', ['$http', stockService]);

    function stockService($http) {
        var service = {
            getWarehouses: getWarehouses,
            getStocks: getStocks,
            updateStocks: updateStocks,
            getStockHistory: getStockHistory
        };
        return service;

        function getWarehouses() {
            return $http.get('api/warehouses/');
        }

        function getStocks(warehouseId, params) {
            return $http.post('api/stocks/grid?warehouseId=' + warehouseId, params);
        }

        function updateStocks(warehouseId, stocks) {
            return $http.put('api/stocks?warehouseId=' + warehouseId, stocks);
        }

        function getStockHistory(warehouseId, productId) {
            return $http.get('api/stocks/history?warehouseId=' + warehouseId + '&productId=' + productId);
        }
    }
})();
