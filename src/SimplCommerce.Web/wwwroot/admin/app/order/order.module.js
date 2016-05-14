/*global angular*/
(function () {
    'use strict';

    angular
        .module('shopAdmin.order', [])
        .config(['$stateProvider',
            function ($stateProvider) {
                $stateProvider
                    .state('order', {
                        url: '/order',
                        templateUrl: 'admin/app/order/order-list.html',
                        controller: 'OrderListCtrl as vm'
                    })
                    .state('order-detail', {
                        url: '/order/detail/:id',
                        templateUrl: 'admin/app/order/order-detail.html',
                        controller: 'OrderDetailCtrl as vm'
                    })
                ;
            }
        ]);
})();