import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Product } from '../_models/Product';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

baseUrl = environment.apiUrl;

constructor(private http: HttpClient) { }

getProducts(): Observable<Product[]> {
  return this.http.get<Product[]>(this.baseUrl + 'productsadmin');
}
getProduct(id): Observable<Product> {
  return this.http.get<Product>(this.baseUrl + 'productsadmin/' + id);
}

add(model: any) {
  return this.http.post(this.baseUrl + 'productsadmin/add', model);
}

edit(id: number, model: Product)  {
  return this.http.put(this.baseUrl + 'productsadmin/' + id + '/edit' , model);
}

deleteProduct(id): Observable<Product> {
  return this.http.delete<Product>(this.baseUrl + 'productsadmin/' + id);
}

}
