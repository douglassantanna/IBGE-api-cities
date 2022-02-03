import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ICities } from '../interface/icities';

const url = `${environment.urlApi}/municipios`;

@Injectable({
  providedIn: 'root',
})
export class CityService {
  constructor(private http: HttpClient) {}

  get():Observable<ICities[]> {
    return this.http.get<ICities[]>(url);
  }
  populateDatabase(city: ICities): Observable<ICities>{
    return this.http.post<ICities>(url, city);
  }
  delete(id: ICities): Observable<any> {
    return this.http.delete(`${url}/${id}`);
  }
}
