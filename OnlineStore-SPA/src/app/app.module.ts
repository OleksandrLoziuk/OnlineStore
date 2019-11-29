import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/auth.service';
import { HeaderComponent } from './header/header.component';
import { RegisterComponent } from './register/register.component';
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

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HeaderComponent,
      RegisterComponent,
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
      ProductDetailComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot()
   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider,
      AlertifyService,
      CategoryService,
      CategoryDetailResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
