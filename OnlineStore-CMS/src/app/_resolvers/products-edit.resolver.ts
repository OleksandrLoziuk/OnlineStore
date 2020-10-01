import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Product } from '../_models/Product';
import { ProductsService } from '../_services/products.service';

@Injectable()

export class ProductsEditResolver implements Resolve<Product> {
  constructor(private productsService: ProductsService, private router: Router,
               private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Product> {
        return this.productsService.getProduct(route.params['id']).pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving data');
                this.router.navigate(['/productsadmin']);
                return of(null);
            })
        );
    }

}