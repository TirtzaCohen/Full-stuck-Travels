import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/classes/User';
import { CurrentService } from 'src/app/services/current.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit{
  constructor(public sUser:UserService, public sCuurent:CurrentService, public MyRoute:Router){}
  Email:String = ""
  Password:string =""
  frm:FormGroup = new FormGroup({})
  u:User =new User(0)
  ngOnInit(): void 
  {
    this.frm = new FormGroup({
      "email": new FormControl("", [Validators.required, Validators.email]),
      "password": new FormControl("", [Validators.required, Validators.minLength(5) ,Validators.pattern('[a-z0-9#@$&]{5,}')])
    })
  }
  
  get email(){
    return this.frm.controls['email'];
  }

  get password(){
    return this.frm.controls['password'];
  }
   
  SignIn(){
    debugger
    // אם הוא מנהל
    if (localStorage.getItem('email')==this.Email && localStorage.getItem('password')==this.Password)
    {
      this.sCuurent.Managger=true
      this.MyRoute.navigate(['/Trips'])
    }
    // אם הוא משתמש
    else if (localStorage.getItem('email')!=this.Email || localStorage.getItem('password')!=this.Password)
    {
      this.sUser.get(this.Email, this.Password).subscribe(
      succ=>{this.u = succ})

       // אם הוא משתמש חדש
      if (this.u.Name==null)
        this.MyRoute.navigate(['/SignUp'])

      this.sCuurent.User=this.u
      this.MyRoute.navigate(['/Trips'])
    }

     
    }

  
}
