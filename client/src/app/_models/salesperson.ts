export interface SalesPerson {
    id: number;
    firstName: string;
    lastName: string;
    address: string;
    phone: string;
    startDate?: string;
    terminationDate?: Date;
    manager: string;
}