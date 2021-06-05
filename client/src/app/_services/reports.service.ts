import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CommissionReport } from '../_models/commissionReport';

@Injectable({
  providedIn: 'root'
})
export class ReportsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getCommissionReport(date?: string) {
    return this.http.get<CommissionReport>(this.baseUrl + ((date != null) ? 'Reports?date=' + date : 'Reports'));
  }
}
