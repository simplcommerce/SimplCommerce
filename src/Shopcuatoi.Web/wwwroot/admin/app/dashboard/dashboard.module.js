(function () {
    'use strict';

    angular
        .module('shopAdmin.dashboard', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider.state('dashboard', {
                url: '/dashboard',
                templateUrl: "admin/app/dashboard/dashboard.html"
            });
        }]);
})();