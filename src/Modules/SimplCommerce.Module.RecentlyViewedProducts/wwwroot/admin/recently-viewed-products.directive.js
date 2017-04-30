(function () {
    'use strict';

    angular
        .module('app')
        .directive('recently_viewed_products', recently_viewed_products);

    recently_viewed_products.$inject = ['$window'];

    function recently_viewed_products($window) {
        // Usage:
        //     <recently_viewed_products></recently_viewed_products>
        // Creates:
        // 
        var directive = {
            link: link,
            restrict: 'EA'
        };
        return directive;

        function link(scope, element, attrs) {
        }
    }

})();