import { Time } from "@angular/common";

export class BookingPlace{
    constructor(public BookingCode:Number, public UserCode?:Number, public FullNameUser?:String, public BookingDate?:Date, public TripCode?:Number, public Destination?:String, public TripDate?:Date, public NumberOfPlaces?:Number){}
}