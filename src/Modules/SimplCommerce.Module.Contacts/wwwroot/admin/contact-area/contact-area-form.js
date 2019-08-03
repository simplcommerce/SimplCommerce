 /*global angular*/
(function () {
    angular
        .module('simplAdmin.contacts')
        .controller('ContactAreaFormCtrl', ['$state', '$stateParams', 'contactAreaService', 'translateService', ContactAreaFormCtrl]);

    function ContactAreaFormCtrl($state, $stateParams, contactAreaService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.contactArea = {};
        vm.contactAreaId = $stateParams.id;
        vm.isEditMode = vm.contactAreaId > 0;

        vm.save = function save() {
            var promise;
            if (vm.isEditMode) {
                promise = contactAreaService.editContactArea(vm.contactArea);
            } else {
                promise = contactAreaService.createContactArea(vm.contactArea);
            }

            promise
                .then(function (result) {
                    $state.go('contact-area');
                })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not add contact category.');
                    }
                });
        };

        function init() {
            if (vm.isEditMode) {
                contactAreaService.getContactArea(vm.contactAreaId).then(function (result) {
                    vm.contactArea = result.data;
                });
            }
        }

        init();
    }
})();
