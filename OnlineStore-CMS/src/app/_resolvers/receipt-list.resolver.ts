import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Receipt } from '../_models/Receipt';
import { ReceiptService } from '../_services/receipt.service';


@Injectable()

export class ReceiptListResolver implements Resolve<Receipt[]> {
  constructor(private receiptService: ReceiptService, private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Receipt[]> {
        return this.receiptService.getReceipts().pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving data');
                this.router.navigate(['/receiptadmin']);
                return of(null);
            })
        );
    }

}