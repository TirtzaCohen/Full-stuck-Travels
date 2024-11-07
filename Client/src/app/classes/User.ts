import { BookingPlace } from "./BookingPlace";

export class User{
    constructor(public UserCode:Number, public Name?:String, public Family?:String, public Phone?:String, public Email?:String, public LoginPassword?:String, public FirstAidCertificate?:Boolean, public BookingPlaces?:Array<BookingPlace>){}
}