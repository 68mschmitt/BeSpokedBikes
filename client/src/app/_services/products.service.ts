import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Product } from '../_models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  baseUrl = environment.apiUrl;
  products: Product[];

  constructor(private http: HttpClient) {
    this.products = [];
  }

  getProducts() {
    return this.http.get<Product[]>(this.baseUrl + 'products');
  }
}
