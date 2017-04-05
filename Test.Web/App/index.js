var app = angular.module('app', ['ngComponentRouter']);

app.config(['$locationProvider', function ($locationProvider) {
        console.log('Confirguration');
        $locationProvider.hashPrefix('');
}]);

app.value('$routerRootComponent', 'app')

app.component('app', {
    template: '<ng-outlet></ng-outlet>',
    $routeConfig: [
        { path: '/', name: 'Root', component: 'root', useAsDefault: true },
        { path: '/blog', name: 'Blog', component: 'blog'}
    ]
});
