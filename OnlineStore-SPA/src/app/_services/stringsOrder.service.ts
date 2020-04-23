import { Injectable } from '@angular/core';
import { Product } from '../_models/Product';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { AlertifyService } from './alertify.service';

@Injectable({
  providedIn: 'root'
})
export class StringsOrderService {
baseUrl = environment.apiUrl + 'cart/';
products: Product[] = [];

constructor(private http: HttpClient, private alertify: AlertifyService) { }

addProduct(product: Product) {
  this.products.push(product);
  this.alertify.success('Товар добавлен в корзину');
}
deleteProd (i: number){
      this.products.splice(i, 1);
}

getProducts() {
  for(let i = 0; i < this.products.length; i++) {

    for(let j =this.products.length-1; j> i; j--) {
      if(this.products[i].id === this.products[j].id) {
        this.products[i].minQuantity+=this.products[j].minQuantity;
        this.deleteProd(j);
        break;
      }
    }
  }
  return this.products;
}

clearProducts() {
  this.products = [];
}

add(model: any[]) {
  return this.http.post(this.baseUrl + 'add', model);
}
}
