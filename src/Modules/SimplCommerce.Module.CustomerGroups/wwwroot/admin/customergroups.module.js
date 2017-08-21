/*global angular*/
(function () {
    'use strict';

    angular
        .module('simplAdmin.customergroups', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider.state('customergroups', {
                url: '/customergroups',
                templateUrl: "modules/customergroups/admin/customergroups/customergroup-list.html",
                controller: 'CustomerGroupListCtrl as vm'
            })
                .state('customergroup-create', {
                    url: '/customergroups/create',
                    templateUrl: "modules/customergroups/admin/customergroups/customergroup-form.html",
                    controller: 'CustomerGroupFormCtrl as vm'
                })
                .state('customergroup-edit', {
                    url: '/customergroups/edit/:id',
                    templateUrl: 'modules/customergroups/admin/customergroups/customergroup-form.html',
                    controller: 'CustomerGroupFormCtrl as vm'
                });
        }]);
})();
