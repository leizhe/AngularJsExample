'use strict';
(function () {
    var app = angular.module("App.Filters", [])
        .filter("merge", function () {
        return function (ls, key, n, omit) {
            var a = [];
            angular.forEach(ls, function (v, i) {
                if (n && n <= i) return false;
                a.push(v[key]);
            })
            if (n && ls.length > n)
                return a.join(',') + (omit || '');
            return a.join(',');
        }
        })
        .filter("none", function () {
        return function (obj, content) {
            if (obj == null || obj == '') {
                return content;
            }
            return obj;
        }
        })
        .filter("state", function () {
        return function (obj) {
            switch (obj) {
                case 0:
                    return "Enable";
                case 1:
                    return "Disable";
                default:
                    return "Others";
            }
        }
    })
})();