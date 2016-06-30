app.controller("ctrl", ["$scope", "$authorization",
    function ($scope, $authorization) {
        $scope.logout = function () {
            $authorization.logout();
        }
        $authorization.init();
    }]);