import { Component, OnInit } from '@angular/core';
import {FoodCategory} from '../../shared/models/FoodCategory';
import {FoodCategoryService} from '../../shared/services/food-category.service';

@Component({
  selector: 'app-food-category-list',
  templateUrl: './food-category-list.component.html',
  styleUrls: ['./food-category-list.component.css']
})
export class FoodCategoryListComponent implements OnInit {

  foodCategories: FoodCategory[];

  constructor(private foodCategoryService: FoodCategoryService) { }

  ngOnInit() {
    this.refresh();
  }

  refresh() {
    this.foodCategoryService.getFoodCategories()
      .subscribe(listOfFoodCategories => {
        this.foodCategories = listOfFoodCategories;
        console.log(this.foodCategories);
      });
  }

  deleteFoodCategory(id: number) {
    this.foodCategoryService.deleteFoodCategory(id)
      .subscribe(() => {
        this.refresh();
      });
  }
}
