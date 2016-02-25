(function () {
    'use strict';

    angular.module('hvAdmin.category', [])
        .config(['$stateProvider', function($stateProvider) {
            $stateProvider.state('category', {
                url: '/category',
                templateUrl: "admin/app/category/category-list.html"
            });
        }]);
})();