import { Time } from "@angular/common";

export class Trip{
    constructor(public TripCode:number, public TripDestination?:String, public TypeCode?:Number, public Date?:Date, public DepartureTime?:Time, public TripDurationHours?:Number, public NumberOfAvailablePlaces?:Number, public Price?:Number, public NameType?:String, public Need_a_medic?:Boolean){}
}