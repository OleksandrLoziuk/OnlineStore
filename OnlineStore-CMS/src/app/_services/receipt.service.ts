import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Product } from '../_models/Product';
import { Receipt } from '../_models/Receipt';

@Injectable({
  providedIn: 'root'
})
export class ReceiptService {

  baseUrl = environment.apiUrl;

constructor(private http: HttpClient) { }

getReceipts(): Observable<Receipt[]> {
  return this.http.get<Receipt[]>(this.baseUrl + 'receiptadmin');
}
getReceipt(id): Observable<Receipt> {
  return this.http.get<Receipt>(this.baseUrl + 'receiptadmin/' + id);
}
add(model: any) {
  return this.http.post(this.baseUrl + 'receiptadmin/add', model);
}

edit(id: number, model: Receipt)  {
  return this.http.put(this.baseUrl + 'receiptadmin/' + id + '/edit' , model);
}

deleteProduct(id): Observable<Receipt> {
  return this.http.delete<Receipt>(this.baseUrl + 'receiptadmin/' + id);
}

}
