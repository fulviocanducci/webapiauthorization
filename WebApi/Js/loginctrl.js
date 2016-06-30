app.controller('LoginCtrl', ["$scope", "$authorization", "$http", "$url",
    function ($scope, $authorization, $http, $url) {

        $scope.username = "";
        $scope.password = "";

        $scope.loggin = function (username, password) {

            var data = { username: username, password: password, grant_type: "password" }
            $http({
                method: "POST",
                url: $url.path + "token",
                data: data,
                headers: { "Content-Type": "application/x-www-form-urlencoded" },
                transformRequest: function (obj) {
                    return $scope.tranform(obj);
                }
            })
                .success(function successCallback(response) {
                    $authorization.save(response.access_token);
                    $authorization.init();
                })
                .error(function errorCallback(response) {
                    if (response.error === "invalid_grant") {
                        alert("Usuário e senhas inválidos");
                    }
                });
        }
        $scope.tranform = function (obj) {
            var str = [];
            for (var p in obj) {
                if (obj.hasOwnProperty(p)) {
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                }
            }
            return str.join("&");
        }

    }]);