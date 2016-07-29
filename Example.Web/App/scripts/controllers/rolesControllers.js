'use strict';
(function () {
    var app = angular.module("App.Controllers");
app.controller("roles", ['$scope', 'rolesService', 'utils', function ($scope, rolesService, utils) {
        var service = rolesService.list;
        $scope.search = function (isPage) {
            $scope.loadingState = true;
            if (!isPage) $scope.current = 1;
            service.gets({ current: $scope.current, size: $scope.size }).success(function (response) {
                $scope.list = response.Data;
                $scope.total = response.Total;
                $scope.loadingState = false;
            });
        };
        $scope.remove = function (item) {
            var model = utils.confirm({ msg: "Confirm Delete " + item.RoleName + "?", ok: "OK", cancel: "Cancel" });
            model.result.then(function () {
                service.delete(item.Id).success(function (data) {
                    if (data.IsDeleted) {
                        utils.notify(item.RoleName + " delete success！", "success");
                        utils.remove($scope.list, item);
                    }
                });
            });
        };
        $scope.size = 10;
        $scope.search();
    }])
   .controller("rolesForm", ['$scope', '$location', '$routeParams', 'rolesService', 'utils', function ($scope, $location, $routeParams, rolesService, utils) {
        var service = rolesService.list;
        var isModified = !!$routeParams.id;
        if (isModified) {
            service.get({ id: $routeParams.id, size: 100 }).success(function (data) {
                $scope.model = data.Data;
            });
            $scope.title = "Update Role";
        } else {
            $scope.title = "Create Role";
        }
        $scope.save = function () {
            var model = $scope.model;
            if (!$.trim(model.RoleName)) return;
            if (model.Id > 0) {
                service.update(model).success(function (response) {
                    if (response.IsSaved) {
                        utils.notify("Role update success！", "success");
                        $scope.goToIndex();
                    }
                });
            } else {
                service.create(model).success(function (response) {
                      if (response.IsCreated) {
                          utils.notify("Role create success！", "success");
                          $scope.goToIndex();
                      }
                 });
            }
        };
        $scope.goToIndex = function () {
            setTimeout(function () {
                $location.path("/roles/list");
                $scope.$apply();
            }, 2000);
        }
    }]);

})()