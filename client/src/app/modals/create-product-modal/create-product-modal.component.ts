import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Product } from 'src/app/_models/product';

@Component({
  selector: 'app-create-product-modal',
  templateUrl: './create-product-modal.component.html',
  styleUrls: ['./create-product-modal.component.css']
})
export class CreateProductModalComponent implements OnInit {
  productForm!: FormGroup;
  productValues!: Product;
  @Output() productInfo = new EventEmitter<Product>();

  constructor(
      public bsModalRef: BsModalRef,
      private fb: FormBuilder) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.productForm = this.fb.group({
      name: [this.productValues.name, Validators.required],
      manufacturer: [this.productValues.manufacturer, Validators.required],
      style: [this.productValues.style, Validators.required],
      purchasePrice: [(this.productValues.purchasePrice == 0) ? '' : this.productValues.purchasePrice, Validators.required],
      salePrice: [(this.productValues.salePrice == 0) ? '' : this.productValues.salePrice, Validators.required],
      quantityOnHand: [(this.productValues.quantityOnHand == 0) ? '' : this.productValues.quantityOnHand, Validators.required],
      commissionPercentage: [(this.productValues.commissionPercentage == 0) ? '' : this.productValues.commissionPercentage, Validators.required]
    });
  }

  updateProductInfo() {
    if (this.productForm.valid) {
      this.productInfo.emit(this.productForm.value);
      this.bsModalRef.hide();
    }
  }

}
