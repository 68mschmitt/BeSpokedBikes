import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomersComponent } from './customers/customers.component';
import { DiscountsComponent } from './discounts/discounts.component';
import { HomeComponent } from './home/home.component';
import { ProductsComponent } from './products/products.component';
import { ReportsComponent } from './reports/reports.component';
import { SalesComponent } from './sales/sales.component';
import { SalespeopleComponent } from './salespeople/salespeople.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'customers', component: CustomersComponent},
  {path: 'products', component: ProductsComponent},
  {path: 'sales', component: SalesComponent},
  {path: 'salespeople', component: SalespeopleComponent},
  {path: 'discounts', component: DiscountsComponent},
  {path: 'reports', component: ReportsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
