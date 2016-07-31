/*global angular*/
(function () {
    'use strict';

    angular
        .module('simplAdmin.dashboard', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider.state('dashboard', {
                url: '/dashboard',
                templateUrl: "admin/dashboard/dashboard.html"
            });
        }]);
})();