import { Component, Input, OnInit } from '@angular/core';
import { OrderDetail } from '../_models/OrderDetail';
import { StringsOrder } from '../_models/StringsOrder';
import { AlertifyService } from '../_services/alertify.service';
import { StringsOrderService } from '../_services/strings-order.service';

@Component({
  selector: 'app-stringsorder',
  templateUrl: './stringsorder.component.html',
  styleUrls: ['./stringsorder.component.css']
})
export class StringsorderComponent implements OnInit {

  @Input() stringsOrder: OrderDetail;
  sringsOrders: StringsOrder[]; 
  constructor(private stringOrserService: StringsOrderService, private alertify:AlertifyService) { }

  ngOnInit() {
    this.loadSrtord();
  }
  loadSrtord() {
    this.stringOrserService.getStringsOrder(this.stringsOrder.id).subscribe((data: StringsOrder[]) => {
      this.sringsOrders = data;
    }, error => {
      this.alertify.error(error);
    })
  }

  deleteStrOrd(ordId, id) {
    this.stringOrserService.deleteStrsOrd(ordId, id).subscribe(()=>{
      this.sringsOrders.splice(this.sringsOrders.findIndex(p => p.id === id), 1);
      this.alertify.success('Продукт удалён');
    }, error => {
      this.alertify.error(error);
    })

  }

}
