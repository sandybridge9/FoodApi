import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule, Routes} from '@angular/router';
import {WelcomeComponent} from './welcome/welcome.component';
import {FoodItemListComponent} from './FoodItem/food-item-list/food-item-list.component';
import {FoodItemDetailsComponent} from './FoodItem/food-item-details/food-item-details.component';
import {FoodItemAddComponent} from './FoodItem/food-item-add/food-item-add.component';
import {FoodItemUpdateComponent} from './FoodItem/food-item-update/food-item-update.component';
import {FoodCategoryListComponent} from './FoodCategory/food-category-list/food-category-list.component';
import {FoodCategoryDetailsComponent} from './FoodCategory/food-category-details/food-category-details.component';
import {FoodCategoryAddComponent} from './FoodCategory/food-category-add/food-category-add.component';
import {FoodCategoryUpdateComponent} from './FoodCategory/food-category-update/food-category-update.component';
import {UserListComponent} from './User/user-list/user-list.component';
import {UserDetailsComponent} from './User/user-details/user-details.component';
import {UserAddComponent} from './User/user-add/user-add.component';
import {UserUpdateComponent} from './User/user-update/user-update.component';

const routes: Routes = [
  { path: '', component: WelcomeComponent},
  { path: 'FoodItems', component: FoodItemListComponent},
  { path: 'FoodItems/:id', component: FoodItemDetailsComponent},
  { path: 'FoodItems-add', component: FoodItemAddComponent},
  { path: 'FoodItems-update/:id', component: FoodItemUpdateComponent},
  { path: 'FoodCategories', component: FoodCategoryListComponent},
  { path: 'FoodCategories/:id', component: FoodCategoryDetailsComponent},
  { path: 'FoodCategories-add', component: FoodCategoryAddComponent},
  { path: 'FoodCategories-update/:id', component: FoodCategoryUpdateComponent},
  { path: 'Users', component: UserListComponent},
  { path: 'Users/:id', component: UserDetailsComponent},
  { path: 'Users-add', component: UserAddComponent},
  { path: 'Users-update/:id', component: UserUpdateComponent}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
