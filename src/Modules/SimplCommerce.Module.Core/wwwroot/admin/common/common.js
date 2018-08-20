/*global angular*/
(function () {
   var common = angular
        .module('simplAdmin.common', []);

   common.directive('decimal', function () {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, element, attrs, ngModelController) {
                function transform(text) {
                    if (text) {
                        var val = text.replace(/[^0-9.,]/g, '');
                        if (val !== text) {
                            ngModelController.$setViewValue(val);
                            ngModelController.$render();
                        }

                        return val.replace(",", ".");
                    }

                    return null;
                }
                ngModelController.$parsers.push(transform);
            }
        };
    });
}());