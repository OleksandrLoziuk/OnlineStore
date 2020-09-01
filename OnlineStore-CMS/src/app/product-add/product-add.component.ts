import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Product } from '../_models/Product';
import { Category } from '../_models/Category';
import { CategoriesService } from '../_services/categories.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.scss']
})
export class ProductAddComponent implements OnInit {

  product: any = {};
  //product: Product;
  categories: Category [];

  constructor(private router: Router, private categoriesService: CategoriesService, private alertify: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.categories = data['categories'];
    });
    //this.loadCategories();
  }
  loadCategories() {
    this.categoriesService.getCategories().subscribe((categories: Category[])=>{
      this.categories = categories;
    }, error => {
      this.alertify.error(error);
    });
  }

  addProduct() {

  }

  back() {
    this.router.navigate(['/productsadmin']);
  }

}
