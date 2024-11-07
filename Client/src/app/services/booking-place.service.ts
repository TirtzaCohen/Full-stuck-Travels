import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BookingPlace } from '../classes/BookingPlace';

@Injectable({
  providedIn: 'root'
})
export class BookingPlaceService {

  constructor(public http:HttpClient) { }
  baseUrl:String = "https://localhost:7128/api/BookingPlace/";

  get_all():Observable<Array<BookingPlace>>
  {
    return this.http.get<Array<BookingPlace>>(`${this.baseUrl}GetAllBookingPlaces/`);
  }

  get_all_to_trip(code:Number):Observable<Array<BookingPlace>>
  {
    return this.http.get<Array<BookingPlace>>(`${this.baseUrl}GetAllToTrip/${code}`);
  }

  add(bp:BookingPlace):Observable<Boolean>
  {
    return this.http.post<Boolean>(`${this.baseUrl}AddBookingPlace/`, bp);
  }

  delete(code:Number):Observable<Boolean>
  {
    return this.http.delete<Boolean>(`${this.baseUrl}DeleteBookingPlace/${code}`);
  }


}
