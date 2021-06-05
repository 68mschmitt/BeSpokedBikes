import { Component, OnInit } from '@angular/core';
import { Sale } from '../_models/sale';
import { SalesService } from '../_services/sales.service';

@Component({
  selector: 'app-sales',
  templateUrl: './sales.component.html',
  styleUrls: ['./sales.component.css']
})
export class SalesComponent implements OnInit {
  sales: Sale[];

  constructor(private salesService: SalesService) {
    this.sales = [];
  }

  ngOnInit(): void {
    this.loadSales();
  }

  loadSales() {
    this.salesService.getSales().subscribe((sales: Sale[]) => { this.sales = sales; console.log(sales); });
  }

}
