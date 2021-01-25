import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Order } from '../_models/Order';
import { OrderDetail } from '../_models/OrderDetail';
import { AlertifyService } from '../_services/alertify.service';
import { OrderService } from '../_services/order.service';

@Component({
  selector: 'app-order-edit',
  templateUrl: './order-edit.component.html',
  styleUrls: ['./order-edit.component.scss']
})
export class OrderEditComponent implements OnInit {
  orderDetail: OrderDetail;
  status = new Array('Новый','Принят','Выполнен','Отменён')
  constructor(private orderService: OrderService, private route: ActivatedRoute, private alertify: AlertifyService, private router: Router) { }
  strOrd = false;
  ngOnInit() {
    this.route.data.subscribe(data => {
      this.orderDetail = data['orderDetail'];
    });
  }

  back() {
    this.router.navigate(['/orderadmin']);
  }

  stringOrderShow() {
    this.strOrd = !this.strOrd;
  }

}
