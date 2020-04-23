import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { StringsOrderService } from '../_services/stringsOrder.service';
import { OrderService } from '../_services/order.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {
 
  model: any = {};
  deliveries = [
    {name: 'Новая почта'},
    {name: 'Интайм'},
    {name: 'Деливери'},
    {name: 'Гюнсел'}
  ];
  payments = [
    {name: 'Наложенный платёж'},
    {name: 'На банковскую карту'},
    {name: 'Расчётный счёт'}
  ];
  constructor( private router: Router, private strOrd: StringsOrderService, private orderService: OrderService, private alertify: AlertifyService) { }

  ngOnInit() {
  }
  addOrder(){
    this.strOrd.clearProducts();
    this.orderService.add(this.model).subscribe(() => {
      this.alertify.success('Заказ оформлен');
      this.router.navigate(['/end']);
    }, error => {
      this.alertify.error(error);
    });
  }
  deleteOrder() {
    this.orderService.delete(0).subscribe(() => {
      this.alertify.warning('Заказ отменён');
    }, error => {
      this.alertify.error(error);
    });
  }
  cancel(){
    this.strOrd.clearProducts();
    this.deleteOrder();
    this.router.navigate(['/categories']);
  }
  ChangeValueDelivery($event){
   this.model.DeliveryMethod = $event.target.value;
  }
  ChangeValuePayment($event) {
    this.model.PaymentMethod = $event.target.value;
  }
}
