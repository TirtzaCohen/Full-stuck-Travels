import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TravelType } from 'src/app/classes/TravelType';
import { Trip } from 'src/app/classes/Trip';
import { TravelTypeService } from 'src/app/services/travel-type.service';
import { TripService } from 'src/app/services/trip.service';

@Component({
  selector: 'app-trips',
  templateUrl: './trips.component.html',
  styleUrls: ['./trips.component.css']
})
export class TripsComponent implements OnInit {
  constructor(public sTrip:TripService, public STravelType:TravelTypeService, public MyRouter:Router){}
  tempTrips:Array<Trip> = new Array<Trip>()
  Trips:Array<Trip> = new Array<Trip>()
  TravelTypes:Array<TravelType> = new Array<TravelType>()
  ngOnInit(): void {
    this.sTrip.get_all().subscribe(
      succ=>{
        console.log(succ);
        
        this.Trips=succ
        this.tempTrips = this.Trips
      },
      err=>{
        alert(err.message)
      }
    )

    

    this.STravelType.get_all().subscribe(
      succ=>{this.TravelTypes=succ},
      err=>{alert(err.message)}
    )
  }
  
  sort(code:Number){
    debugger
    if (code!=-1)
      this.tempTrips = this.Trips.filter(x=>x.TypeCode==code)
    else
      this.tempTrips = this.Trips
  }
  goToTripDet(code:number){
    this.MyRouter.navigate([`TripDetails/${code}`])
  }
}
