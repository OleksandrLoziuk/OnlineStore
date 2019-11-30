import { Component, OnInit, Input } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { Product } from '../_models/Product';
import { ActivatedRoute } from '@angular/router';
import { CategoryService } from '../_services/category.service';


@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  product: Product;
  icon: string;
  isAvText: string;
  textColor: string;

  constructor(private route: ActivatedRoute, private categoryService: CategoryService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadProduct();
  }
  loadProduct() {
   this.categoryService.getProduct(+this.route.snapshot.params['catid'], +this.route.snapshot.params['prodid'])
   .subscribe((product: Product) => { this.product = product; },
   error => {
        this.alertify.error(error);
   });
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

}
