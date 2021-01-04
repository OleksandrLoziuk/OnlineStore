import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Order } from 'src/app/_models/Order';
@Injectable({
  providedIn: 'root'
})
export class OrderService {

baseUrl = environment.apiUrl;

constructor(private http: HttpClient) { }
  
  getOrders(): Observable<Order[]> {
  return this.http.get<Order[]>(this.baseUrl + 'orderadmin');
}

deleteOrder(id): Observable<Order> {
  return this.http.delete<Order>(this.baseUrl + 'orderadmin/' + id);
}

}
