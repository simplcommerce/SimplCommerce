/*global angular*/
(function () {
    angular
        .module('simplAdmin.news')
        .factory('newsCategoryService', ['$http', newsCategoryService]);

    function newsCategoryService($http) {
        var service = {
            getNewsCategory: getNewsCategory,
            createNewsCategory: createNewsCategory,
            editNewsCategory: editNewsCategory,
            deleteNewsCategory: deleteNewsCategory,
            getNewsCategories: getNewsCategories
        };
        return service;

        function getNewsCategory(id) {
            return $http.get('api/news-categories/' + id);
        }

        function getNewsCategories() {
            return $http.get('api/news-categories');
        }

        function createNewsCategory(newsCategory) {
            return $http.post('api/news-categories', newsCategory);
        }

        function editNewsCategory(newsCategory) {
            return $http.put('api/news-categories/' + newsCategory.id, newsCategory);
        }

        function deleteNewsCategory(newsCategory) {
            return $http.delete('api/news-categories/' + newsCategory.id, null);
        }
    }
})();
