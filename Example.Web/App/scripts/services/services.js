'use strict';
(function () {
var service = angular.module("App.Services", [])
    .factory("http", ['$http', '$modal', 'utils', function ($http,$modal, utils) {
        var methods = {
            'call': function (type, url, params, data) {
                return $http({ method: type, url: url, params: params, data: data })
                    .success(methods.success)
                    .error(methods.errorModal);
            },
            'success': function (data) {
                if (data.Message)
                    utils.confirm({ msg: data.Message, ok: "ok" });
                return data;
            },
            'errorModal': function (data) {
                $modal.open({
                    templateUrl: '/App/views/utils/errorModal.html',
                    backdrop: "static",
                    controller: "errorModal",
                    resolve: {
                        error: function () {
                            return data;
                        }
                    }
                });
            },
            'get': function (url, params) {
                return methods.call('GET', url, params);
            },
            'post': function (url, data) {
                return methods.call('POST', url, null, data);
            }
        };
        return methods;
    }])
    .factory("utils", ["$http", '$modal', function ($http, $modal) {
        var methods = {
            confirm: function(text) {
                return $modal.open({
                    templateUrl: '/App/views/utils/confirmModal.html',
                    backdrop: "static",
                    controller: "confirmmModal",
                    resolve: {
                        items: function() {
                            return text;
                        }
                    }
                });
            },
            notify: function(content, type) {
                $.notify(content, {
                    type: type, delay: 1000, z_index: 1000000, placement: { from: 'top', align: 'right' }, offset: { x:20,y: 80 },
                });
            },
            remove: function(list, item, fn) {
                angular.forEach(list, function(i, v) {
                    if (fn ? (fn(i, item)) : (i.$$hashKey === item.$$hashKey)) {
                        list.splice(v, 1);
                        return false;
                    }
                    return true;
                });
            }
        };
        return methods;
    }])
    .factory("usersService", ["http", function (http) {
        var methods = {
            list: {
                "get": function (params) {
                    return http.get("/api/user/GetUsers", params);
                },
                "delete": function (id) {
                    return http.post("/api/user/DeleteUser/" + id);
                }
            },
            user: {
                "get": function (param) {
                    return http.get("/api/user/UserInfo", param);
                },
                "update": function (param) {
                    return http.post("/api/user/UpdateUser", param);
                },
                "create": function (param) {
                    return http.post("/api/user/AddUser", param);
                },
                "updateRoles": function (params) {
                    return http.post("/api/user/UpdateRoles", params);
                },
                "deleteRole": function (id, roleId) {
                    return http.post("/api/user/DeleteRole/" + id + "/" + roleId);
                }
            }
        };
        return methods;
    }])
    .factory("rolesService", ["http", function (http) {
        var methods = {
            list: {
                "gets": function (param) {
                    return http.get("/api/role/GetRoles", param);
                },
                "get": function (param) {
                    return http.get("/api/role/RoleInfo", param);
                },
                "create": function (param) {
                    return http.post("/api/role/AddRole", param);
                },
                "update": function (param) {
                    return http.post("/api/role/UpdateRole", param);
                },
                "delete": function (id) {
                    return http.post("/api/role/DeleteRole/" + id);
                }
            }
        }
        
        return methods;
    }]);


service.controller("confirmmModal", ['$scope', '$modalInstance', 'items', function ($scope, $modalInstance, items) {
    var methods = {
        ok: function () {
            $modalInstance.close(true);
        },
        cancel: function () {
            $modalInstance.dismiss('cancel');
        },
        text: items
    };
    $.extend($scope, methods);
}]);

service.controller("errorModal", ['$scope', '$modalInstance', 'error', function ($scope, $modalInstance, error) {
    var methods = {
        cancel: function () {
            $modalInstance.dismiss('cancel');
        },
        report: function () {
            $modalInstance.close(true);
        }
    };
    angular.extend($scope, methods, error);
    }]);

})()