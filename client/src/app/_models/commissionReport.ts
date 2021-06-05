import { SalesPerson } from "./salesperson";

export interface CommissionReport {
    salesPeople: CommissionSalesPerson[];
    startDate: Date;
    endDate: Date;
}

export interface CommissionSalesPerson {
    id: number;
    fullName: string;
    commission: number;
}