import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BalanceComponent } from './balance/balance.component';
import { ReceiptListComponent } from './receipt-list/receipt-list.component';
import { ConsumptionListComponent } from './consumption-list/consumption-list.component';
import { CategoriesListComponent } from './categories-list/categories-list.component';
import { ProductsListComponent } from './products-list/products-list.component';
import { OrdersListComponent } from './orders-list/orders-list.component';
import { MainComponent } from './main/main.component';
import { AuthGuard } from './_guards/auth.guard';
import { CategoriesListResolver } from './_resolvers/categories-list.resolver';
import { CategoryAddComponent } from './category-add/category-add.component';
import { CategoryEditComponent } from './category-edit/category-edit.component';
import { CategoriesEditResolver } from './_resolvers/categories-edit.resolver';
import { WelcomepageComponent } from './welcomepage/welcomepage.component';
import { PhotocategoryEditorComponent } from './photocategory-editor/photocategory-editor.component';



const routes: Routes = [
  {path: 'welcomepage', component: WelcomepageComponent},
  {path: 'balanceadmin', component: BalanceComponent},
  {path: 'receiptadmin', component: ReceiptListComponent},
  {path: 'consumptionadmin', component: ConsumptionListComponent},
  {path: 'categoriesadmin', component: CategoriesListComponent, resolve: {categories: CategoriesListResolver}},
  {path: 'productsadmin', component: ProductsListComponent},
  {path: 'ordersadmin', component: OrdersListComponent},
  {path: 'categoriesadmin/add', component: CategoryAddComponent},
  {path: 'categoriesadmin/:id/edit', component: CategoryEditComponent,resolve: {category: CategoriesEditResolver}},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
