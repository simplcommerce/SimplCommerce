/*global angular*/
(function () {
    'use strict';

    angular.module('simplAdmin.cms', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider
                .state('page', {
                    url: '/page',
                    templateUrl: 'cms/admin/page/page-list.html',
                    controller: 'PageListCtrl as vm'
                })
                .state('page-create', {
                    url: '/page/create',
                    templateUrl: 'cms/admin/page/page-form.html',
                    controller: 'PageFormCtrl as vm'
                })
                .state('page-edit', {
                    url: '/page/edit/:id',
                    templateUrl: 'cms/admin/page/page-form.html',
                    controller: 'PageFormCtrl as vm'
                });
        }]);
})();