import { Component, OnInit } from '@angular/core';
import { CurrentService } from './services/current.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  constructor(public sCurrent:CurrentService){}
  ngOnInit(): void {
    localStorage.setItem( "email","tc3261@gmail.com")
    localStorage.setItem( "password","12345")
  }
  
  title = 'Journey Joy';
  h_private_area(){
    return false;
  }
  h_users(){
}
  who_is_now(){
    if(this.sCurrent.Managger==true)
      return "תרצה"
    else
      return this.sCurrent.User.Name
  }
  
}
