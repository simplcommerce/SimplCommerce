/*global angular, confirm*/
(function () {
    angular
        .module('simplAdmin.news')
        .controller('NewsItemListCtrl', NewsItemListCtrl);

    /* @ngInject */
    function NewsItemListCtrl(newsItemService) {
        var vm = this;
        vm.newsItems = [];

        vm.getNewsItems = function getNewsItems() {
            newsItemService.getNewsItems().then(function (result) {
                vm.newsItems = result.data;
            });
        };

        vm.deleteNewsItem = function deleteNewsItem(newsItem) {
            bootbox.confirm('Are you sure you want to delete this news item: ' + newsItem.name, function (result) {
                if (result) {
                    newsItemService.deleteNewsItem(newsItem)
                       .then(function (result) {
                           vm.getNewsItems();
                           toastr.success(newsItem.name + ' has been deleted');
                       })
                        .catch(function (response) {
                            toastr.error(response.data.error);
                       });
                }
            });
        };

        vm.getNewsItems();
    }
})();