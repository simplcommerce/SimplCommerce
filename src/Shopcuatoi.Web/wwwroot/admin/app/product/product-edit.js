/*global angular, jQuery*/
(function ($) {
    angular
        .module('shopAdmin.product')
        .controller('ProductEditCtrl', ProductEditCtrl);

    /* @ngInject */
    function ProductEditCtrl($state, $stateParams, $http, categoryService, productService, summerNoteService, manufacturerService) {
        var vm = this;
        // declare shoreDescription and description for summernote
        vm.product = { shortDescription: '', description: '', specification: '' };
        vm.product.categoryIds = [];
        vm.product.attributes = [];
        vm.product.variations = [];
        vm.categories = [];
        vm.thumbnailImage = null;
        vm.productImages = [];
        vm.attributes = [];
        vm.addingAttribute = null;
        vm.isEditMode = true;
        vm.addingVariation = { priceOffset: 0 };
        vm.manufacturers = [];

        vm.shortDescUpload = function (files) {
            summerNoteService.upload(files[0])
                .success(function (url) {
                    $(vm.shortDescEditor).summernote('insertImage', url);
                });
        };

        vm.descUpload = function (files) {
            summerNoteService.upload(files[0])
                .success(function (url) {
                    $(vm.descEditor).summernote('insertImage', url);
                });
        };

        vm.specUpload = function (files) {
            summerNoteService.upload(files[0])
                .success(function (url) {
                    $(vm.specEditor).summernote('insertImage', url);
                });
        };

        vm.addAttribute = function addAttribute() {
            vm.addingAttribute.values = [];
            var index = vm.attributes.indexOf(vm.addingAttribute);
            vm.product.attributes.push(vm.addingAttribute);
            vm.attributes.splice(index, 1);
            vm.addingAttribute = null;
        };

        vm.deleteAttr = function deleteAttr(attr) {
            var index = vm.product.attributes.indexOf(attr);
            vm.product.attributes.splice(index, 1);
            vm.attributes.push(attr);
        };

        vm.generateAttrCombination = function generateAttrCombination() {
            var maxIndexAttr = vm.product.attributes.length - 1;
            vm.product.variations = [];

            function getItemValue(item) {
                return item.value;
            }

            function helper(arr, attrIndex) {
                var j, l, variation, attrCombinations, attrValue;

                for (j = 0, l = vm.product.attributes[attrIndex].values.length; j < l; j = j + 1) {
                    attrCombinations = arr.slice(0);
                    attrValue = {
                        attributeName: vm.product.attributes[attrIndex].name,
                        attributeId: vm.product.attributes[attrIndex].id,
                        value: vm.product.attributes[attrIndex].values[j]
                    };
                    attrCombinations.push(attrValue);

                    if (attrIndex === maxIndexAttr) {
                        variation = {
                            name: attrCombinations.map(getItemValue).join('-'),
                            attributeCombinations: attrCombinations,
                            priceOffset : 0
                        };
                        vm.product.variations.push(variation);
                    } else {
                        helper(attrCombinations, attrIndex + 1);
                    }
                }
            }

            helper([], 0);
        };

        vm.deleteVariation = function deleteVariation(variation) {
            var index = vm.product.variations.indexOf(variation);
            vm.product.variations.splice(index, 1);
        };

        vm.removeMedia = function removeMedia(media) {
            var index = vm.product.productMedias.indexOf(media);
            vm.product.productMedias.splice(index, 1);
            vm.product.deletedMediaIds.push(media.id);
        };

        vm.filterAddedAttributeValue = function filterAddedAttributeValue(item) {
            if (vm.product.attributes.length > 1) {
                return true;
            }
            var attrValueAdded = false;
            vm.product.variations.forEach(function (variation) {
                var addedValues = variation.attributeCombinations.map(function (item) {
                    return item.value;
                });
                if (addedValues.indexOf(item) > -1) {
                    attrValueAdded = true;
                }
            });

            return !attrValueAdded;
        };

        vm.addVariation = function addVariation() {
            var variation,
                attrCombinations = [];

            vm.product.attributes.forEach(function (attr) {
                var attrValue = {
                    attributeName: attr.name,
                    attributeId: attr.id,
                    value: vm.addingVariation[attr.name]
                };
                attrCombinations.push(attrValue);
            });

            variation = {
                name: attrCombinations.map(function (item) {
                    return item.value;
                }).join('-'),
                attributeCombinations: attrCombinations,
                priceOffset: vm.addingVariation.priceOffset || 0
            };
            if (!vm.product.variations.find(function (item) { return item.name === variation.name; })) {
                vm.product.variations.push(variation);
                vm.addingVariation = { priceOffset: 0 };
            }
        };

        vm.save = function save() {
            productService.editProduct(vm.product, vm.thumbnailImage, vm.productImages)
                .success(function (result) {
                    $state.go('product');
                });
        };

        function getProduct() {
            productService.getProduct($stateParams.id).then(function (result) {
                var i, index, attributeIds;
                vm.product = result.data;
                attributeIds = vm.attributes.map(function (item) { return item.id; });
                for (i = 0; i < vm.product.attributes.length; i = i + 1) {
                    index = attributeIds.indexOf(vm.product.attributes[i].id);
                    vm.attributes.splice(index, 1);
                }
            });
        }

        function getCategories() {
            categoryService.getCategories().then(function (result) {
                vm.categories = result.data;
            });
        }

        function getProductAttrs() {
            productService.getProductAttrs().then(function (result) {
                vm.attributes = result.data;
            });
        }

        vm.toggleCategories = function toggleCategories(categoryId) {
            var index = vm.product.categoryIds.indexOf(categoryId);
            if (index > -1) {
                vm.product.categoryIds.splice(index, 1);
            } else {
                vm.product.categoryIds.push(categoryId);
            }
        };

        function getManufacturers() {
            manufacturerService.getManufacturers().then(function (result) {
                vm.manufacturers = result.data;
            });
        }

        function init() {
            getProduct();
            getProductAttrs();
            getCategories();
            getManufacturers();
        }

        init();
    }
})(jQuery);