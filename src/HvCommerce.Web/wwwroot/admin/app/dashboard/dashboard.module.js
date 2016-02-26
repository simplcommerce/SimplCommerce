(function () {
    'use strict';

    angular
        .module('hvAdmin.dashboard', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider.state('dashboard', {
                url: '/dashboard',
                templateUrl: "admin/app/dashboard/dashboard.html"
            });
        }]);
})();