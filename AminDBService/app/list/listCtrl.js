app.controller('ListCtrl', function ($scope, $location, $routeParams, personService) {

    ////TEMP
    //var p1 = {display:"שלום רן בן ריטה"};
    //var p2 = {display: " שמרית דויב בת רחלי רן" };
    //var p3 = { display: "שלום רן בן שלווה" };
    //var p4 = { display: "ברוך משה בן בלה" };
    
    //$scope.persons = [p1, p2, p3, p4];

    
    $scope.selectedPerson = "";
    
    $scope.search = function () {
        $location.url('/');
    };

    $scope.getPersonList = function () {
        personService.getPersons()
                .then(
                    loadData,
                    function (errorMessage) {
                        console.warn(errorMessage);
                    }
                );
            };

    function loadData(data) {
        $scope.persons = data;
    }

    
    $scope.getPersonList();

});