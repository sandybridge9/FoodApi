import { Component, OnInit } from '@angular/core';
import {FoodItem} from '../../shared/models/FoodItem';
import {FoodCategory} from '../../shared/models/FoodCategory';
import {FoodItemService} from '../../shared/services/food-item.service';

@Component({
  selector: 'app-food-item-list',
  templateUrl: './food-item-list.component.html',
  styleUrls: ['./food-item-list.component.css']
})
export class FoodItemListComponent implements OnInit {

  foodItems: FoodItem[];

  constructor(private foodItemService: FoodItemService) { }

  ngOnInit() {
    this.refresh();
  }

  refresh() {
    this.foodItemService.getFoodItems()
      .subscribe(listOfFoodItems => {
        this.foodItems = listOfFoodItems;
        console.log(this.foodItems);
      });
  }

  deleteFoodItem(id: number) {
    this.foodItemService.deleteFoodItem(id)
      .subscribe(message => {
        console.log('Deleted user, got message: ' +message);
        this.refresh();
      });
  }
}
