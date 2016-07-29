'use strict';
(function () {
    var app = angular.module("App.Controllers");
 app.controller("users", ['$scope', '$modal', 'usersService', 'utils', function ($scope, $modal, usersService, utils) {
        var service = usersService.list;
        $scope.search = function (isPage) {
             $scope.loadingState = true;
             if (!isPage) $scope.current = 1;
             service.get({ current: $scope.current, size: $scope.size }).success(function (response) {
                    $scope.list = response.Data;
                    $scope.total = response.Total;
                    $scope.loadingState = false;
             });
         };
        $scope.remove = function (item) {
            var model = utils.confirm({ msg: "Confirm Delete " + item.Name + "?", ok: "OK", cancel: "Cancel" });
            model.result.then(function () {
                service.delete(item.Id).success(function (data) {
                    if (data.IsDeleted) {
                        utils.notify(item.Name + " delete success！", "success");
                        utils.remove($scope.list, item);
                    }
                });
            });
        };
        $scope.assignRoles = function (item) {
            $scope.model = item;
            var modal = $modal.open({
                templateUrl: '/App/views/users/chooseRoles.html',
                backdrop: "static",
                controller: "chooseRoles",
                size: "lg",
                resolve: {
                    params: function () {
                        return $scope.model;
                    }
                }
            });
            modal.result.then(function () {
                usersService.user.updateRoles($scope.model).success(function (data) {
                    if (data.IsSaved) {
                        utils.notify("Assign roles success！", "success");
                    }
                })
            })
        };
        $scope.size = 12;
        $scope.search();
    }])
    .controller("usersForm", ['$scope', '$location', '$routeParams', 'usersService', 'utils', function ($scope, $location, $routeParams, usersService, utils) {
        var service = usersService.user;
        var isModified = !!$routeParams.id;
        if (isModified) {
            service.get({ id: $routeParams.id, size: 100 }).success(function (data) {
                $scope.model = data.Data;
            });
            $scope.title = "Update User";
        } else {
            $scope.title = "Create User";
        }
        $scope.save = function () {
            var model = $scope.model;
            if (!$.trim(model.Name) || !$.trim(model.RealName) || !$.trim(model.Email)) return;
            if (model.Id > 0) {
                service.update(model).success(function (response) {
                    if (response.IsSaved) {
                        utils.notify("User update success！", "success");
                        $scope.goToIndex();
                    }
                });
            } else {
                service.create(model).success(function (response) {
                      if (response.IsCreated) {
                          utils.notify("User create success！", "success");
                          $scope.goToIndex();
                      }
                 });
            }
        };
        $scope.goToIndex = function () {
            setTimeout(function () {
                $location.path("/users/list");
                $scope.$apply();
            }, 2000);
        };
        
    }])
    .controller("chooseRoles", ['$scope', '$modalInstance', 'utils', 'rolesService', 'params', function ($scope, $modalInstance, utils, rolesService, params) {
        var service = rolesService.list;
        var org = angular.copy(params.Roles || []);
        $scope.search= function () {
            $scope.current = 1;
            service.gets({ current: $scope.current, size: $scope.size }).success(function (data) {
                angular.forEach(data.Data, function(l) {
                    angular.forEach(org, function(v) {
                        if (l.Id == v.Id) {
                            l.isChecked = true;
                        }
                    });
                });
                $scope.roles = data.Data;
                $scope.total = data.Total;
            });
        };
        $scope.save = function () {
            params.Roles = org;
            $modalInstance.close(true);
        };
        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
        $scope.checked = function (item) {
            item.isChecked = !item.isChecked;
            if (!item.isChecked) {
                utils.remove(org, item, function (i, v) {
                    return i.Id == v.Id;
                });
            } else {
                org.push(item);
            }
        };
        $scope.size = 10;
        $scope.search();
    }]);

})()