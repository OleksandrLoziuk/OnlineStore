import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Product } from '../_models/Product';
import { Category } from '../_models/Category';
import { CategoriesService } from '../_services/categories.service';
import { AlertifyService } from '../_services/alertify.service';
import { Color } from '../_models/Color';
import { ColorService } from '../_services/color.service';
import { ProductsService } from '../_services/products.service';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.scss']
})
export class ProductAddComponent implements OnInit {

  product: any = {};
  categories: Category [];
  colors: Color[];
  isAddColors: boolean = false;
  model: any = {};
  iconClass: string =  'fa-plus';
  btnClass: string = 'btn-success';
  constructor(private router: Router, private categoriesService: CategoriesService, private alertify: AlertifyService, private route: ActivatedRoute, 
    private colorService: ColorService, private productService: ProductsService) { }

  ngOnInit() {   
    this.loadCategories();
    this.loadColors();
  }
  
  loadCategories() {
    this.route.data.subscribe(data => {
      this.categories = data['categories'];
    });
  }

  loadColors() {
    this.route.data.subscribe(data => {
      this.colors = data['colors'];
    })
  }

  addProduct() {
     this.productService.add(this.product).subscribe(() => {
       this.alertify.success('Продукт добавлен');
     }, error => {
       this.alertify.error(error);
     })
  }

  addColor() {
    this.colorService.addColor(this.model).subscribe((data:Color) => {
        this.alertify.success("Цвет добавлен");
        this.isAddColors = false;
        this.colors.push(data);
    }, error => {
      this.alertify.error(error);
    });
  }

  back() {
    this.router.navigate(['/productsadmin']);
  }
  addColorForm() {
    this.isAddColors = !this.isAddColors;
    if(this.isAddColors===false) {
      this.iconClass =  'fa-plus';
      this.btnClass = 'btn-success';
    } else {
      this.iconClass =  'fa-ban';
      this.btnClass = 'btn-danger';
    }
  }

}
