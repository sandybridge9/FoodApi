import { Component, OnInit } from '@angular/core';
import {User} from '../../shared/models/User';
import {UserService} from '../../shared/services/user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  users: User[];

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.refresh();
  }

  refresh() {
    this.userService.getUsers()
      .subscribe(listOfUserItems => {
        this.users = listOfUserItems;
        console.log(this.users);
      });
  }

  deleteUser(id: number) {
    this.userService.deleteUser(id)
      .subscribe(message => {
        console.log('Deleted user, got message: ' + message);
        this.refresh();
      });
  }
}
