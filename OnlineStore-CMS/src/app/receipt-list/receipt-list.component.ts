import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Receipt } from '../_models/Receipt';
import { AlertifyService } from '../_services/alertify.service';
import { ReceiptService } from '../_services/receipt.service';

@Component({
  selector: 'app-receipt-list',
  templateUrl: './receipt-list.component.html',
  styleUrls: ['./receipt-list.component.css']
})
export class ReceiptListComponent implements OnInit {
  receipts: Receipt[];
  constructor(private receiptService: ReceiptService, private route: ActivatedRoute, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadReceipts();
  }
  loadReceipts() {
    this.route.data.subscribe(data => {
      this.receipts = data['receipts'];
    });
  }
  deleteReceipt(rec: Receipt) {
    this.receiptService.deleteProduct(rec.id).subscribe(()=>{
      this.receipts.splice(this.receipts.findIndex(c => c.id === rec.id), 1);
      this.alertify.success('Приход удален');
    })
  }

}
