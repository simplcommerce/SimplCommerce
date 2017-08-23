/*global angular*/
(function () {
    angular
        .module('simplAdmin.pricing')
        .factory('cartRuleService', cartRuleService);

    /* @ngInject */
    function cartRuleService($http) {
        var service = {
            getCartRule: getCartRule,
            createCartRule: createCartRule,
            editCartRule: editCartRule,
            deleteCartRule: deleteCartRule,
            getCartRules: getCartRules
        };
        return service;

        function getCartRule(id) {
            return $http.get('api/cartrules/' + id);
        }

        function getCartRules(params) {
            return $http.post('api/cartrules/grid', params);
        }

        function createCartRule(cartRule) {
            return $http.post('api/cartrules', cartRule);
        }

        function editCartRule(cartRule) {
            return $http.put('api/cartrules/' + cartRule.id, cartRule);
        }

        function deleteCartRule(cartRule) {
            return $http.delete('api/cartrules/' + cartRule.id, null);
        }
    }
})();