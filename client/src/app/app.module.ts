import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NavComponent } from './nav/nav.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CustomersComponent } from './customers/customers.component';
import { ProductsComponent } from './products/products.component';
import { SalesComponent } from './sales/sales.component';
import { SalespeopleComponent } from './salespeople/salespeople.component';
import { DiscountsComponent } from './discounts/discounts.component';
import { ReportsComponent } from './reports/reports.component';
import { HttpClientModule } from '@angular/common/http';
import { CreateCustomerModalComponent } from './modals/create-customer-modal/create-customer-modal.component';
import { CreateProductModalComponent } from './modals/create-product-modal/create-product-modal.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TextInputComponent } from './_forms/text-input/text-input.component'
import { ReactiveFormsModule } from '@angular/forms';
import { DateInputComponent } from './_forms/date-input/date-input.component';
import { BsDatepickerModule, BsLocaleService } from 'ngx-bootstrap/datepicker';
import { CreateSaleModalComponent } from './modals/create-sale-modal/create-sale-modal.component';
import { CreateSalesPersonComponent } from './modals/create-sales-person/create-sales-person.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavComponent,
    CustomersComponent,
    ProductsComponent,
    SalesComponent,
    SalespeopleComponent,
    DiscountsComponent,
    ReportsComponent,
    CreateCustomerModalComponent,
    CreateProductModalComponent,
    TextInputComponent,
    DateInputComponent,
    CreateSaleModalComponent,
    CreateSalesPersonComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    ModalModule.forRoot(),
    ReactiveFormsModule,
    BsDatepickerModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
