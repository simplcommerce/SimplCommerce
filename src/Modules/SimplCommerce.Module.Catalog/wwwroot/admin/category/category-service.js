/*global angular*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .factory('categoryService', categoryService);

    /* @ngInject */
    function categoryService($http) {
        var service = {
            getCategory: getCategory,
            createCategory: createCategory,
            editCategory: editCategory,
            deleteCategory: deleteCategory,
            getCategories: getCategories
        };
        return service;

        function getCategory(id) {
            return $http.get('api/categories/' + id);
        }

        function getCategories() {
            return $http.get('api/categories');
        }

        function createCategory(category) {
            return $http.post('api/categories', category);
        }

        function editCategory(category) {
            return $http.put('api/categories/' + category.id, category);
        }

        function deleteCategory(category) {
            return $http.delete('api/categories/' + category.id);
        }
    }
})();