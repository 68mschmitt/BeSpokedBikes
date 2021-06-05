import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { CreateProductModalComponent } from '../modals/create-product-modal/create-product-modal.component';
import { Product } from '../_models/product';
import { ProductsService } from '../_services/products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  products: Product[];
  bsModalRef!: BsModalRef;

  constructor(private productService: ProductsService, private modalService: BsModalService) {
    this.products = [];
  }

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts() {
    this.productService.getProducts().subscribe((products: Product[]) => { this.products = products; });
  }

  showProductModal() {
    const config = {
      class: 'modal-dialog-centered',
      initialState: {
        productValues: {
          id: 0,
          name: '',
          manufacturer: '',
          style: '',
          purchasePrice: 0,
          salePrice: 0,
          quantityOnHand: 0,
          commissionPercentage: 0
        }
      }
    }
    this.modalFunction(config);
  }

  updateProductModal(product: Product) {
    const config = {
      class: 'modal-dialog-centered',
      initialState: {
        productValues: {
          id: product.id,
          name: product.name,
          manufacturer: product.manufacturer,
          style: product.style,
          purchasePrice: product.purchasePrice,
          salePrice: product.salePrice,
          quantityOnHand: product.quantityOnHand,
          commissionPercentage: product.commissionPercentage
        }
      }
    }
    this.modalFunction(config);
  }

  modalFunction(config: any) {
    this.bsModalRef = this.modalService.show(CreateProductModalComponent, config);
    this.bsModalRef.content.productInfo.subscribe((product: Product) => {
      if (product)
      {
        if (product.id == 0) {
          this.productService.createProduct(product).subscribe(response => {
            this.loadProducts();
          }, error => {
            console.log(error);
          });
        } else {
          this.productService.updateProduct(product).subscribe(response => {
            this.loadProducts();
          }, error => {
            console.log(error);
          });
        }
      }
    });
  }

}
