import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Trip } from '../classes/Trip';

@Injectable({
  providedIn: 'root'
})
export class TripService {

  constructor(public http:HttpClient) { }
  baseUrl:String = "https://localhost:7128/api/Trip/";

  get_all():Observable<Array<Trip>>
  {
    return this.http.get<Array<Trip>>(`${this.baseUrl}GetAllTrips/`);
  }

  get(code:Number):Observable<Trip>
  {
    return this.http.get<Trip>(`${this.baseUrl}GetTripById/${code}`);
  }

  add(t:Trip):Observable<Boolean>
  {
    return this.http.post<Boolean>(`${this.baseUrl}Addtrip/`, t);
  }

  update(t:Trip):Observable<Boolean>
  {
    return this.http.put<Boolean>(`${this.baseUrl}UpdateTrip/`, t);
  }

  delete(code:Number):Observable<Boolean>
  {
    return this.http.delete<Boolean>(`${this.baseUrl}DeletaTrip${code}`);
  }

}
