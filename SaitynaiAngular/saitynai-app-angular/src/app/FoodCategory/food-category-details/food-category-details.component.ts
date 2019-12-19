import { Component, OnInit } from '@angular/core';
import {FoodItem} from '../../shared/models/FoodItem';
import {ActivatedRoute} from '@angular/router';
import {FoodItemService} from '../../shared/services/food-item.service';
import {FoodCategory} from '../../shared/models/FoodCategory';
import {FoodCategoryService} from '../../shared/services/food-category.service';

@Component({
  selector: 'app-food-category-details',
  templateUrl: './food-category-details.component.html',
  styleUrls: ['./food-category-details.component.css']
})
export class FoodCategoryDetailsComponent implements OnInit {

  foodCategory: FoodCategory;
  constructor(private route: ActivatedRoute, private foodCategoryService: FoodCategoryService) { }

  ngOnInit() {
    const id = +this.route.snapshot.paramMap.get('id');
    this.foodCategoryService.getFoodCategoryById(id)
      .subscribe(foodCategoryFromApi => {
        this.foodCategory = foodCategoryFromApi;
      });
  }
}
