/*global angular, jQuery*/
(function ($) {
    angular
        .module('shopAdmin.widget')
        .controller('CarouselFormCtrl', CarouselFormCtrl);

    /* @ngInject */
    function CarouselFormCtrl($state, $stateParams, summerNoteService, widgetService) {
        var vm = this;
        vm.widgetInstance = {zone : 1, items: [{}] };
        vm.widgetZones = [{id : 1, name : 'Home Featured'}, {id : 2, name : 'Home Content'}]
        vm.widgetInstanceId = $stateParams.id;
        vm.isEditMode = vm.widgetInstanceId > 0;

        vm.addItem = function addItem() {
            vm.widgetInstance.items.push({});
        }

        vm.removeItem = function removeItem(item) {
            var index = vm.widgetInstance.items.indexOf(item);
            vm.widgetInstance.items.splice(index, 1);
        }

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
                        vm.validationErrors.push('Could not carousel widget page.');
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