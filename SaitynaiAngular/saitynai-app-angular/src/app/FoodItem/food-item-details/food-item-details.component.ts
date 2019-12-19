import { Component, OnInit } from '@angular/core';
import {FoodItem} from '../../shared/models/FoodItem';
import {FoodItemService} from '../../shared/services/food-item.service';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-food-item-details',
  templateUrl: './food-item-details.component.html',
  styleUrls: ['./food-item-details.component.css']
})
export class FoodItemDetailsComponent implements OnInit {
  foodItem: FoodItem;
  constructor(private route: ActivatedRoute, private foodItemService: FoodItemService) { }

  ngOnInit() {
    const id = +this.route.snapshot.paramMap.get('id');
    this.foodItemService.getFoodItemById(id)
      .subscribe(foodItemFromApi => {
        this.foodItem = foodItemFromApi;
      });
  }


}
