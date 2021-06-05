import { Component, OnInit } from '@angular/core';
import { Discount } from '../_models/discount';
import { DiscountsService } from '../_services/discounts.service';

@Component({
  selector: 'app-discounts',
  templateUrl: './discounts.component.html',
  styleUrls: ['./discounts.component.css']
})
export class DiscountsComponent implements OnInit {
  discounts: Discount[];

  constructor(private discountsService: DiscountsService) {
    this.discounts = [];
  }

  ngOnInit(): void {
    this.loadDiscounts();
  }

  loadDiscounts() {
    this.discountsService.getDiscounts().subscribe((discounts: Discount[]) => { this.discounts = discounts; });
  }

}
