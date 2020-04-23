import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BalanceComponent } from './balance/balance.component';
import { ReceiptListComponent } from './receipt-list/receipt-list.component';
import { ConsumptionListComponent } from './consumption-list/consumption-list.component';
import { CategoriesListComponent } from './categories-list/categories-list.component';
import { ProductsListComponent } from './products-list/products-list.component';
import { OrdersListComponent } from './orders-list/orders-list.component';


const routes: Routes = [
  {path: 'balance', component: BalanceComponent},
  {path: 'receipt', component: ReceiptListComponent},
  {path: 'consumption', component: ConsumptionListComponent},
  {path: 'categories', component: CategoriesListComponent},
  {path: 'products', component: ProductsListComponent},
  {path: 'orders', component: OrdersListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
