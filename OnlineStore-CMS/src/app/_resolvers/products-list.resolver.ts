import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Product } from '../_models/Product';
import { ProductsService } from '../_services/products.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';


@Injectable()

export class ProductsListResolver implements Resolve<Product[]> {
  constructor(private productsService: ProductsService, private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Product[]> {
        return this.productsService.getProducts().pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving data');
                this.router.navigate(['/productadmin']);
                return of(null);
            })
        );
    }

}