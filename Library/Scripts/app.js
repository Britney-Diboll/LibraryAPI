angular.
    module("LibraryApp", [])
    .controller("mainController", ["$scope", "$http", ($scope, $http) => {

        $http({
            method: "GET",
            url: "/api/book"
        }).then(resp => {
            console.log(resp.data);
            $scope.books = resp.data;
        })
}]);