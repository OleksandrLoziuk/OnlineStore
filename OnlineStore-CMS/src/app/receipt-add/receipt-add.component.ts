import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EventEmitter } from 'events';
import { Category } from '../_models/Category';
import { Product } from '../_models/Product';
import { Receipt } from '../_models/Receipt';
import { AlertifyService } from '../_services/alertify.service';
import { ReceiptService } from '../_services/receipt.service';

@Component({
  selector: 'app-receipt-add',
  templateUrl: './receipt-add.component.html',
  styleUrls: ['./receipt-add.component.css']
})
export class ReceiptAddComponent implements OnInit {
  categories: Category[];
  products: Product[];
  model: any = {};
  req: any = {};
  prodToRet: Product[];
  constructor(private alertify: AlertifyService, private route: ActivatedRoute,private router: Router, private receiptService: ReceiptService) { }

  ngOnInit() {
    this.loadCategories();
    this.loadProducts();
  }

  loadCategories() {
    this.route.data.subscribe(data => {
      this.categories = data['categories'];
    });
  }
  loadProducts() {
    this.route.data.subscribe(data => {
      this.products = data['products'];
    });
  }

  back() {
    this.router.navigate(['/receiptadmin']);
  }



  addReceipt() {
     this.receiptService.add(this.model).subscribe((data: Receipt) => {
       this.alertify.success('Операция успешна');
       this.req = data;
       this.router.navigate(['/receiptadmin']);
     }, error => {
       this.alertify.error(error);
     })
  }

}
