import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Color } from '../_models/Color';

@Injectable({
  providedIn: 'root'
})
export class ColorService {

baseUrl = environment.apiUrl;

constructor(private httpClient: HttpClient) { }

getColors(): Observable<Color[]> {
  return this.httpClient.get<Color[]>(this.baseUrl + 'colors');
}

getColor(id): Observable<Color> {
  return this.httpClient.get<Color>(this.baseUrl + 'colors/' + id);
}

addColor(model: any) {
  return this.httpClient.post(this.baseUrl + 'colors/', model);
}

deleteColor(id: number ) {
  return this.httpClient.delete(this.baseUrl + 'colors/' + id);
}

}
