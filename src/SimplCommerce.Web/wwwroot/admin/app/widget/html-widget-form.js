/*global angular, jQuery*/
(function ($) {
    angular
        .module('shopAdmin.widget')
        .controller('HtmlWidgetFormCtrl', HtmlWidgetFormCtrl);

    /* @ngInject */
    function HtmlWidgetFormCtrl($state, $stateParams, summerNoteService, widgetService) {
        var vm = this;
        vm.widgetZones = [];
        vm.widgetInstanceId = $stateParams.id;
        vm.isEditMode = vm.widgetInstanceId > 0;

        vm.imageUpload = function (files) {
            summerNoteService.upload(files[0])
                .success(function (url) {
                    $(vm.htmlContent).summernote('insertImage', url);
                });
        };

        vm.save = function save() {
            var promise;
            if (vm.isEditMode) {
                promise = widgetService.editHtmlWidget(vm.widgetInstance);
            } else {
                promise = widgetService.createHtmlWidget(vm.widgetInstance);
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
                        vm.validationErrors.push('Could not html widget.');
                    }
                });
        };

        function init() {
            widgetService.getWidgetZones().then(function (result) {
                vm.widgetZones = result.data;
            });

            if (vm.isEditMode) {
                widgetService.getHtmlWidget(vm.widgetInstanceId).then(function (result) {
                    vm.widgetInstance = result.data;
                });
            }
        }

        init();
    }
})(jQuery);