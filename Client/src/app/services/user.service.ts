import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../classes/User';
import { Trip } from '../classes/Trip';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(public http:HttpClient) { }
  baseUrl:string="https://localhost:7128/api/User/";
  
  get_all():Observable<Array<User>>
  {
    return this.http.get<Array<User>>(`${this.baseUrl}GetAllUsers/`)
  }

  get(email:String, password:String):Observable<User>
  {

    https://localhost:7128/api/User/GetUser?email=john.doe%40example.com&login_password=password1
    // return this.http.get<User>(`${this.baseUrl}GetUser/${email}${password}`);
    return this.http.get<User>(`${this.baseUrl}GetUser?email=${email}&login_password=${password}`);
  }

  add(u:User):Observable<Boolean>
  {
    return this.http.post<Boolean>(`${this.baseUrl}AddUser/`, u);
  }

  update(u:User):Observable<Boolean>
  {
    return this.http.put<Boolean>(`${this.baseUrl}UpdateUser/`, u);
  }

  delete(user:User):Observable<Boolean>
  {
    return this.http.delete<Boolean>(`${this.baseUrl}DeleteUser${user}`);
  }

  get_all_trips(code:Number):Observable<Array<Trip>>
  {
    return this.http.get<Array<Trip>>(`${this.baseUrl}GetAllTrips/${code}`);
  }

}
