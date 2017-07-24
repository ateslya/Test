import { Component } from '@angular/core';
import { HttpService } from './http.service';
import { Link } from './link';

@Component({
    selector: 'info-links',
    templateUrl: '/LinksApp/Views/Info/app/app.component.html',
    providers: [HttpService]
})

export class AppComponent {

    links: Link[] = [];

    constructor(private httpService: HttpService)
    { }

    ngOnInit() {
        this.httpService.getLinks()
            .subscribe((data) => this.links = data);
    }
}