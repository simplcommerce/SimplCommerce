/*global angular*/
(function () {
    angular
        .module('simplAdmin.pricing')
        .factory('cartRuleService', ['$http', cartRuleService]);

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
            return $http.get('api/cart-rules/' + id);
        }

        function getCartRules(params) {
            return $http.post('api/cart-rules/grid', params);
        }

        function createCartRule(cartRule) {
            return $http.post('api/cart-rules', cartRule);
        }

        function editCartRule(cartRule) {
            return $http.put('api/cart-rules/' + cartRule.id, cartRule);
        }

        function deleteCartRule(cartRule) {
            return $http.delete('api/cart-rules/' + cartRule.id, null);
        }
    }
})();
