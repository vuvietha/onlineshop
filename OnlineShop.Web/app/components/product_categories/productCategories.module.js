﻿/// <reference path="/Assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('onlineshop.product_categories', ['onlineshop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('product_categories', {
            url: "/product_categories",
            templateUrl: "/app/components/product_categories/productCategoryListView.html",
            controller: "productCategoryListController"
        }).state('productcategory_add', {
            url: "/productcategory_add",
            templateUrl: "/app/components/product_categories/productCategoryAddView.html",
            controller: "productCategoryAddController"
        }).state('productcategory_edit', {
            url: "/productcategory_edit",
            templateUrl: "/app/components/product_categories/productCategoryEditView.html",
            controller: "productCategoryEditController"
        });

    }

})();