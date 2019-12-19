import { Component, OnInit } from '@angular/core';
import {FoodItemService} from '../../shared/services/food-item.service';
import {FoodItem} from '../../shared/models/FoodItem';
import {FormControl, FormGroup} from '@angular/forms';
import {Router} from '@angular/router';

@Component({
  selector: 'app-food-item-add',
  templateUrl: './food-item-add.component.html',
  styleUrls: ['./food-item-add.component.css']
})
export class FoodItemAddComponent implements OnInit {

  foodItemForm = new FormGroup({
    Name: new FormControl(''),
    FoodCategoryId: new FormControl('')
  });

  constructor(private foodItemService: FoodItemService, private router: Router) { }

  ngOnInit() {
  }

  save() {
    const foodItem = this.foodItemForm.value;
    this.foodItemService.addFoodItem(foodItem)
      .subscribe(() => {
        this.router.navigateByUrl('/FoodItems');
      });
  }
}
