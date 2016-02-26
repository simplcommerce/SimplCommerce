(function() {
    angular.module('hvAdmin.category')
        .factory('categoryService', ['$http', function ($http) {
            function getCategories() {
                return $http.get('Admin/Category/List');
            }

            function createCategory(category) {
                return $http.post('Admin/Category/Create', category);
            }

            return {
                createCategory: createCategory,
                getCategories: getCategories
            };
    }]);
})()