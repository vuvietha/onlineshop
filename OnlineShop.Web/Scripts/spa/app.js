/// <reference path="../plugins/angular/angular.js" />

//create module
var myApp = angular.module('myModule', []);

//register the controller with the module
myApp.controller("schoolController", schoolController);
myApp.controller("studentController", studentController);
myApp.controller("teacherController", teacherController);

//myApp.controller("myController", function ($scope) { $scope.message = "This is my message from controller"; });

//inject $scope into myController like autofac mechanism in backend
//myController.$inject = ['$scope'];

//Create controller
function schoolController($scope) {
    $scope.message = "This is my message from schoolController";
}
function studentController($scope) {
    $scope.message = "This is my message from studentController";
}

function teacherController($scope) {
    $scope.message = "This is my message from teacherController";
}