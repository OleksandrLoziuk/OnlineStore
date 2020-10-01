import { Route } from '@angular/compiler/src/core';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FileUploader } from 'ng2-file-upload';
import { environment } from 'src/environments/environment';
import { Category } from '../_models/Category';
import { Color } from '../_models/Color';
import { Product } from '../_models/Product';
import { ColorService } from '../_services/color.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {
  @ViewChild('editFrom', {static: false}) editForm: NgForm;
  product: Product;
  categories: Category[];
  colors: Color[];
  uploader: FileUploader;
  hasBaseDropZoneOver = false;
  baseUrl = environment.apiUrl;
  constructor(private route: ActivatedRoute, private router: Router, private colorsService: ColorService) { }

  ngOnInit() {
    this.loadProduct();
    this.loadCategories();
    this.loadColors();
  }
  editProduct() {

  }

  loadProduct() {
    this.route.data.subscribe(data => {
      this.product = data['product'];
    });
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
  back() {
    this.router.navigate(['/productsadmin']);
  }

  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + 'productsadmin/' + this.product.id + '/photo',
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
