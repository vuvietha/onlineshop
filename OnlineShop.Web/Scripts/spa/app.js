/// <reference path="../plugins/angular/angular.js" />

//create module
var myApp = angular.module('myModule', []);

//register the controller with the module
myApp.controller("schoolController", schoolController);
myApp.service("Validator", Validator)
//myApp.controller("myController", function ($scope) { $scope.message = "This is my message from controller"; });

//inject $scope into myController like autofac mechanism in backend
//myController.$inject = ['$scope'];

schoolController.$inject = ['$scope', 'Validator'];

//Create controller
function schoolController($scope, Validator) {
    //Validator.checkNumber(2);
    //$scope.message = Validator.checkNumber(1);
    $scope.checkNumber = function () {
        $scope.message = Validator.checkNumber(1);
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

function Validator($window) {
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