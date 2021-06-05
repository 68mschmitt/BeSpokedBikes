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

  getSales() {
    return this.http.get<Sale[]>(this.baseUrl + 'sales');
  }
}
