import { Component, OnInit } from '@angular/core';
import { Product } from '../_models/Product';
import { StringsOrderService } from '../_services/stringsOrder.service';
import { StringsOrder } from '../_models/StringsOrder';
import { Router } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { OrderService } from '../_services/order.service';

@Component({
  selector: 'app-shop-cart',
  templateUrl: './shop-cart.component.html',
  styleUrls: ['./shop-cart.component.css']
})
export class ShopCartComponent implements OnInit  {
  products: Product[]=[];
  strOrd: StringsOrder[] = [];
  s: StringsOrder;
  currentsum = 0;
  constructor(private stringsOrderService: StringsOrderService, private router: Router, private alertify: AlertifyService) { }

  ngOnInit() {
    this.products = this.stringsOrderService.getProducts();
    this.sum();
  }
  onQuanChange(){
    this.currentsum = 0;
    this.sum();
  }
  cancel() {
    this.router.navigate(['/categories']);
  }
  toOrder() {
    for(let i = 0; i< this.products.length; i++) {
        this.s = { 
          ProductId: this.products[i].id,
          Quantity: this.products[i].minQuantity,
          Amount: this.products[i].minQuantity * this.products[i].cost
        };
        this.strOrd.push(this.s);
    }
    this.add();
  }
  sum() {
    for(let i = 0; i < this.products.length; i++) {
      this.currentsum += (this.products[i].minQuantity*this.products[i].cost);
    }
 }
  add() {
    this.stringsOrderService.add(this.strOrd).subscribe();
  }
  isOrder() {
    if (this.products.length === 0) {
      return true;
    } else {
     return false;
    }
  }
  del(prodId: number){
    let index: number;
    for(let i = 0; i < this.products.length; i++) {
      
      if(this.products[i].id === prodId){
          index = i;
      }
    }
    this.stringsOrderService.deleteProd(index);
    this.products = this.stringsOrderService.getProducts();
    this.currentsum=0;
    this.sum();
  }



}
