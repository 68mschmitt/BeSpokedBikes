import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { SalesComponent } from 'src/app/sales/sales.component';
import { Customer } from 'src/app/_models/customer';
import { Product } from 'src/app/_models/product';
import { Sale } from 'src/app/_models/sale';
import { SalesPerson } from 'src/app/_models/salesperson';
import { CustomerService } from 'src/app/_services/customer.service';
import { ProductsService } from 'src/app/_services/products.service';
import { SalespeopleService } from 'src/app/_services/salespeople.service';

@Component({
  selector: 'app-create-sale-modal',
  templateUrl: './create-sale-modal.component.html',
  styleUrls: ['./create-sale-modal.component.css']
})
export class CreateSaleModalComponent implements OnInit {
  saleForm!: FormGroup;
  saleValues!: Sale;
  products!: Product[];
  salesPeople!: SalesPerson[];
  customers!: Customer[];
  salesPersonLabel = 'Sales People';
  productLabel = 'Products';
  customerLabel = 'Customers';
  @Output() saleOutput = new EventEmitter<Sale>();

  constructor(
    public bsModalRef: BsModalRef,
    private fb: FormBuilder,
    private productService: ProductsService,
    private salesPersonService: SalespeopleService,
    private customerService: CustomerService) {
    this.saleValues = {
      productId: 0,
      customerId: 0,
      salesPersonId: 0
    };
  }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.productService.getProducts().subscribe((products: Product[]) => {
      this.products = products;
    });
    this.salesPersonService.getSalesPeople().subscribe((salesPeople: SalesPerson[]) => {
      this.salesPeople = salesPeople;
    });
    this.customerService.getCustomers().subscribe((customers: Customer[]) => {
      this.customers = customers;
    });
  }

  createSale() {
    console.log(this.saleValues);
    if (this.saleValues.productId != 0 &&
      this.saleValues.customerId != 0 &&
      this.saleValues.salesPersonId != 0) 
    {
      console.log(this.saleValues);
      this.saleOutput.emit(this.saleValues);
      this.bsModalRef.hide();
    }
  }

  selectProduct(productId: number, newLabel: any) {
    this.saleValues.productId = productId;
    this.productLabel = newLabel;
  }
  selectCustomer(customerId: number, newLabel: string) {
    this.saleValues.customerId = customerId;
    this.customerLabel = newLabel;
  }
  selectSalesPerson(salesPersonId: number, newLabel: string) {
    this.saleValues.salesPersonId = salesPersonId;
    this.salesPersonLabel = newLabel;
  }

}
