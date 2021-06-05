import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { CreateSaleModalComponent } from '../modals/create-sale-modal/create-sale-modal.component';
import { Product } from '../_models/product';
import { Sale } from '../_models/sale';
import { ProductsService } from '../_services/products.service';
import { SalesService } from '../_services/sales.service';

@Component({
  selector: 'app-sales',
  templateUrl: './sales.component.html',
  styleUrls: ['./sales.component.css']
})
export class SalesComponent implements OnInit {
  sales: Sale[];
  bsModalRef!: BsModalRef;

  constructor(
      private salesService: SalesService, 
      private modalService: BsModalService) {
    this.sales = [];
  }

  ngOnInit(): void {
    this.loadSales();
  }

  loadSales() {
    this.salesService.getSales().subscribe((sales: Sale[]) => { this.sales = sales; });
  }

  createSale() {
    this.bsModalRef = this.modalService.show(CreateSaleModalComponent);
    this.bsModalRef.content.saleOutput.subscribe((sale: Sale) => {
      if (sale) {
        this.salesService.createSale(sale).subscribe(response => {
          this.loadSales();
        }, error => {
          console.log(error);
        });
      }
    });
  }

}
