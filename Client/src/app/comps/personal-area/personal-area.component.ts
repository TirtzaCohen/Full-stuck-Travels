import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BookingPlace } from 'src/app/classes/BookingPlace';
import { TravelType } from 'src/app/classes/TravelType';
import { Trip } from 'src/app/classes/Trip';
import { User } from 'src/app/classes/User';
import { BookingPlaceService } from 'src/app/services/booking-place.service';
import { CurrentService } from 'src/app/services/current.service';
import { TravelTypeService } from 'src/app/services/travel-type.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-personal-area',
  templateUrl: './personal-area.component.html',
  styleUrls: ['./personal-area.component.css']
})
export class PersonalAreaComponent {
  constructor(public sUser:UserService, public sBookingPlace:BookingPlaceService, public STravelType:TravelTypeService, public sCurrent:CurrentService){}
  Today:Date = new Date()
  Edit:String = "Edit";
  MyTrips:String = "MyTrips";
  b_edit:Boolean = true;
  b_mytrips:Boolean = true;
  u:User = this.sCurrent.User
  frm:FormGroup = new FormGroup({})
  Trips:Array<Trip> = new Array<Trip>()
  tempTrips:Array<Trip> = new Array<Trip>()
  BookingPlaces:Array<BookingPlace> = new Array<BookingPlace>()
  bp:BookingPlace = new BookingPlace(0)
  TravelTypes:Array<TravelType> = new Array<TravelType>()
  SortBy:String = ""
  T_F:Boolean = true
  ngOnInit(): void 
  {
    this.frm = new FormGroup({
      "code": new FormControl("",[Validators.required] ),
      "name": new FormControl("", [Validators.required, Validators.minLength(2), Validators.pattern('[A-Za-zא-ת]{2,}')]),
      "family": new FormControl("", [Validators.required, Validators.minLength(2), Validators.pattern('[A-Za-zא-ת]{2,}')]),
      "phone": new FormControl("", [Validators.required, Validators.max(10), Validators.minLength(10), Validators.pattern('[0-9]{10,}')]),
      "email": new FormControl("", [Validators.required, Validators.email]),
      "password": new FormControl("", [Validators.required, Validators.minLength(5) ,Validators.pattern('[A-Za-z0-9#@$&]{5,}')])
    })

    this.sUser.get_all_trips(this.u.UserCode).subscribe(
      succ=>
      {
        this.Trips=succ
        this.tempTrips=this.Trips
      },
      err=>{alert(err.message)}
    );
   
    this.sBookingPlace.get_all().subscribe(
      succ=>{this.BookingPlaces=succ},
      err=>{alert(err.message)}
    )

    this.STravelType.get_all().subscribe(
      succ=>{this.TravelTypes=succ},
      err=>{alert(err.message)}
    )
     
    // אם זה המנהל
    this.sUser.get(localStorage.getItem('email')!, localStorage.getItem('password')!).subscribe(
      succ=>{this.u=succ},
      err=>{alert(err.message)}
    )
  }
  
  get name(){
    return this.frm.controls['name'];
  }

  get family(){
    return this.frm.controls['family'];
  }

  get phone(){
    return this.frm.controls['phone'];
  }

  get email(){
    return this.frm.controls['email'];
  }

  get password(){
    return this.frm.controls['password'];
  }

  selected(what:String){
    if (what=="Edit")
      this.b_edit=false
    if (what=="MyTrips")
      this.b_mytrips=false
  }

  sort(code:Number){
    debugger
    if (code!=-1)
      this.tempTrips = this.Trips.filter(x=>x.TypeCode==code)
    else
      this.tempTrips = this.Trips
  }

  cancel(trip:Trip){
    this.BookingPlaces.forEach((b)=>  {
      if(b.TripCode == trip.TripCode && b.UserCode == this.u.UserCode)
        this.bp = b;
    })
    this.sBookingPlace.delete(this.bp.BookingCode)
  }
  Remove(){
    this.Trips.forEach(t => {
      if (new Date(t.Date!) > this.Today)
      {
        this.T_F = false
      }
    }); 
    if(this.T_F == true)
    {
      this.sUser.delete(this.u)
      alert("הוסרת בהצלחה")
      this.sCurrent.User=new User(0,"אורח")
    }
  }
  NotPass(date:Date){
      return new Date(date)>this.Today
    }
  
  update(){
    debugger
    this.sUser.update(this.u).subscribe(
      succ=>{if(succ==true) alert("עודכן בהצלחה")},
      err=>{alert(err.message)}
    )
  }
}
