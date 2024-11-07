import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/classes/User';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  constructor(public SUser:UserService){}
  Users:Array<User> = new Array<User>();
  ngOnInit(): void {
    this.SUser.get_all().subscribe(
      succ=>{
        this.Users=succ
      },
      err=>{
        alert(err.message)
      }
    )  }

}
