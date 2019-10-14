/*global angular*/
(function () {
    angular
        .module('simplAdmin.news')
        .factory('newsItemService', ['$http', 'Upload', newsItemService]);

    function newsItemService($http, Upload) {
        var service = {
            getNewsItem: getNewsItem,
            createNewsItem: createNewsItem,
            editNewsItem: editNewsItem,
            deleteNewsItem: deleteNewsItem,
            getNewsItems: getNewsItems
        };
        return service;

        function getNewsItem(id) {
            return $http.get('api/news-items/' + id);
        }

        function getNewsItems(params) {
            return $http.post('api/news-items/grid', params);
        }

        function createNewsItem(newsItem) {
            return Upload.upload({
                url: 'api/news-items',
                data: newsItem
            });
        }

        function editNewsItem(newsItem) {
            return Upload.upload({
                url: 'api/news-items/' + newsItem.id,
                method: 'PUT',
                data: newsItem
            });
        }  

        function deleteNewsItem(newsItem) {
            return $http.delete('api/news-items/' + newsItem.id, null);
        }
    }
})();
