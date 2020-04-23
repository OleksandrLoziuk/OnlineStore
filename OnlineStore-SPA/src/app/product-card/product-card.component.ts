import { Component, OnInit, Input } from '@angular/core';
import { Product } from '../_models/Product';
import { StringsOrderService } from '../_services/stringsOrder.service';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.css']
})
export class ProductCardComponent implements OnInit {
  @Input() product: Product;
  icon: string;
  isAvText: string;
  textColor: string;
  constructor(private stringsOrederService: StringsOrderService) { }

  ngOnInit() {
  }
  isAv() {
    if (this.product.isAvailable) {
      this.icon = 'check';
      this.isAvText = 'В наличии';
      this.textColor = 'text-success';
      return true;
    } else {
       this.icon = 'times';
       this.isAvText = 'Нет в наличии';
       this.textColor = 'text-danger';
       return true;
    }
 }
 isPay() {
  if (this.product.isAvailable) {
    return false;
  } else {
   return true;
  }
 }
 toCart(){
   this.stringsOrederService.addProduct(this.product);
 }
}
