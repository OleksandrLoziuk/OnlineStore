import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Order } from '../_models/Order';
import { AlertifyService } from '../_services/alertify.service';
import { OrderService } from '../_services/order.service';

@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html',
  styleUrls: ['./orders-list.component.css']
})
export class OrdersListComponent implements OnInit {
   orders: Order[];
  constructor(private route: ActivatedRoute, private alertify: AlertifyService, private orderService : OrderService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.orders = data['orders'];
    });
  }
  
}
