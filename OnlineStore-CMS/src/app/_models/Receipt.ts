import { Product } from "./Product";

export interface Receipt {
    id: number;
    productName: string;
    productCost: number
    quantity: number;
    sum: number;
    dateAdded: string;
}