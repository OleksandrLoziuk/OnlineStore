import { Injectable } from '@angular/core';
import { Category } from '../_models/category';
import { Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { CategoriesService } from '../_services/categories.service';

@Injectable()

export class CategoriesListResolver implements Resolve<Category[]> {
  constructor(private categoriesService: CategoriesService, private router: Router,
               private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Category[]> {
        return this.categoriesService.getCategories().pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving data');
                this.router.navigate(['/categoriesadmin']);
                return of(null);
            })
        );
    }

}