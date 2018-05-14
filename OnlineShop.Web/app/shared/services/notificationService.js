/// <reference path="D:\Project\OnlineShop\Source\OnlineShop.Web\Assets/admin/libs/toastr/toastr.js" />
/// <reference path="D:\Project\OnlineShop\Source\OnlineShop.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.factory('notificationService', notificationService);
    function notificationService() {
        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };
        function displaySuccess(message) {
            toastr.success(message);

        };
        function displayError(error) {
            if (Array.isArray(error)) {
                error.each(function (err) {
                    toastr.error(err);
                });
            } else {
                toastr.error(error);
            }

        };
        function displayWarning(message) {
            toastr.warning(message);
        };
        function displayInfor(message) {
            toastr.info(message);
        }
        return {
            displaySuccess: displaySuccess,
            displayError: displayError,
            displayWarning: displayWarning,
            displayInfor: displayInfor
        }
    }

})(angular.module('onlineshop.common'));