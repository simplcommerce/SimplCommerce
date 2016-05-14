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
                ;
            }
        ]);
})();