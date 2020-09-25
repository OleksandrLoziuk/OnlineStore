import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Product } from '../_models/Product';
import { Category } from '../_models/Category';
import { CategoriesService } from '../_services/categories.service';
import { AlertifyService } from '../_services/alertify.service';
import { Color } from '../_models/Color';
import { ColorService } from '../_services/color.service';
import { ProductsService } from '../_services/products.service';
import { FileUploader } from 'ng2-file-upload';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.scss']
})
export class ProductAddComponent implements OnInit {
  req: Product = null;
  product: any = {};
  categories: Category [];
  colors: Color[];
  model: any = {};
  uploader: FileUploader;
  hasBaseDropZoneOver = false;
  isNameAdded: boolean = false;
  baseUrl = environment.apiUrl;
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
     this.productService.add(this.product).subscribe((data: Product) => {
       this.alertify.success('Продукт добавлен');
       this.req = data;
       this.isNameAdded = true;
       this.initializeUploader();
     }, error => {
       this.alertify.error(error);
     })
  }

  back() {
    this.router.navigate(['/productsadmin']);
  }

  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + 'productsadmin/' + this.req.id + '/photo',
      authToken: 'Bearer ' + localStorage.getItem('token'),
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10*1024*1024
    });
    this.uploader.onAfterAddingFile = (file) => {file.withCredentials = false; };

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if(response) {
        this.router.navigate(['/productsadmin']);
      }
    }
  }

  fileOverBase(e: any): void {
    this.hasBaseDropZoneOver = e;
  }

}
