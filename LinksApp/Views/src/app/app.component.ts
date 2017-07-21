import { Component } from '@angular/core';

@Component({
    selector: 'my-app',
    templateUrl: 'LinksApp/Views/src/app/app.component.html'
})

export class AppComponent {
    URL = '';

    constructor() { this.log(`constructor`); }

    ngOnInit() { this.log(`onInit`); }

    ngOnDestroy() { this.log(`onDestroy`); }

    private log(msg: string) {
        console.log(msg);
    }

    zipURL(URL: string) {
        console.log(URL);
        //this.phones.push(new Phone(title, price, company));
    }
}