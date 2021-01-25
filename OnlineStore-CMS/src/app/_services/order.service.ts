import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Order } from 'src/app/_models/Order';
import { OrderDetail } from '../_models/OrderDetail';
@Injectable({
  providedIn: 'root'
})
export class OrderService {

baseUrl = environment.apiUrl;

constructor(private http: HttpClient) { }
  
  getOrders(): Observable<Order[]> {
  return this.http.get<Order[]>(this.baseUrl + 'orderadmin');
}

getOrder(id): Observable<Order> {
  return this.http.get<Order>(this.baseUrl + 'orderadmin/' + id);
}

editOrder(id: number, model: OrderDetail)  {
  return this.http.put(this.baseUrl + 'orderadmin/' + id, model);
}
}
