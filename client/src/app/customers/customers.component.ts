import { Component, OnInit } from '@angular/core';
import { Customer } from '../_models/customer';
import { CustomerService } from '../_services/customer.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { CreateCustomerModalComponent } from '../modals/create-customer-modal/create-customer-modal.component';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {
  customers: Customer[];
  bsModalRef!: BsModalRef;

  constructor(private customerService: CustomerService, private modalService: BsModalService) {
    this.customers = [];
  }

  ngOnInit(): void {
    this.loadCustomers();
  }

  loadCustomers() {
    this.customerService.getCustomers().subscribe((customers: Customer[]) => { this.customers = customers; });
  }

  createCustomerModal() {
    const config = {
      class: 'modal-dialog-centered',
      initialState: {
        customerValues: {firstName: '', lastName: '', address: '', phone: ''}
      }
    };
    this.bsModalRef = this.modalService.show(CreateCustomerModalComponent, config);
    this.bsModalRef.content.customerInfo.subscribe((customer: Customer) => {
      if (customer) {
        this.customerService.updateCustomer(customer).subscribe(response => {
          this.loadCustomers();
        }, error => {
          console.log(error);
        });
      }
    });
  }

}
