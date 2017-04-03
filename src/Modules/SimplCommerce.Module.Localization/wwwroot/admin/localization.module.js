/*global angular*/
(function () {
    'use strict';

    angular
        .module('simplAdmin.localization', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider.state('localization', {
                url: '/localization',
                templateUrl: "modules/localization/admin/localization/localization-form.html",
                controller: 'LocalizationFormCtrl as vm'
            });
        }]);
})();