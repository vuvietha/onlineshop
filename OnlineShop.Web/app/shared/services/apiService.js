﻿/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function (app) {
    app.factory('apiService', apiService);
    apiService.$inject = ['$http','notificationService']
    function apiService($http, notificationService) {
        return {
            get: get,
            post:post
        }
        function get(url, param, success, failure) {
            $http.get(url, param).then(function (result) {
                success(result);
               

            }, function (error) {
                failure(error);
              
            })

        }
        function post(url, data, success, failure) {
            $http.post(url, data).then(function (result) {
                success(result);    
            }, function (error) {
                if (error.status === 401) {
                    notificationService.displayError('Authenticate is required');
                }
                failure(error);   
            })
        }

    }
})(angular.module('onlineshop.common'));