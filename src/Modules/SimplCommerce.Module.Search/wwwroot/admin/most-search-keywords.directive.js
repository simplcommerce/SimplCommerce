(function() {
    angular
        .module('simplAdmin.search')
        .directive('mostSearchKeyword', mostSearchKeyword);

    function mostSearchKeyword() {
        var directive = {
            restrict: 'E',
            templateUrl: 'search/admin/most-search-keywords.directive.html',
            scope: {},
            controller: MostSearchKeywordCtrl,
            controllerAs: 'vm',
            bindToController: true
        };

        return directive;
    }

    /* @ngInject */
    function MostSearchKeywordCtrl(searchService) {
        var vm = this;
        vm.keywords = [];

        searchService.getMostSearchKeywords().then(function (result) {
            vm.keywords = result.data;
        });
    }
})();
