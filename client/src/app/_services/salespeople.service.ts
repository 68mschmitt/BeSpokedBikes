import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { SalesPerson } from '../_models/salesperson';

@Injectable({
  providedIn: 'root'
})
export class SalespeopleService {
  baseUrl = environment.apiUrl;
  salesPeople: SalesPerson[];

  constructor(private http: HttpClient) {
    this.salesPeople = [];
  }

  getSalesPeople() {
    return this.http.get<SalesPerson[]>(this.baseUrl + 'SalesPeople');
  }
}
