import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import {FoodItemService} from '../../shared/services/food-item.service';
import {Router} from '@angular/router';
import {UserService} from '../../shared/services/user.service';

@Component({
  selector: 'app-user-add',
  templateUrl: './user-add.component.html',
  styleUrls: ['./user-add.component.css']
})
export class UserAddComponent implements OnInit {

  userForm = new FormGroup({
    Name: new FormControl(''),
    FoodCategoryId: new FormControl('')
  });

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {
  }

  save() {
    const user = this.userForm.value;
    this.userService.addUser(user)
      .subscribe(() => {
        this.router.navigateByUrl('/Users');
      });
  }
}
