import { Route } from '@angular/compiler/src/core';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FileUploader } from 'ng2-file-upload';
import { environment } from 'src/environments/environment';
import { Category } from '../_models/Category';
import { Color } from '../_models/Color';
import { Photo } from '../_models/Photo';
import { Product } from '../_models/Product';
import { AlertifyService } from '../_services/alertify.service';
import { ColorService } from '../_services/color.service';
import { ProductsService } from '../_services/products.service';

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
  photos: Photo[];
  currentMainPhoto: Photo;
  constructor(private route: ActivatedRoute, private router: Router, private colorsService: ColorService, private productsService: ProductsService,
    private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadProduct();
    this.loadCategories();
    this.loadColors();
    this.initializeUploader();
    this.photos = this.product.photos;
    
  }
  mainPhoto() {
    for(let i = 0; i < this.photos.length; i++) {
      if(this.photos[i].isMain === true) {
        return this.photos[i];
      }
    }
  }
  editProduct() {
    this.productsService.edit(this.product.id, this.product).subscribe(() => {
      this.alertify.success('Продукт изменён');
      this.editForm.reset(this.product);
    }, error => {
      this.alertify.error(error);
    })
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

  setMainPhoto (photo: Photo) {
    this.productsService.setMainPhoto(this.product.id, photo.id).subscribe(() => {
      this.currentMainPhoto = this.photos.filter(p => p.isMain === true)[0];
      this.currentMainPhoto.isMain = false;
      photo.isMain = true;
      this.alertify.success('Главное фото измененно');
    }, error => {
      this.alertify.error(error);
    });
  }

  deletePhoto(id: number) {
    this.productsService.deletePhoto(this.product.id, id).subscribe(() => {
      this.photos.splice(this.photos.findIndex(p => p.id === id), 1);
      this.alertify.success('Фото удалено');
    }, error => {
      this.alertify.error(error);
    });
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
        const res: Photo = JSON.parse(response);
        const photo = {
          id: res.id,
          url: res.url,
          isMain: res.isMain
        };
        this.photos.push(photo);
      }
    }
  }

  fileOverBase(e: any): void {
    this.hasBaseDropZoneOver = e;
  }

}
