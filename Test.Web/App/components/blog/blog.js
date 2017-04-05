(function () {
    'use strict';

    app.component('blog', {
        templateUrl: '/App/components/blog/blog.html',
        controller: blogController,
    });

    blogController.$inject = [];
    function blogController() {
        var $ctrl = this;

        console.log('blog Component');
        ////////////////

        $ctrl.$onInit = function () {
            console.log('Blog Init');
        };
        $ctrl.$onChanges = function (changesObj) { };
        $ctrl.$onDestroy = function () { };
        $ctrl.$doCheck = function () { };
    }

})();