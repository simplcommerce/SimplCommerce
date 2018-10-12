/*global angular*/
(function () {
    angular
        .module('simplAdmin.orders')
        .factory('orderService', orderService);

    /* @ngInject */
    function orderService($http) {
        var service = {
            getOrders: getOrders,
            getOrdersForGrid: getOrdersForGrid,
            getOrder: getOrder,
            getOrderStatus: getOrderStatus,
            changeOrderStatus: changeOrderStatus,
            getOrderHistory: getOrderHistory,
            getOrdersExport: getOrdersExport,
            getOrderLinesExport: getOrderLinesExport
        };
        return service;

        function getOrdersForGrid(params) {
            return $http.post('api/orders/grid', params);
        }

        function getOrders(status, numRecords) {
            return $http.get('api/orders?status=' + status + '&numRecords=' + numRecords);
        }

        function getOrder(orderId) {
            return $http.get('api/orders/' + orderId);
        }

        function getOrderStatus() {
            return $http.get('api/orders/order-status');
        }

        function changeOrderStatus(orderId, statusModel) {
            return $http.post('api/orders/change-order-status/' + orderId, statusModel);
        }

        function getOrderHistory(orderId) {
            return $http.get('api/orders/' + orderId + '/history');
        }

        function getOrdersExport(params) {
            var config = { responseType: 'blob' };
            var httpPromise = $http.post('api/orders/export', params);

            httpPromise.then(function (response) {
                console.log(response);
                var blob = new Blob([response.data], { type: "application/octet-stream" });
                var objectUrl = URL.createObjectURL(blob);

                let a = document.createElement("a");
                a.style = "display: none";
                document.body.appendChild(a);
                let url = window.URL.createObjectURL(blob);
                a.href = url;
                a.download = 'orders-export.csv'; // gives it a name via an a tag
                a.click();
                window.URL.revokeObjectURL(objectUrl);

                //window.open(objectUrl);
            });
        }

        function getOrderLinesExport(params) {
            var config = { responseType: 'blob' };
            var httpPromise = $http.post('api/orders/lines-export', params);

            httpPromise.then(function (response) {
                console.log(response);
                var blob = new Blob([response.data], { type: "application/octet-stream" });
                var objectUrl = URL.createObjectURL(blob);

                let a = document.createElement("a");
                a.style = "display: none";
                document.body.appendChild(a);
                let url = window.URL.createObjectURL(blob);
                a.href = url;
                a.download = 'orders-lines-export.csv'; // gives it a name via an a tag
                a.click();
                window.URL.revokeObjectURL(objectUrl);

                //window.open(objectUrl);
            });
        }
    }
})();
