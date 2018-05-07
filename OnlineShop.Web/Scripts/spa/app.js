/// <reference path="onlineShopDirective.html" />
/// <reference path="../plugins/angular/angular.js" />

//create module
var myApp = angular.module('myModule', []);

//register the controller with the module
myApp.controller("schoolController", schoolController);
myApp.service("validatorService", validatorService)
myApp.directive("onlineShopDirective", onlineShopDirective)
//myApp.controller("myController", function ($scope) { $scope.message = "This is my message from controller"; });

//inject $scope into myController like autofac mechanism in backend
//myController.$inject = ['$scope'];

schoolController.$inject = ['$scope', 'validatorService'];

//Create controller
function schoolController($scope, validatorService) {
    //Validator.checkNumber(2);
    //$scope.message = Validator.checkNumber(1);
    $scope.checkNumber = function () {
        $scope.message = validatorService.checkNumber(1);
    }
    $scope.num = 1;
}

//function Validator($window) {
//    return {
//        checkNumber: checkNumber
//    }
//    function checkNumber(input) {
//        if (input % 2 == 0) {
//            $window.alert("This is even");
//        } else {
//            $window.alert("This is odd");
//        }
//    }
//}

function validatorService($window) {
    return {
        checkNumber: checkNumber
    }
    function checkNumber(input) {
        if (input % 2 == 0) {
            return "This is even";
        } else {
            return "This is odd";
        }
    }
}

function onlineShopDirective() {
    return {
        //template:"<h1>This is my first custom directive</h1>"
        templateUrl : "/Scripts/spa/onlineShopDirective.html"
    }
}