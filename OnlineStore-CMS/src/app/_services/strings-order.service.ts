import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { StringsOrder } from '../_models/StringsOrder';

@Injectable({
  providedIn: 'root'
})
export class StringsOrderService {
baseUrl = environment.apiUrl;
constructor(private http: HttpClient) { }
getStringsOrder(id): Observable<StringsOrder[]> {
  return this.http.get<StringsOrder[]>(this.baseUrl + 'orderadmin/' + id + '/stringsorderadmin');
}
deleteStrsOrd(ordid, id): Observable<StringsOrder> {
  return this.http.delete<StringsOrder>(this.baseUrl + 'orderadmin/' + ordid + '/stringsorderadmin/' + id);
}
}
