app.controller("IndexCtrl", ["$scope", "$authorization", "$http", "$cookies",
    function ($scope, $authorization, $http) {

        $authorization.init();
        $http.defaults.headers.common["Authorization"] = $authorization.token();
        
        $scope.description = "";

        $scope.items = [
            { Id: 1, Description: "Nome 1" },
            { Id: 2, Description: "Nome 2" }
        ];

        $scope.load = function() {
            $http({
                    method: "GET",
                    url: "/api/v1/credits",
                    headers: {
                        "Cache-Control" : "no-cache"
                    },
                    cache:false
                })
                .success(function successCallback(response) {
                    $scope.items = response;
                });
        }

        $scope.add = function(description) {
            $http({
                    method: "POST",
                    url: "/api/v1/credits",
                    data: { Id: 0, Description: description }
                })
                .success(function successCallback(response) {
                    $scope.description = "";
                    description = "";
                    $scope.items.push(response);
                });
        }

        $scope.edit = function (index, id,description) {
            $http({
                    method: "PUT",
                    url: "/api/v1/credits/" + id,
                    data: { Id: id, Description: description }
                })
                .success(function successCallback(response) {
                    $scope.description = "";
                    description = "";
                    id = "";
                    $scope.items[index] = response;
                });
        }

        $scope.delete = function (index, id) {
            $http({
                method: "DELETE",
                url: "/api/v1/credits/" + id,
                data: { Id: id }
            })
                .success(function successCallback(response) {
                    $scope.description = "";
                    id = "";
                    if (response.deleted) {
                        $scope.items.splice(index, 1);
                    }
                });
        }

        $scope.load();

    }]);