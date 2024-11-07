import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TravelType } from '../classes/TravelType';

@Injectable({
  providedIn: 'root'
})
export class TravelTypeService {

  constructor(public http:HttpClient) { }
  baseUrl:String = "https://localhost:7128/api/TravelType/"; 


  get_all():Observable<Array<TravelType>>
  {
    return this.http.get<Array<TravelType>>(`${this.baseUrl}GetAllTravelTypes`);
  }

  add(tt:TravelType):Observable<Boolean>
  {
    return this.http.post<Boolean>(`${this.baseUrl}AddTravelType/`, tt);
  }

  delete(code:Number):Observable<Boolean>
  {
    return this.http.delete<Boolean>(`${this.baseUrl}DeletaTravelType${code}`);
  }
}
