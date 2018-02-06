(function () {
    'use strict';

    app.service('dataservice', dataservice);

    dataservice.$inject = ['$http'];

    function dataservice($http) {
        var urlBase = "api/DogDirectory/";

        var service = {
            getAllbreeds: getAllbreeds,
            getrandomimage: getrandomimage
        };

        return service;

       
        function getAllbreeds() {
            return $http({
                method: 'GET',
                url: urlBase + "getallbreeds",
                headers: { "Content-Type": "application/json" }
            })

        };
        function getrandomimage(breed) {
            return $http({
                method: 'GET',
                url: urlBase + "getrandomimage",
                params: { Breed: breed },
                headers: { "Content-Type": "application/json" }
            })

        };

    }
})();