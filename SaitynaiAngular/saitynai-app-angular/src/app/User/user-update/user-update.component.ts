import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {FoodItemService} from '../../shared/services/food-item.service';
import {UserService} from '../../shared/services/user.service';

@Component({
  selector: 'app-user-update',
  templateUrl: './user-update.component.html',
  styleUrls: ['./user-update.component.css']
})
export class UserUpdateComponent implements OnInit {
  id: number;

  userForm = new FormGroup({
    Name: new FormControl(''),
    UserLoginId: new FormControl('')
  });

  constructor(private route: ActivatedRoute, private userService: UserService, private router: Router) { }

  ngOnInit() {
    this.id = +this.route.snapshot.paramMap.get('id');

    this.userService.getUserById(this.id)
      .subscribe(user =>{
        this.userForm.patchValue({
          Name: user.Name,
          UserLoginId: user.UserLoginId
        });
      });
  }

  save() {
    const user = this.userForm.value;
    user.Id = this.id;
    this.userService.updateUser(user)
      .subscribe(() => {
        this.router.navigateByUrl('/Users');
      });
  }
}
