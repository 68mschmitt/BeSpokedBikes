import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { CreateSalesPersonComponent } from '../modals/create-sales-person/create-sales-person.component';
import { SalesPerson } from '../_models/salesperson';
import { SalespeopleService } from '../_services/salespeople.service';

@Component({
  selector: 'app-salespeople',
  templateUrl: './salespeople.component.html',
  styleUrls: ['./salespeople.component.css']
})
export class SalespeopleComponent implements OnInit {
  salesPeople: SalesPerson[];
  bsModalRef!: BsModalRef;

  constructor(private salesPeopleService: SalespeopleService, private modalService: BsModalService) {
    this.salesPeople = [];
  }

  ngOnInit(): void {
    this.loadSalesPeople();
  }

  loadSalesPeople() {
    this.salesPeopleService.getSalesPeople().subscribe((salesPeople: SalesPerson[]) => { this.salesPeople = salesPeople; });
  }

  openModal() {
    const config = {
      class: 'modal-dialog-centered',
      initialState: {
        salesPersonValues: {
          id: 0,
          firstName: '',
          lastName: '',
          address: '',
          phone: '',
          manager: ''
        }
      }
    }
    this.modalFunction(config);
  }

  updateSalesPerson(salesPerson: SalesPerson) {
    const config = {
      class: 'modal-dialog-centered',
      initialState: {
        salesPersonValues: {
          id: salesPerson.id,
          firstName: salesPerson.firstName,
          lastName: salesPerson.lastName,
          address: salesPerson.address,
          phone: salesPerson.phone,
          terminationDate: salesPerson.terminationDate,
          manager: salesPerson.manager
        }
      }
    }
    this.modalFunction(config);
  }

  modalFunction(config: any) {
    this.bsModalRef = this.modalService.show(CreateSalesPersonComponent, config);
    this.bsModalRef.content.salesPersonOutput.subscribe((salesPerson: SalesPerson) => {
      if (salesPerson)
      {
        if (salesPerson.id == 0){
          this.salesPeopleService.createSalesPerson(salesPerson).subscribe(response => {
            this.loadSalesPeople();
          }, error => {
            console.log(error);
          });
        } else {
          this.salesPeopleService.updateSalesPerson(salesPerson).subscribe(response => {
            this.loadSalesPeople();
          }, error => {
            console.log(error);
          });
        }
      }
    });
  }

}
