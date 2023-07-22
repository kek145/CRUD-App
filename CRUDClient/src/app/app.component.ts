import { Component } from '@angular/core';
import { IUserModel } from "../models/IUserModel";
import {UserService} from "../services/user.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private userService: UserService) { }

  userDto: IUserModel = {
    userId: 0,
    firstName: "",
    lastName: "",
    email: ""
  };

  createUser(user: IUserModel) {
    if (user.firstName === "" || user.lastName === "" || user.email === "") {
      alert("Error");
      return;
    }

    this.userService.CreateNewUser(user).subscribe(
      response => {
        alert(response);
      },
      error => {
        alert(error);
      }
    );
  }
}
