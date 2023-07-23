import {Component, OnInit} from '@angular/core';
import { IUserModel } from "../models/IUserModel";
import {UserService} from "../services/user.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(private userService: UserService) { }

  userDto: IUserModel = {
    userId: 0,
    firstName: "",
    lastName: "",
    email: ""
  };

  items: IUserModel[] = [];

  ngOnInit() {
    this.userService.GetAllUsers().subscribe(
      (response: IUserModel[]) => {
        this.items = response;
      },
      (error: any) => {
        console.log(error.Message)
      }
    );
  }

  createUser(user: IUserModel) {
    if (user.firstName === "" || user.lastName === "" || user.email === "") {
      alert("Error");
      return;
    }
    this.userService.CreateNewUser(user).subscribe(
      response => {
        alert("Successful");
        this.userService.GetAllUsers().subscribe(
          (response: IUserModel[]) => {
            this.items = response;
          },
          (error: any) => {
            console.log(error.Message)
          }
        );
      },
      error => {
        alert("Error");
      }
    );
  }
  removeUser(userId: number) : void {
    this.userService.DeleteUser(userId).subscribe(
      (response) =>{
        alert("Successfully");
        this.userService.GetAllUsers().subscribe(
          (response: IUserModel[]) => {
            this.items = response;
          },
          (error: any) => {
            console.log(error.Message)
          }
        );
      }
    );
  }
}
