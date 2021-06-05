import { Customer } from "./customer";
import { Product } from "./product";
import { SalesPerson } from "./salesperson";

export interface Sale {
    productId: number;
    product?: Product;
    salesPersonId: number;
    salesPerson?: SalesPerson;
    customerId: number;
    customer?: Customer;
    saleDate?: string;
}