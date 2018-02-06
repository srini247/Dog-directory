(function () {
    'use strict';

        app.controller('homecontroller', homecontroller);

        homecontroller.$inject = ['$location', 'dataservice'];

        function homecontroller($location, dataservice) {
            var vm = this;
            vm.title = 'homecontroller';
            vm.selectedbreedimg = "";
            vm.breeds = [];
            vm.loadimage = loadimage;
            vm.loadallbreeds = loadallbreeds;           
            

            function loadimage() {
                
                if (vm.selectedbreed != null) {
                    dataservice.getrandomimage(vm.selectedbreed)
                          .then(function (response) {
                              vm.selectedbreedimg = response.data.image;
                          }, function (error) {
                              vm.selectedbreedimg = '';
                              console.log("Load Image failed.")
                          });
                }
                else { vm.selectedbreedimg = ''; }
       }

       function loadallbreeds() {
           dataservice.getAllbreeds()
                 .then(function (response) {
                     vm.breeds = response.data.breeds;
                 }, function (error) {
                     console.log("Load List of breeds failed.")
                 });
       }

       activate();

       function activate() {
           vm.loadallbreeds();          
       }
       
    }
})();
