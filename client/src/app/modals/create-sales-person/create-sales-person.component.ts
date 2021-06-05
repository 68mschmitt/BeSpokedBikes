import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { SalesPerson } from 'src/app/_models/salesperson';

@Component({
  selector: 'app-create-sales-person',
  templateUrl: './create-sales-person.component.html',
  styleUrls: ['./create-sales-person.component.css']
})
export class CreateSalesPersonComponent implements OnInit {
  salesPersonForm!: FormGroup;
  salesPersonValues!: SalesPerson;
  @Output() salesPersonOutput = new EventEmitter<SalesPerson>();

  constructor(
    public bsModalRef: BsModalRef,
    private fb: FormBuilder) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.salesPersonForm = this.fb.group({
      firstName: [this.salesPersonValues.firstName, Validators.required],
      lastName: [this.salesPersonValues.lastName, Validators.required],
      address: [this.salesPersonValues.address, Validators.required],
      phone: [this.salesPersonValues.phone, Validators.required],
      manager: [this.salesPersonValues.manager, Validators.required]
    });
  }

  createSalesPerson() {
    if (this.salesPersonForm.valid) {
      this.salesPersonOutput.emit(this.salesPersonForm.value);
      this.bsModalRef.hide();
    }
  }

}
