import { Component, OnInit } from '@angular/core';
import { CommissionReport } from '../_models/commissionReport';
import { ReportsService } from '../_services/reports.service';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css']
})
export class ReportsComponent implements OnInit {
  commissionReport!: CommissionReport;

  constructor(private reportsService: ReportsService) {
  }

  ngOnInit(): void {
    this.loadCommissionReport();
  }

  loadCommissionReport() {
    this.reportsService.getCommissionReport().subscribe((commissionReport: CommissionReport) => { this.commissionReport = commissionReport; });
  }

}
