/*global angular*/
(function () {
    'use strict';

    angular.module('simplAdmin.inventory', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider
                .state('stocks', {
                    url: '/stocks',
                    templateUrl: 'modules/inventory/admin/stock/stock-form.html',
                    controller: 'StockFormCtrl as vm'
                });
        }]);
})();