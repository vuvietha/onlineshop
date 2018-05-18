﻿/// <reference path="/Assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('onlineshop',
        ['onlineshop.products',
         'onlineshop.product_categories',
         'onlineshop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('base', {
            url: "",
            templateUrl: "/app/shared/views/baseView.html",
            abstract:true,
        }).state('login', {
            url: "/login",
            templateUrl: "/app/components/login/loginView.html",
            controller: "loginController"
        }).state('home', {
            url: "/admin",
            parent:"base",
            templateUrl: "/app/components/home/homeView.html",
            controller: "homeController"
        });
        $urlRouterProvider.otherwise('/admin');
    }

})();