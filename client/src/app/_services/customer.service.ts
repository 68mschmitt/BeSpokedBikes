import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from '../_models/customer';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getCustomers() {
    return this.http.get<Customer[]>(this.baseUrl + 'customers');
  }

  updateCustomer(customer: Customer) {
    return this.http.post(this.baseUrl + 'Customers/create-customer', customer);
  }
}
