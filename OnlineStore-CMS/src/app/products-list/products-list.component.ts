import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../_services/products.service';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Product } from '../_models/Product';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {

products: Product[];

  constructor(private productService: ProductsService, private route: ActivatedRoute, private alertify: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.products = data['products'];
    });
  }
  deleteProduct(prod: Product){
    this.productService.deleteProduct(prod.id).subscribe(() => {
      this.products.splice(this.products.findIndex(p => p.id === prod.id), 1);
      this.alertify.success('Продукт удалён');
    }, error => {
      this.alertify.error(error);
    })
  }

}
