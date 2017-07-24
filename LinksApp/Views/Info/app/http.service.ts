import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Link } from './link';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class HttpService {

    constructor(private http: Http) { }

    getLinks(): Observable<Link[]> {
        return this.http.get('/LinksApp/Info/Get/')
            .map((resp: Response) => {

                let linksList = resp.json();
                let links: Link[] = [];
                debugger
                for (let index in linksList) {
                    let link = linksList[index];
                    links.push({
                        Id: link.Id,
                        CreateDate: link.CreateDate,
                        OriginLink: link.OriginLink,
                        ShortLink: link.ShortLink,
                        RedirectCount: link.RedirectCount                        
                    });
                }
                return links;
            });
    }
}