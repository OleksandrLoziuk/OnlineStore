import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { AlertifyService } from './alertify.service';
import { Observable } from 'rxjs';
import { Category } from '../_models/Category';
import { catchError } from 'rxjs/operators';
import { Photocategory } from '../_models/Photocategory';
import { Config } from 'protractor';


@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  baseUrl = environment.apiUrl;
  configUrl: any ={};

constructor(private http: HttpClient, private alertify: AlertifyService) { }

getCategories(): Observable<Category[]> {
  return this.http.get<Category[]>(this.baseUrl + 'categoriesadmin');
}
getCategory(id): Observable<Category> {
  return this.http.get<Category>(this.baseUrl + 'categoriesadmin/' + id);
}

add(model: any) {
  return this.http.post(this.baseUrl + 'categoriesadmin/add', model);
}

edit(id: number, model: Category)  {
  return this.http.put(this.baseUrl + 'categoriesadmin/' + id + '/edit' , model);
}

deleteCategory(id): Observable<Category> {
  return this.http.delete<Category>(this.baseUrl + 'categoriesadmin/' + id);
}

}
