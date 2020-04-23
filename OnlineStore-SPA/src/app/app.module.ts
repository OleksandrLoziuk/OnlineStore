import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import { BsDropdownModule, TabsModule } from 'ngx-bootstrap';
import { NgxGalleryModule } from 'ngx-gallery';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { AlertifyService } from './_services/alertify.service';
import { AboutComponent } from './about/about.component';
import { ContactsComponent } from './contacts/contacts.component';
import { DeliveryComponent } from './delivery/delivery.component';
import { PaymentComponent } from './payment/payment.component';
import { ReviewsComponent } from './reviews/reviews.component';
import { CategoriesListComponent } from './categories-list/categories-list.component';
import { CategoryService } from './_services/category.service';
import { CategoryCardComponent } from './category-card/category-card.component';
import { CategoryDetailComponent } from './category-detail/category-detail.component';
import { ProductCardComponent } from './product-card/product-card.component';
import { CategoryDetailResolver } from './resolvers/category-detail.resolver';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductDetailResolver } from './resolvers/product-detail.resolver';
import { StringsOrderService } from './_services/stringsOrder.service';
import { ShopCartComponent } from './shop-cart/shop-cart.component';
import { OrderComponent } from './order/order.component';
import { OrderService } from './_services/order.service';
import { EndComponent } from './end/end.component';
import { FooterComponent } from './footer/footer.component';


@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HeaderComponent,
      HomeComponent,
      AboutComponent,
      ContactsComponent,
      DeliveryComponent,
      PaymentComponent,
      ReviewsComponent,
      CategoriesListComponent,
      CategoryCardComponent,
      CategoryDetailComponent,
      ProductCardComponent,
      ProductDetailComponent,
      ShopCartComponent,
      OrderComponent,
      EndComponent,
      FooterComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      NgxGalleryModule,
      FormsModule,
      TabsModule.forRoot(),
      BsDropdownModule.forRoot()
   ],
   providers: [
      ErrorInterceptorProvider,
      AlertifyService,
      CategoryService,
      StringsOrderService,
      CategoryDetailResolver,
      ProductDetailResolver,
      OrderService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
