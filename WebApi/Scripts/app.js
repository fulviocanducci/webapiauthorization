var app = angular.module("app", ["ngRoute"]);

app.constant("$url", { "path": "http://localhost:54651/" });

app.factory("$authorization",
    function($http, $location) {
        var save = function(token) {
            $http.defaults.headers.common["Authorization"] = token;
            $http.defaults.headers.common["Content-Type"] = "application/json";
        }
        var logged = function() {
            return !(undefined === $http.defaults.headers.common["Authorization"]);
        }

        var init = function() {
            if (this.logged() === false) {
                $location.path("/login");
            }
        }

        return {
            init: init,
            save: save,
            logged: logged
        };

    });

app.config(function ($routeProvider /*, $locationProvider*/) {
    
    //$locationProvider.html5Mode(true);

    $routeProvider
        .when("/",
        {
            templateUrl: "/Html/index.html",
            controller: "IndexCtrl"
        })
        .when("/login",
        {
            templateUrl: "/Html/login.html",
            controller: "LoginCtrl"
        });

    /*.otherwise({ redirectTo: '/' });*/
});

//controllers
app.controller("ctrl", ["$scope", "$authorization",
    function ($scope, $authorization) {
        $authorization.init();
        $scope.name = "fulvio";
        
    }]);

app.controller("IndexCtrl", ["$scope", "$authorization",
    function ($scope, $authorization) {
        $authorization.init();
        $scope.items = [
            { Id: 1, Description: "Nome 1" },
            { Id: 2, Description: "Nome 2" }
        ];
        
    }]);

app.controller('LoginCtrl', ["$scope", "$authorization", "$http", "$url",
    function ($scope, $authorization, $http, $url) {

        $scope.loggin = function () {
            var name = "fulvio";
            var password = "abcdef";
            var data = { username: name, password: password, grant_type: "password" }

            $http({
                    method: "POST",
                    url: $url.path + "token",
                    data: data,
                    headers: {"Content-Type": "application/x-www-form-urlencoded"},
                    transformRequest: function(obj) {
                        return $scope.tranform(obj);
                    }
                })
                .success(function successCallback(response) {
                    console.log(response);
                })
                .error(function errorCallback(response) {
                    console.log("Error:");
                    console.log(response);
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

app.run(["$authorization", "$location", function ($authorization) { $authorization.init(); }]);