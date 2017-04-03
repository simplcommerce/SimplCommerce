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
        'simplAdmin.vendors',
        'simplAdmin.localization'
    ]);

    toastr.options.closeButton = true;
    adminApp
        .config([
            '$urlRouterProvider', '$httpProvider',
            function ($urlRouterProvider, $httpProvider) {
                $urlRouterProvider.otherwise("/dashboard");

                $httpProvider.interceptors.push(function () {
                    return {
                        request: function (config) {
                            if (/modules.*admin.*\.html/i.test(config.url)) {
                                var separator = config.url.indexOf('?') === -1 ? '?' : '&';
                                config.url = config.url + separator + 'v=' + window.Global_AssetVersion;
                            }

                            return config;
                        }
                    };
                });
            }
        ]);
}());