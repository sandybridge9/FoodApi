import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import {FoodItemService} from '../../shared/services/food-item.service';
import {Router} from '@angular/router';
import {FoodCategoryService} from '../../shared/services/food-category.service';

@Component({
  selector: 'app-food-category-add',
  templateUrl: './food-category-add.component.html',
  styleUrls: ['./food-category-add.component.css']
})
export class FoodCategoryAddComponent implements OnInit {
  foodCategoryForm = new FormGroup({
    Name: new FormControl('')
  });

  constructor(private foodCategoryService: FoodCategoryService, private router: Router) { }

  ngOnInit() {
  }

  save() {
    const foodCategory = this.foodCategoryForm.value;
    this.foodCategoryService.addFoodCategory(foodCategory)
      .subscribe(() => {
        this.router.navigateByUrl('/FoodCategories');
      });
  }

}
