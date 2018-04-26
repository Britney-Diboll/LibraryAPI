angular.
    module("LibraryApp", [])
    .controller("mainController", ["$scope", "$http", ($scope, $http) => {

        

        const searchTitle = () => {
            let titleUrl = "/api/search"
            if ($scope.inputTitle) {
                titleUrl += "?title=" + $scope.inputTitle
            }
            $http({
                method: "GET",
                url: titleUrl
            }).then(resp => {
                $scope.books = resp.data;
            })
        }
        $scope.searchT = () => {
            searchTitle();
        }

        /* $http({
            method: "GET",
            url: "/api/book"
        }).then(resp => {
            console.log(resp.data);
            $scope.books = resp.data;
            })*/
            
        var init = () => {
            $scope.welcomeMessage = "Slience in the Library"
            searchTitle();
        }
        init();
}]);