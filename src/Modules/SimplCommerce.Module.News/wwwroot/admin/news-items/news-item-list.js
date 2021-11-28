/*global angular, confirm*/
(function () {
    angular
        .module('simplAdmin.news')
        .controller('NewsItemListCtrl', ['newsItemService', 'translateService', NewsItemListCtrl]);

    function NewsItemListCtrl(newsItemService, translateService) {
        var vm = this;
        vm.tableStateRef = {};
        vm.translate = translateService;
        vm.newsItems = [];

        vm.getNewsItems = function getNewsItems(tableState) {
            vm.tableStateRef = tableState;
            vm.isLoading = true;
            newsItemService.getNewsItems(tableState).then(function (result) {
                vm.newsItems = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                tableState.pagination.totalItemCount = result.data.totalRecord;
                vm.isLoading = false;
            });
        };

        vm.deleteNewsItem = function deleteNewsItem(newsItem) {
            bootbox.confirm('Are you sure you want to delete this news item: ' + simplUtil.escapeHtml(newsItem.name), function (result) {
                if (result) {
                    newsItemService.deleteNewsItem(newsItem)
                       .then(function (result) {
                           vm.getNewsItems(vm.tableStateRef);
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
