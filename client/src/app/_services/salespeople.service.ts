import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { SalesPerson } from '../_models/salesperson';

@Injectable({
  providedIn: 'root'
})
export class SalespeopleService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {
  }

  getSalesPeople() {
    return this.http.get<SalesPerson[]>(this.baseUrl + 'SalesPeople');
  }

  createSalesPerson(salesPerson: SalesPerson) {
    return this.http.post(this.baseUrl + 'SalesPeople/create-sales-person', salesPerson);
  }

  updateSalesPerson(salesPerson: SalesPerson) {
    return this.http.post(this.baseUrl + 'SalesPeople/update-sales-person', salesPerson);
  }
}
