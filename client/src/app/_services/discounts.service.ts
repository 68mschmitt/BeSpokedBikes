import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Discount } from '../_models/discount';

@Injectable({
  providedIn: 'root'
})
export class DiscountsService {
  baseUrl = environment.apiUrl;
  discounts: Discount[];

  constructor(private http: HttpClient) {
    this.discounts = [];
  }

  getDiscounts() {
    return this.http.get<Discount[]>(this.baseUrl + 'discounts');
  }
}
