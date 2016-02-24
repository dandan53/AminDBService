app.controller('MainCtrl', function ($scope, $location, $routeParams) {
    // $scope.Data = Data;
    
    $scope.toList = function () {
        $location.url('/list');
    };
    
    $scope.addPerson = function () {
        $location.url('/newperson');
    };
    
});
