/*global angular*/
(function () {
    'use strict';

    angular
        .module('simplAdmin.orders', [])
        .config(['$stateProvider',
            function ($stateProvider) {
                $stateProvider
                    .state('order', {
                        url: '/order',
                        templateUrl: '_content/SimplCommerce.Module.Orders/admin/order/order-list.html',
                        controller: 'OrderListCtrl as vm'
                    })
                    .state('order-detail', {
                        url: '/order/detail/:id',
                        templateUrl: '_content/SimplCommerce.Module.Orders/admin/order/order-detail.html',
                        controller: 'OrderDetailCtrl as vm'
                    })
                    .state('order-create', {
                        url: '/order-create',
                        templateUrl: '_content/SimplCommerce.Module.Orders/admin/order/order-create.html',
                        controller: 'OrderCreateCtrl as vm'
                    })
                ;
            }
        ]);
})();
