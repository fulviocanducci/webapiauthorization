app.factory("$authorization",
    function ($http, $location, $cookies) {
        var save = function (token) {
            $cookies.put("Authorization", token);
        }
        var logged = function () {
            return !(undefined === $cookies.get("Authorization"));
        }

        var init = function () {
            if (this.logged() === false) {
                $location.path("/login");
            } else {
                $location.path("/");
            }
        }

        var logout = function () {
            $cookies.remove("Authorization");
            $location.path("/login");
        }

        var token = function() {
            return "bearer " + $cookies.get("Authorization");
        }

        return {
            init: init,
            save: save,
            logged: logged,
            logout: logout,
            token: token
        };

    });