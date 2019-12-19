import { Component, OnInit } from '@angular/core';
import {FoodItem} from '../../shared/models/FoodItem';
import {ActivatedRoute} from '@angular/router';
import {FoodItemService} from '../../shared/services/food-item.service';
import {User} from '../../shared/models/User';
import {UserService} from '../../shared/services/user.service';
import {Cart} from '../../shared/models/Cart';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit {
  user: User;
  carts: Cart[];
  constructor(private route: ActivatedRoute, private userService: UserService) { }

  ngOnInit() {
    const id = +this.route.snapshot.paramMap.get('id');
    this.userService.getUserById(id)
      .subscribe(userFromApi => {
        this.user = userFromApi;
        this.carts = this.user.Carts;
      });
  }
}
