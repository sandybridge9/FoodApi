import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {FoodItemService} from '../../shared/services/food-item.service';
import {FoodCategoryService} from '../../shared/services/food-category.service';

@Component({
  selector: 'app-food-category-update',
  templateUrl: './food-category-update.component.html',
  styleUrls: ['./food-category-update.component.css']
})
export class FoodCategoryUpdateComponent implements OnInit {
  id: number;

  foodCategoryForm = new FormGroup({
    Name: new FormControl(''),
    FoodCategoryId: new FormControl('')
  });

  constructor(private route: ActivatedRoute, private foodCategoryService: FoodCategoryService, private router: Router) { }

  ngOnInit() {
    this.id = +this.route.snapshot.paramMap.get('id');

    this.foodCategoryService.getFoodCategoryById(this.id)
      .subscribe(foodCategory =>{
        this.foodCategoryForm.patchValue({
          Name: foodCategory.Name
        });
      });
  }

  save() {
    const foodCategory = this.foodCategoryForm.value;
    foodCategory.Id = this.id;
    this.foodCategoryService.updateFoodCategory(foodCategory)
      .subscribe(() => {
        this.router.navigateByUrl('/FoodCategories');
      });
  }

}
