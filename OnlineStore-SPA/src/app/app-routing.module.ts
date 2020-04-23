import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactsComponent } from './contacts/contacts.component';
import { DeliveryComponent } from './delivery/delivery.component';
import { PaymentComponent } from './payment/payment.component';
import { ReviewsComponent } from './reviews/reviews.component';
import { CategoriesListComponent } from './categories-list/categories-list.component';
import { CategoryDetailComponent } from './category-detail/category-detail.component';
import { CategoryDetailResolver } from './resolvers/category-detail.resolver';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductDetailResolver } from './resolvers/product-detail.resolver';
import { ShopCartComponent } from './shop-cart/shop-cart.component';
import { OrderComponent } from './order/order.component';
import { EndComponent } from './end/end.component';


const routes: Routes = [
  {path: 'home', component: HomeComponent},
  {path: 'categories', component: CategoriesListComponent},
  {path: 'categories/:id', component: CategoryDetailComponent, resolve: {categories: CategoryDetailResolver}},
  {path: 'categories/:catid/:prodid', component: ProductDetailComponent, resolve: {product: ProductDetailResolver}},
  {path: 'about', component: AboutComponent},
  {path: 'contacts', component: ContactsComponent},
  {path: 'delivery', component: DeliveryComponent},
  {path: 'payment', component: PaymentComponent},
  {path: 'reviews', component: ReviewsComponent},
  {path: 'cart', component: ShopCartComponent},
  {path: 'order', component: OrderComponent},
  {path: 'end', component: EndComponent},
  {path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
