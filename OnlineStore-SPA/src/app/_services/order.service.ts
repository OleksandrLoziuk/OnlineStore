import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { AlertifyService } from './alertify.service';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

baseUrl = environment.apiUrl + 'order/';

constructor(private http: HttpClient, private alertify: AlertifyService) { }

add(model: any) {
  return this.http.post(this.baseUrl + 'add', model);
}
delete(id) {
  return this.http.post(this.baseUrl + 'delete', id);
}
}
