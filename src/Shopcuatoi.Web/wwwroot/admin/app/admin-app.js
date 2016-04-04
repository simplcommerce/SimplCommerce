/*global angular*/
(function () {
    var adminApp = angular.module('shopAdmin', [
        'ui.router',
        'ngMaterial',
        'ngMessages',
        'smart-table',
        'ngFileUpload',
        'ui.bootstrap',
        'summernote',
        'shopAdmin.common',
        'shopAdmin.dashboard',
        'shopAdmin.user',
        'shopAdmin.category',
        'shopAdmin.product'
    ]);

    adminApp.config([
        '$urlRouterProvider',
        function ($urlRouterProvider) {
            $urlRouterProvider.otherwise("/dashboard");
        }
    ]);
}());