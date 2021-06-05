import { DatePipe } from '@angular/common';
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
    const datepipe: DatePipe = new DatePipe('en-US');
    let termDate = this.salesPersonValues.terminationDate? datepipe.transform(this.salesPersonValues.terminationDate, 'dd MMMM YYYY'): '';
    this.salesPersonForm = this.fb.group({
      id: this.salesPersonValues.id,
      firstName: [this.salesPersonValues.firstName, Validators.required],
      lastName: [this.salesPersonValues.lastName, Validators.required],
      address: [this.salesPersonValues.address, Validators.required],
      phone: [this.salesPersonValues.phone, Validators.required],
      terminationDate: termDate,
      manager: [this.salesPersonValues.manager, Validators.required]
    });
  }

  createSalesPerson() {
    if (this.salesPersonForm.valid) {
      if (this.salesPersonForm.value.terminationDate != ''){
        const datepipe: DatePipe = new DatePipe('en-US');
        this.salesPersonForm.value.terminationDate = datepipe.transform(this.salesPersonForm.value.terminationDate, 'YYYY-MM-dd') + 'T00:00:00Z';
        console.log(this.salesPersonForm.value.terminationDate);
      }
      this.salesPersonOutput.emit(this.salesPersonForm.value);
      this.bsModalRef.hide();
    }
  }

}
