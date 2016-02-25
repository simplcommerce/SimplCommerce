(function () {
    'use strict';

    angular.module('hvAdmin.product', [])
        .config(['$stateProvider', function($stateProvider) {
            $stateProvider.state('product', {
                url: '/product',
                templateUrl: "admin/app/product/product-list.html"
            });
        }]);
})();