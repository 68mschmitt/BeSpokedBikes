import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Customer } from 'src/app/_models/customer';

@Component({
  selector: 'app-create-customer-modal',
  templateUrl: './create-customer-modal.component.html',
  styleUrls: ['./create-customer-modal.component.css']
})
export class CreateCustomerModalComponent implements OnInit {
  registerForm!: FormGroup;
  customerValues: any;
  @Output() customerInfo = new EventEmitter<Customer>();

  constructor(
      public bsModalRef: BsModalRef,
      private fb: FormBuilder) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.registerForm = this.fb.group({
      firstName: [this.customerValues.firstName, Validators.required],
      lastName: [this.customerValues.lastName, Validators.required],
      address: [this.customerValues.address, Validators.required],
      phone: [this.customerValues.phone, Validators.required]
    });
  }

  updateCustomerInfo() {
    if (this.registerForm.valid) {
      this.customerInfo.emit(this.registerForm.value);
      this.bsModalRef.hide();
    }
  }

}
