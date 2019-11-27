import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { AlertifyService } from './alertify.service';
import { Observable } from 'rxjs';
import { Product } from '../_models/Product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient, private alertify: AlertifyService) { }
  
  getCategories(): Observable<Product[]> {
    return this.http.get<Product[]>(this.baseUrl + 'products');
  }
  
  getCategory(id): Observable<Product> {
    return this.http.get<Product>(this.baseUrl + 'products/' + id);
  }

}
