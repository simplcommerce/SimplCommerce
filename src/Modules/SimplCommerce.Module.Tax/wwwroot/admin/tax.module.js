/*global angular*/
(function () {
    'use strict';

    angular.module('simplAdmin.tax', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider
                .state('tax-classes', {
                    url: '/tax-classes',
                    templateUrl: 'modules/tax/admin/tax-class/tax-class-list.html',
                    controller: 'TaxClassListCtrl as vm'
                })
                .state('tax-classes-create', {
                    url: '/tax-classes/create',
                    templateUrl: 'modules/tax/admin/tax-class/tax-class-form.html',
                    controller: 'TaxClassFormCtrl as vm'
                })
                .state('tax-classes-edit', {
                    url: '/tax-classes/edit/:id',
                    templateUrl: 'modules/tax/admin/tax-class/tax-class-form.html',
                    controller: 'TaxClassFormCtrl as vm'
                });
        }]);
})();