import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Sale } from '../_models/sale';

@Injectable({
  providedIn: 'root'
})
export class SalesService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {
  }

  getSales(query?: string) {
    if (query != '' || query != null) return this.http.get<Sale[]>(this.baseUrl + 'sales?FilterBy=' + query);
    return this.http.get<Sale[]>(this.baseUrl + 'sales');
  }

  createSale(sale: Sale) {
    return this.http.post(this.baseUrl + 'Sales', sale);
  }
}
