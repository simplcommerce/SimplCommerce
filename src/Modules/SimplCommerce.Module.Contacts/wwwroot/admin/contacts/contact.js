/*global angular*/
(function () {
    angular
        .module('simplAdmin.contacts')
        .controller('ContactCtrl', ContactCtrl);

    /* @ngInject */
    function ContactCtrl($stateParams, contactService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.contact = {};
        vm.contactId = $stateParams.id;

        function init() {
            contactService.getContact(vm.contactId).then(function (result) {
                vm.contact = result.data;
            });
        }

        init();
    }
})();
