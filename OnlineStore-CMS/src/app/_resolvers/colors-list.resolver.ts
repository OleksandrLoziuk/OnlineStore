import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Color } from '../_models/Color';
import { ColorService } from '../_services/color.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core';

@Injectable()

export class ColorsListReolver implements Resolve<Color[]> {
    
    constructor(private colorService: ColorService, private router: Router, private alertify: AlertifyService) {}
    resolve(route: ActivatedRouteSnapshot): Observable<Color[]> {
        return this.colorService.getColors().pipe(
            catchError( error => {
                this.alertify.error('Problem retrieving data');
                return of(null);
            })
        );    
    }
    
}