/*global angular*/
(function () {
    'use strict';

    angular
        .module('shopAdmin.user', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider.state('user', {
                url: '/user',
                templateUrl: "core/admin/user/user-list.html",
                controller: 'UserListCtrl as vm'
            });
        }]);
})();