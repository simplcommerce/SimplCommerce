/*global angular, jQuery*/
(function ($) {
    angular
        .module('shopAdmin.widget')
        .controller('CarouselFormCtrl', CarouselFormCtrl);

    /* @ngInject */
    function CarouselFormCtrl($state, $stateParams, summerNoteService, widgetService) {
        var vm = this;
        vm.widgetInstance = { items: [{}, {}, {}, {}] };
        vm.widgetZones = [{id : 1, name : 'Home Featured'}, {id : 2, name : 'Home Content'}]
        vm.widgetInstanceId = $stateParams.id;
        vm.isEditMode = vm.widgetInstanceId > 0;

        vm.item1Upload = function (files) {
            summerNoteService.upload(files[0])
                .success(function (url) {
                    $(vm.item1).summernote('insertImage', url);
                });
        };

        vm.item2Upload = function (files) {
            summerNoteService.upload(files[0])
                .success(function (url) {
                    $(vm.item2).summernote('insertImage', url);
                });
        };

        vm.item3Upload = function (files) {
            summerNoteService.upload(files[0])
                .success(function (url) {
                    $(vm.item3).summernote('insertImage', url);
                });
        };

        vm.item4Upload = function (files) {
            summerNoteService.upload(files[0])
                .success(function (url) {
                    $(vm.item4).summernote('insertImage', url);
                });
        };

        vm.save = function save() {
            var promise;
            if (vm.isEditMode) {
                promise = widgetService.editCarousel(vm.widgetInstance);
            } else {
                promise = widgetService.createCarousel(vm.widgetInstance);
            }

            promise
                .success(function (result) {
                    $state.go('widget');
                })
                .error(function (error) {
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not add page.');
                    }
                });
        };

        function init() {
            if (vm.isEditMode) {
                widgetService.getCarousel(vm.widgetInstanceId).then(function (result) {
                    vm.widgetInstance = result.data;
                });
            }
        }

        init();
    }
})(jQuery);