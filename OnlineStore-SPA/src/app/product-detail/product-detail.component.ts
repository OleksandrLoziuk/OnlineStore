import { Component, OnInit, Input } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { Product } from '../_models/Product';
import { ActivatedRoute } from '@angular/router';
import { CategoryService } from '../_services/category.service';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from 'ngx-gallery';
import { StringsOrderService } from '../_services/stringsOrder.service';


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
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  constructor(private route: ActivatedRoute, private categoryService: CategoryService, private alertify: AlertifyService, private stringsOrederService: StringsOrderService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.product = data['product'];
    });
    this.galleryOptions = [
      {
       // width: '100%',
        //height: '500px',
        imagePercent: 100,
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide,
        preview: true
      }
    ];
    this.galleryImages = this.getImages();
  } 
  getImages(){
    const imageUrls = [];
    for(let i = 0; i < this.product.photos.length; i++) {
      imageUrls.push({
        small: this.product.photos[i].url,
        medium: this.product.photos[i].url,
        big: this.product.photos[i].url
      });
    }
    return imageUrls;
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
 
 toCart(){
  this.stringsOrederService.addProduct(this.product);
}

}
