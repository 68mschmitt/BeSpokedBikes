import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Product } from '../_models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {
  }

  getProducts() {
    return this.http.get<Product[]>(this.baseUrl + 'products');
  }

  createProduct(product: Product) {
    return this.http.post(this.baseUrl + 'Products/create-product', product);
  }

  updateProduct(product: Product) {
    return this.http.post(this.baseUrl + 'Products/update-product', product);
  }
}
