/*global angular*/
(function () {
    var adminApp = angular.module('simplAdmin', [
        'ui.router',
        'ngMaterial',
        'ngMessages',
        'smart-table',
        'ngFileUpload',
        'ui.bootstrap',
        'ui.bootstrap.datetimepicker',
        'summernote',
        'simplAdmin.common',
        'simplAdmin.dashboard',
        'simplAdmin.core',
        'simplAdmin.catalog',
        'simplAdmin.orders',
        'simplAdmin.cms',
        'simplAdmin.search',
        'simplAdmin.reviews',
        'simplAdmin.activityLog',
        'simplAdmin.vendors'
    ]);

    toastr.options.closeButton = true;
    adminApp
        .config([
            '$urlRouterProvider',
            function ($urlRouterProvider) {
                $urlRouterProvider.otherwise("/dashboard");
            }
        ])
        .config(['$httpProvider', function ($httpProvider) {
            $httpProvider.interceptors.push(function () {
                return {
                    request: function (config) {
                        if (config.url.indexOf('.html') > -1) {
                            var separator = config.url.indexOf('?') === -1 ? '?' : '&';
                            config.url = config.url + separator + 'c=' + window.Global_AssetVersion;
                        }

                        return config;
                    }
                };
            });
        }]);
}());