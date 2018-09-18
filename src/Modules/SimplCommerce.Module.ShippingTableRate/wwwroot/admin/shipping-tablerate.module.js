/*global angular*/
(function () {
    'use strict';

    angular
        .module('simplAdmin.shipping-tablerate', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider.state('shipping-table-rate-config', {
                url: '/shippings/table-rate-config',
                templateUrl: "modules/shippingtablerate/admin/tablerate/shipping-tablerate-form.html",
                controller: 'ShippingTableRateFormCtrl as vm'
            });
        }]);
})();