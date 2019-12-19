import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {FoodItemService} from '../../shared/services/food-item.service';
import {FormControl, FormGroup} from '@angular/forms';

@Component({
  selector: 'app-food-item-update',
  templateUrl: './food-item-update.component.html',
  styleUrls: ['./food-item-update.component.css']
})
export class FoodItemUpdateComponent implements OnInit {
  id: number;

  foodItemForm = new FormGroup({
    Name: new FormControl(''),
    FoodCategoryId: new FormControl('')
  });

  constructor(private route: ActivatedRoute, private foodItemService: FoodItemService, private router: Router) { }

  ngOnInit() {
    this.id = +this.route.snapshot.paramMap.get('id');

    this.foodItemService.getFoodItemById(this.id)
      .subscribe(foodItem =>{
        this.foodItemForm.patchValue({
          Name: foodItem.Name,
          FoodCategoryId: foodItem.FoodCategoryId
        });
      });
  }

  save() {
    const foodItem = this.foodItemForm.value;
    foodItem.Id = this.id;
    this.foodItemService.updateFoodItem(foodItem)
      .subscribe(() => {
        this.router.navigateByUrl('/FoodItems');
    });
  }
}
