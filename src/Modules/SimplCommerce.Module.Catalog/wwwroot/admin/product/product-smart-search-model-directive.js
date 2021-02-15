(function () {
    angular
        .module('simplAdmin.catalog')
        .directive('stSearchModel', ['$parse', '$$debounce', stSearchModel]);

    function stSearchModel($parse, $$debounce) {
            return {
                require:'^stTable',
                link: function (scope, elem, attr, ctrl) {

                    scope.$watch(
                        function () {
                            return $parse(attr.stSearchModel)(scope);
                        },

                        $$debounce(function (filter) {
                            if (filter) {
                                for (const [key, value] of Object.entries(filter)) {
                                    ctrl.search(value, key);
                                }
                            }
                        }, 400),

                        true
                    );
                }
            };
        }
})();
