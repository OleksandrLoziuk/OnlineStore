import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { JwtModule } from '@auth0/angular-jwt';
import { FileUploadModule } from 'ng2-file-upload';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AuthComponent } from './auth/auth.component';
import { AuthService } from './_services/auth.service';
import { MainComponent } from './main/main.component';
import { HomeComponent } from './home/home.component';
import { WorkspaceComponent } from './workspace/workspace.component';
import { CategoriesListComponent } from './categories-list/categories-list.component';
import { BalanceComponent } from './balance/balance.component';
import { ReceiptListComponent } from './receipt-list/receipt-list.component';
import { ConsumptionListComponent } from './consumption-list/consumption-list.component';
import { OrdersListComponent } from './orders-list/orders-list.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { AlertifyService } from './_services/alertify.service';
import { CategoriesService } from './_services/categories.service';
import { AuthGuard } from './_guards/auth.guard';
import { CategoriesListResolver } from './_resolvers/categories-list.resolver';
import { CategoryAddComponent } from './category-add/category-add.component';
import { PhotocategoryEditorComponent } from './photocategory-editor/photocategory-editor.component';
import { CategoryEditComponent } from './category-edit/category-edit.component';
import { CategoriesEditResolver } from './_resolvers/categories-edit.resolver';
import { WelcomepageComponent } from './welcomepage/welcomepage.component';
import { ProductsListComponent } from './products-list/products-list.component';
import { ProductsService } from './_services/products.service';
import { ProductsListResolver } from './_resolvers/products-list.resolver';
import { ProductAddComponent } from './product-add/product-add.component';
import { ColorService } from './_services/color.service';
import { ColorsListReolver } from './_resolvers/colors-list.resolver';
import { ColorsListComponent } from './colors-list/colors-list.component';
import { ColorsAddComponent } from './colors-add/colors-add.component';
import { ProductEditComponent } from './product-edit/product-edit.component';
import { ProductsEditResolver } from './_resolvers/products-edit.resolver';
import { ReceiptAddComponent } from './receipt-add/receipt-add.component';
import { ReceiptListResolver } from './_resolvers/receipt-list.resolver';







export function tokenGetter() {
   return localStorage.getItem('token');
}

@NgModule({
   declarations: [										
      AppComponent,
      NavComponent,
      AuthComponent,
      MainComponent,
      HomeComponent,
      WorkspaceComponent,
      CategoriesListComponent,
      BalanceComponent,
      ReceiptListComponent,
      ConsumptionListComponent,
      OrdersListComponent,
      CategoryAddComponent,
      PhotocategoryEditorComponent,
      CategoryEditComponent,
      WelcomepageComponent,
      ProductsListComponent,
      ProductAddComponent,
      ColorsListComponent,
      ColorsAddComponent,
      ProductEditComponent,
      ReceiptAddComponent,
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      FileUploadModule,
      JwtModule.forRoot({
         config: {
            tokenGetter: tokenGetter,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: ['localhost:5000/api/auth']
         }
      })
   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider,
      AlertifyService,
      AuthGuard,
      CategoriesService,
      CategoriesListResolver,
      CategoriesEditResolver,
      ProductsService,
      ProductsListResolver,
      ColorService,
      ColorsListReolver,
      ProductsEditResolver,
      ReceiptListResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
