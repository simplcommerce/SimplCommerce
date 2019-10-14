/*global angular*/
(function () {
    angular
        .module('simplAdmin.orders')
        .factory('orderService', ['$http', orderService]);

    function orderService($http) {
        var service = {
            getOrders: getOrders,
            getOrdersForGrid: getOrdersForGrid,
            getOrder: getOrder,
            getOrderStatus: getOrderStatus,
            changeOrderStatus: changeOrderStatus,
            getOrderHistory: getOrderHistory,
            getOrdersExport: getOrdersExport,
            getOrderLinesExport: getOrderLinesExport,
            getCart: getCart,
            addCartItem: addCartItem,
            updateCartItem: updateCartItem,
            removeCartItem: removeCartItem,
            getCountries: getCountries,
            getStatesOrProvinces: getStatesOrProvinces,
            getDistricts: getDistricts,
            updateTaxAndShippingPrice: updateTaxAndShippingPrice,
            createOrder: createOrder,
            getCustomerAddresses: getCustomerAddresses
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
            var httpPromise = $http.post('api/orders/export', params, config);

            httpPromise.then(function (response) {
                var blob = new Blob([response.data], { type: "text/csv" });
                getBlob(blob, "orders-export.csv");
            });
        }

        function getOrderLinesExport(params) {
            var config = { responseType: 'blob' };
            var httpPromise = $http.post('api/orders/lines-export', params, config);

            httpPromise.then(function (response) {
                var blob = new Blob([response.data], { type: "text/csv" });
                getBlob(blob, "order-lines-export.csv");
            });
        }

        function getBlob(blob, filename) {
            //IE11 & Edge
            if (navigator.msSaveBlob) {
                navigator.msSaveBlob(blob, filename);
            }
            else {
                var objectUrl = URL.createObjectURL(blob);
                var a = document.createElement("a");
                a.href = objectUrl;
                a.style = "display: none";
                a.download = filename; // gives it a name via an a tag
                document.body.appendChild(a);
                a.click();
                window.URL.revokeObjectURL(objectUrl);
                document.body.removeChild(a);
            }
        }

        function getCart(customerId) {
            return $http.get('api/customers/' + customerId + '/cart');
        }

        function addCartItem(customerId, cartItem) {
            return $http.post('api/customers/' + customerId + '/add-cart-item', cartItem);
        }

        function updateCartItem(cartItem) {
            return $http.put('api/carts/items/' + cartItem.id, cartItem);
        }

        function removeCartItem(cartItemId) {
            return $http.delete('api/carts/items/' + cartItemId);
        }

        function getCountries() {
            return $http.get('api/countries');
        }

        function getStatesOrProvinces(countryId) {
            return $http.get('/api/country-states-provinces/' + countryId);
        }

        function getDistricts(stateOrProvinceId) {
            return $http.get('api/states-provinces/' + stateOrProvinceId + '/districts');
        }

        function updateTaxAndShippingPrice(cartId, taxAndShippingPriceRequestVm) {
            return $http.post('api/cart/' + cartId + '/update-tax-and-shipping-prices', taxAndShippingPriceRequestVm);
        }

        function createOrder(cartId, orderInfo) {
            return $http.post('api/cart/' + cartId + '/order', orderInfo);
        }

        function getCustomerAddresses(customerId) {
            return $http.get('api/users/' + customerId +'/addresses');
        }
    }
})();
