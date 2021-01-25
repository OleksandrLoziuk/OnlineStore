import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, Router } from "@angular/router";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { OrderDetail } from "../_models/OrderDetail";
import { AlertifyService } from "../_services/alertify.service";
import { OrderService } from "../_services/order.service";

@Injectable()

export class OrderDetailResolver implements Resolve<OrderDetail> {
  constructor(private orderService: OrderService, private router: Router,
               private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<OrderDetail> {
        return this.orderService.getOrder(route.params['id']).pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving data');
                this.router.navigate(['/orderadmin']);
                return of(null);
            })
        );
    }

}