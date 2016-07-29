/*global angular*/
(function () {
    'use strict';

    angular
        .module('simplAdmin.core', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider.state('user', {
                url: '/user',
                templateUrl: "core/admin/user/user-list.html",
                controller: 'UserListCtrl as vm'
            });
        }]);
})();