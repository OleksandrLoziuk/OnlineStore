import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactsComponent } from './contacts/contacts.component';
import { DeliveryComponent } from './delivery/delivery.component';
import { PaymentComponent } from './payment/payment.component';
import { ReviewsComponent } from './reviews/reviews.component';
import { RegisterComponent } from './register/register.component';
import { CategoriesListComponent } from './categories-list/categories-list.component';
import { CategoryDetailComponent } from './category-detail/category-detail.component';


const routes: Routes = [
  {path: 'home', component: HomeComponent},
  {path: 'categories', component: CategoriesListComponent},
  {path: 'categories/:id', component: CategoryDetailComponent},
  {path: 'about', component: AboutComponent},
  {path: 'contacts', component: ContactsComponent},
  {path: 'delivery', component: DeliveryComponent},
  {path: 'payment', component: PaymentComponent},
  {path: 'reviews', component: ReviewsComponent},
  {path: 'register', component: RegisterComponent},
  {path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
