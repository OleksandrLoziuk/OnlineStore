import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AuthComponent } from './auth/auth.component';
import { AuthService } from './_services/auth.service';
import { MainComponent } from './main/main.component';
import { HomeComponent } from './home/home.component';
import { WorkspaceComponent } from './workspace/workspace.component';
import { CategoriesListComponent } from './categories-list/categories-list.component';
import { ProductsListComponent } from './products-list/products-list.component';
import { BalanceComponent } from './balance/balance.component';
import { ReceiptListComponent } from './receipt-list/receipt-list.component';
import { ConsumptionListComponent } from './consumption-list/consumption-list.component';
import { OrdersListComponent } from './orders-list/orders-list.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { AlertifyService } from './_services/alertify.service';

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      AuthComponent,
      MainComponent,
      HomeComponent,
      WorkspaceComponent,
      CategoriesListComponent,
      ProductsListComponent,
      BalanceComponent,
      ReceiptListComponent,
      ConsumptionListComponent,
      OrdersListComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule
   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider,
      AlertifyService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
