(function() {
    var adminApp = angular.module('hvAdmin', [
        'ui.router',
        'smart-table',
        'hvAdmin.dashboard',
        'hvAdmin.user',
        'hvAdmin.category',
        'hvAdmin.product'
    ]);

    adminApp.config(['$urlRouterProvider',
        function ($urlRouterProvider) {
            $urlRouterProvider.otherwise("/dashboard");
        }
    ]);
})()