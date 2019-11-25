import { Photo } from './Photo';

export interface Product {
    id: number;
    productName: string;
    categoryName?: string;
    cost?: number;
    colorName?: string;
    minQuantity?: number;
    description?: string;
    balance?: number;
    isAvailable?: boolean;
    photos?: Photo[];
}
