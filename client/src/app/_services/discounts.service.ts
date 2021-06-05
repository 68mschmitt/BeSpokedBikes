import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Discount } from '../_models/discount';

@Injectable({
  providedIn: 'root'
})
export class DiscountsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {
  }

  getDiscounts() {
    return this.http.get<Discount[]>(this.baseUrl + 'discounts');
  }
}
