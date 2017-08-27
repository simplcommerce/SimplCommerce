/*global angular*/
(function () {
    'use strict';

    angular
        .module('simplAdmin.core', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider.state('users', {
                url: '/users',
                templateUrl: "modules/core/admin/user/user-list.html",
                controller: 'UserListCtrl as vm'
            })
                .state('user-create', {
                    url: '/user/create',
                    templateUrl: 'modules/core/admin/user/user-form.html',
                    controller: 'UserFormCtrl as vm'
                })
                .state('user-edit', {
                    url: '/user/edit/:id',
                    templateUrl: 'modules/core/admin/user/user-form.html',
                    controller: 'UserFormCtrl as vm'
                })
                .state('widget', {
                    url: '/widget',
                    templateUrl: 'modules/core/admin/widget/widget-instance-list.html',
                    controller: 'WidgetInstanceListCtrl as vm'
                })
                .state('configuration', {
                    url: '/configuration',
                    templateUrl: 'modules/core/admin/configuration/configuration.html',
                    controller: 'ConfigurationCtrl as vm'
                })
                .state('customergroups', {
                    url: '/customergroups',
                    templateUrl: "modules/core/admin/customergroups/customergroup-list.html",
                    controller: 'CustomerGroupListCtrl as vm'
                })
                .state('customergroup-create', {
                    url: '/customergroups/create',
                    templateUrl: "modules/core/admin/customergroups/customergroup-form.html",
                    controller: 'CustomerGroupFormCtrl as vm'
                })
                .state('customergroup-edit', {
                    url: '/customergroups/edit/:id',
                    templateUrl: 'modules/core/admin/customergroups/customergroup-form.html',
                    controller: 'CustomerGroupFormCtrl as vm'
                });
        }]);
})();