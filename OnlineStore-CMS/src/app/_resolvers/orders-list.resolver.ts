import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { OrderService } from '../_services/order.service';
import { Order } from '../_models/Order';


@Injectable()

export class OrdersListResolver implements Resolve<Order[]> {
  constructor(private orderService: OrderService, private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Order[]> {
        return this.orderService.getOrders().pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving data');
                return of(null);
            })
        );
    }

}