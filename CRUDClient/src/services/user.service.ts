import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import {IUserModel} from "../models/IUserModel";
import {Observable} from "rxjs";
import {environment} from "../environments/environments";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  public CreateNewUser(user: IUserModel) : Observable<IUserModel> {
    return this.http.post<IUserModel>(`${environment.apiUrl}/User/CreateNewUser`, user);
  }

  public GetAllUsers() : Observable<IUserModel[]> {
    return this.http.get<IUserModel[]>(`${environment.apiUrl}/User/GetAllUsers`)
  }

  public GetUserById(userId: number) : Observable<IUserModel> {
    return this.http.get<IUserModel>(`${environment.apiUrl}/User/GetUserById/${userId}`);
  }

  public UpdateUser(userId: number, user: IUserModel) : Observable<IUserModel> {
    return this.http.put<IUserModel>(`${environment.apiUrl}/User/UpdateUser/${userId}`, user);
  }

  public DeleteUser(userId: number) : Observable<IUserModel> {
    return this.http.delete<IUserModel>(`${environment.apiUrl}/User/DeleteUser/${userId}`);
  }
}
