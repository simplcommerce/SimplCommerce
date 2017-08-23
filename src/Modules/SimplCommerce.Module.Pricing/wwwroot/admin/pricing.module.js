/*global angular*/
(function () {
    'use strict';

    angular
        .module('simplAdmin.pricing', [])
        .config(['$stateProvider',
            function ($stateProvider) {
                $stateProvider
                    .state('cartrule', {
                        url: '/cartrule',
                        templateUrl: 'modules/pricing/admin/cartrule/cartrule-list.html',
                        controller: 'CartRuleListCtrl as vm'
                    })
                    .state('cartrule-create', {
                        url: '/cartrule/create',
                        templateUrl: 'modules/pricing/admin/cartrule/cartrule-form.html',
                        controller: 'CartRuleFormCtrl as vm'
                    })
                    .state('cartrule-edit', {
                        url: '/cartrule/edit/:id',
                        templateUrl: 'modules/pricing/admin/cartrule/cartrule-form.html',
                        controller: 'CartRuleFormCtrl as vm'
                    })
                ;
            }
        ]);
})();