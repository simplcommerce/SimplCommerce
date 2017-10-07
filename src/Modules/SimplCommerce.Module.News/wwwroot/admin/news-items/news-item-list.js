/*global angular, confirm*/
(function () {
    angular
        .module('simplAdmin.news')
        .controller('NewsItemListCtrl', NewsItemListCtrl);

    /* @ngInject */
    function NewsItemListCtrl(newsItemService, translateService) {
        var vm = this,
            tableStateRef;
        vm.translate = translateService;
        vm.newsItems = [];

        vm.getNewsItems = function getNewsItems(tableState) {
            tableStateRef = tableState;
            vm.isLoading = true;
            newsItemService.getNewsItems(tableState).then(function (result) {
                vm.newsItems = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                vm.isLoading = false;
            });
        };

        vm.deleteNewsItem = function deleteNewsItem(newsItem) {
            bootbox.confirm('Are you sure you want to delete this news item: ' + newsItem.name, function (result) {
                if (result) {
                    newsItemService.deleteNewsItem(newsItem)
                       .then(function (result) {
                           vm.getNewsItems(tableStateRef);
                           toastr.success(newsItem.name + ' has been deleted');
                       })
                        .catch(function (response) {
                            toastr.error(response.data.error);
                       });
                }
            });
        };
    }
})();