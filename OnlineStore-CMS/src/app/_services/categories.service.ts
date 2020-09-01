import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../_models/Category';



@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  baseUrl = environment.apiUrl;
  configUrl: any ={};

constructor(private http: HttpClient) { }

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
