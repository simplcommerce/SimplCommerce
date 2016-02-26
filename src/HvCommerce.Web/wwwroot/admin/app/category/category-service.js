(function() {
    angular.module('hvAdmin.category')
        .factory('categoryService', ['$http', function ($http) {
            function getCategories(params) {
                return $http.post('Admin/Category/List', params);
            }

            return {
                getCategories: getCategories
            };
    }]);
})()