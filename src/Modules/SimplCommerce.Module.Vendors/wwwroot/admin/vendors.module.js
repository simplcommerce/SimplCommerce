/*global angular*/
(function () {
    'use strict';

    angular
        .module('simplAdmin.vendors', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider.state('vendors', {
                url: '/vendors',
                templateUrl: "modules/vendors/admin/vendors/vendor-list.html",
                controller: 'VendorListCtrl as vm'
            })
        }]);
})();