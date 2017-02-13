/*global angular*/
(function () {
    'use strict';

    angular
        .module('simplAdmin.core', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider.state('user', {
                url: '/user',
                templateUrl: "modules/core/admin/user/user-list.html",
                controller: 'UserListCtrl as vm'
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
            });
        }]);
})();