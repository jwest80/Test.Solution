(function () {
    'use strict';

    app.component('root', {
        templateUrl: '/App/components/root/root.html',
        controller: rootController,
    });

    rootController.$inject = [];
    function rootController() {
        var $ctrl = this;

        console.log('Root Component');
        ////////////////

        $ctrl.$onInit = function () {
            console.log('Root Init');
        };
        $ctrl.$onChanges = function (changesObj) { };
        $ctrl.$onDestroy = function () { };
        $ctrl.$doCheck = function () { };
    }

})();