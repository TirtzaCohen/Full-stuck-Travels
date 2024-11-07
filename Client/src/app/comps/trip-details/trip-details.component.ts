import { Time } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { timer } from 'rxjs';
import { BookingPlace } from 'src/app/classes/BookingPlace';
import { Trip } from 'src/app/classes/Trip';
import { User } from 'src/app/classes/User';
import { BookingPlaceService } from 'src/app/services/booking-place.service';
import { TripService } from 'src/app/services/trip.service';

@Component({
  selector: 'app-trip-details',
  templateUrl: './trip-details.component.html',
  styleUrls: ['./trip-details.component.css']
})
export class TripDetailsComponent implements OnInit {
constructor(public sRouting:ActivatedRoute , public sTrip:TripService, public sBookingPlac:BookingPlaceService, public MyRoute:Router){}
CurrentUser:User = new User(0)
trip:Trip = new Trip(0)
hidd:boolean = true
h:boolean = true
booking_place!:BookingPlace
time?:Time
p:Number = 0;
images:string[] = ['image1', 'image2', 'image3'];
  ngOnInit() {
    this.sRouting.params.subscribe(
          data=>this.sTrip.get(data[`code`]).subscribe(
          succ=>{this.trip=succ},
          err=>{alert(err.message)})
    ) 
  }

  Display(){
    if(this.hidd==true)
      this.hidd = false
  }

  OrderPlace(){
    if(this.trip.NumberOfAvailablePlaces!>=this.p)
  { 
    if(this.CurrentUser.Name=="אורח")
    {
      alert("אורח")
      this.h = false
      this.MyRoute.navigate(['./SignIn'])
    }
    this.booking_place = new BookingPlace(0,7, "תרצה כהן", new Date("2024-01-17"), 2,"אוצרות ים המלח",new Date("2024-02-02T00:00:00"),1 )
    this.sBookingPlac.add(this.booking_place).subscribe(
      succ=>{this.hidd=true},
      err=>{alert(err.message)}
    )
  }
    else
      alert("אין מספיק מקומות")      
  }
}
