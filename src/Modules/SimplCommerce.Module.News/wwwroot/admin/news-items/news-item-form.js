/*global angular, jQuery*/
(function ($) {
    angular
        .module('simplAdmin.news')
        .controller('NewsItemFormCtrl', NewsItemFormCtrl);

    /* @ngInject */
    function NewsItemFormCtrl($state, $stateParams, summerNoteService, newsItemService, newsCategoryService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.newsItem = { isPublished: true };
        vm.newsCategories = [];
        vm.newsItem.newsCategoryIds = [];
        vm.newsItemId = $stateParams.id;
        vm.isEditMode = vm.newsItemId > 0;

        vm.updateSlug = function () {
            vm.newsItem.slug = slugify(vm.newsItem.name);
        };

        vm.imageUpload = function (files) {
            summerNoteService.upload(files[0])
                .then(function (response) {
                    $(vm.body).summernote('insertImage', response.data);
                });
        };

        vm.save = function save() {
            var promise;
            // ng-upload will post null as text
            vm.newsItem.metaTitle = vm.newsItem.metaTitle === null ? '' : vm.newsItem.metaTitle;
            vm.newsItem.metaKeywords = vm.newsItem.metaKeywords === null ? '' : vm.newsItem.metaKeywords;
            vm.newsItem.metaDescription = vm.newsItem.metaDescription === null ? '' : vm.newsItem.metaDescription;

            if (vm.isEditMode) {
                promise = newsItemService.editNewsItem(vm.newsItem);
            } else {
                promise = newsItemService.createNewsItem(vm.newsItem);
            }

            promise
                .then(function (result) {
                    $state.go('news-items');
                })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not add news item.');
                    }
                });
        };

        function getNewsCategories() {
            newsCategoryService.getNewsCategories().then(function (result) {
                vm.newsCategories = result.data;
            });
        }

        vm.toggleNewsCategories = function toggleNewsCategories(newsCategoryId) {
            var index = vm.newsItem.newsCategoryIds.indexOf(newsCategoryId);
            if (index > -1) {
                vm.newsItem.newsCategoryIds.splice(index, 1);
            } else {
                vm.newsItem.newsCategoryIds.push(newsCategoryId);
            }
        };

        function init() {
            if (vm.isEditMode) {
                newsItemService.getNewsItem(vm.newsItemId).then(function (result) {
                    vm.newsItem = result.data;
                });
            }
            getNewsCategories()
        }

        init();
    }
})(jQuery);