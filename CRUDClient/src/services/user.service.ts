import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserModel } from 'src/models/UserModel';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }
  
  public CreateNewUser(user: UserModel): Observable<UserModel> {
    return this.http.post<UserModel>(`${environment.apiUrl}/User/CreateNewUser`, user);
  }

  public GetAllUsers(): Observable<UserModel[]> {
    return this.http.get<UserModel[]>(`${environment.apiUrl}/User/GetAllUsers`);
  }

  public UpdateUser(userId: number) : Observable<UserModel> {
    return this.http.put<UserModel>(`${environment}/User/UpdateUser/${userId}`, userId);
  }

  public DeleteUser(userId: number) : Observable<UserModel> {
    return this.http.delete<UserModel>(`${environment.apiUrl}/User/DeleteUser/${userId}`);
  }
}
