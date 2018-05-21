(function (app) {
    app.controller('loginController', ['$scope', 'loginService', '$injector', 'notificationService',
        function ($scope, loginService, $injector, notificationService) {
            $scope.loginData = {
                username: "",
                password: ""

            }
            $scope.login = function () {
                loginService.login($scope.loginData.username, $scope.loginData.password).then(function (response) {
                    if (response != null && response.data.error != undefined) {
                        notificationService.displayError("Đăng nhập không đúng");
                    } else {
                        var stateService = $injector.get('$state');
                        stateService.go('home');
                    }

                }).catch(function (err, status) {
                    notificationService.displayError("Lỗi");
                });
            }

        }
    ]);
    

})(angular.module('onlineshop'));