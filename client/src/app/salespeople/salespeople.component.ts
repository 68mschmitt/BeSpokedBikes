import { Component, OnInit } from '@angular/core';
import { SalesPerson } from '../_models/salesperson';
import { SalespeopleService } from '../_services/salespeople.service';

@Component({
  selector: 'app-salespeople',
  templateUrl: './salespeople.component.html',
  styleUrls: ['./salespeople.component.css']
})
export class SalespeopleComponent implements OnInit {
  salesPeople: SalesPerson[];

  constructor(private salesPeopleService: SalespeopleService) {
    this.salesPeople = [];
  }

  ngOnInit(): void {
    this.loadSalesPeople();
  }

  loadSalesPeople() {
    this.salesPeopleService.getSalesPeople().subscribe((salesPeople: SalesPerson[]) => { this.salesPeople = salesPeople; });
  }

}
