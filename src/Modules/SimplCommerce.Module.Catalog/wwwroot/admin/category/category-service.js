/*global angular*/
(function () {
    angular
        .module('simplAdmin.catalog')
        .factory('categoryService', categoryService);

    /* @ngInject */
    function categoryService($http, Upload) {
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
            return Upload.upload({
                url: 'api/categories',
                data: category
            });
        }

        function editCategory(category) {
            return Upload.upload({
                url: 'api/categories/' + category.id,
                method: 'PUT',
                data: category
            });
        }

        function deleteCategory(category) {
            return $http.delete('api/categories/' + category.id);
        }
    }
})();