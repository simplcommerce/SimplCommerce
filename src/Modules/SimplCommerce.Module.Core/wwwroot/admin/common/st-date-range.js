/*global angular*/
(function () {
    'use strict';

    angular
        .module('simplAdmin.common')
        .directive('stDateRange', ['$timeout', function ($timeout) {
            return {
                restrict: 'E',
                require: '^stTable',
                scope: {
                    before: '=',
                    after: '='
                },
                templateUrl: 'modules/core/admin/common/st-date-range.html',
                link: function (scope, element, attr, table) {
                    var predicateName = attr.predicate;

                    scope.changeDate = function() {
                        var query = {};
                        if (scope.before) {
                            query.before = scope.before;
                            query.before = new Date(query.before.setDate(query.before.getDate() + 1));
                        }

                        if (scope.after) {
                            query.after = scope.after;
                        }

                        table.search(query, predicateName);
                    };

                    function open(before) {
                        return function ($event) {
                            $event.preventDefault();
                            $event.stopPropagation();

                            if (before) {
                                scope.isBeforeOpen = true;
                            } else {
                                scope.isAfterOpen = true;
                            }
                        };
                    }

                    scope.openBefore = open(true);
                    scope.openAfter = open();
                }
            };
        }]);
})();