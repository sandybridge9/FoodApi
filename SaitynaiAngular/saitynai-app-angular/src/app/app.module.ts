import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { FoodItemListComponent } from './FoodItem/food-item-list/food-item-list.component';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { AppRoutingModule } from './app-routing.module';
import { FoodItemDetailsComponent } from './FoodItem/food-item-details/food-item-details.component';
import { FoodItemAddComponent } from './FoodItem/food-item-add/food-item-add.component';
import {ReactiveFormsModule} from '@angular/forms';
import { FoodItemUpdateComponent } from './FoodItem/food-item-update/food-item-update.component';
import {HttpClientModule} from '@angular/common/http';
import { FoodCategoryListComponent } from './FoodCategory/food-category-list/food-category-list.component';
import { FoodCategoryAddComponent } from './FoodCategory/food-category-add/food-category-add.component';
import { FoodCategoryUpdateComponent } from './FoodCategory/food-category-update/food-category-update.component';
import { FoodCategoryDetailsComponent } from './FoodCategory/food-category-details/food-category-details.component';
import { UserListComponent } from './User/user-list/user-list.component';
import { UserAddComponent } from './User/user-add/user-add.component';
import { UserDetailsComponent } from './User/user-details/user-details.component';
import { UserUpdateComponent } from './User/user-update/user-update.component';

@NgModule({
  declarations: [
    AppComponent,
    FoodItemListComponent,
    NavbarComponent,
    WelcomeComponent,
    FoodItemDetailsComponent,
    FoodItemAddComponent,
    FoodItemUpdateComponent,
    FoodCategoryListComponent,
    FoodCategoryAddComponent,
    FoodCategoryUpdateComponent,
    FoodCategoryDetailsComponent,
    UserListComponent,
    UserAddComponent,
    UserDetailsComponent,
    UserUpdateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
