import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../_services/category.service';
import { ProductService } from '../_services/product.service';
import { AlertifyService } from '../_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../_models/Product';

@Component({
  selector: 'app-category-detail',
  templateUrl: './category-detail.component.html',
  styleUrls: ['./category-detail.component.css']
})
export class CategoryDetailComponent implements OnInit{

  products: Product[];

  constructor(private categoryService: CategoryService,
    private alertify: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.loadProductsByCategory();
  }
  ngDoCheck() {
    this.loadProductsByCategory();
  }

  loadProductsByCategory() {
    this.categoryService.getCategory(+this.route.snapshot.params['id']).subscribe((products: Product[]) =>{
      this.products = products;
    }, error => {
      this.alertify.error(error);
    })
  }

}
