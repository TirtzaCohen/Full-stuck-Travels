import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/classes/User';
import { CurrentService } from 'src/app/services/current.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  constructor(public sUser:UserService, public MyRouter:Router, public sCurrent:CurrentService){}
  u:User = new User(0);
  frm:FormGroup = new FormGroup({})
  ngOnInit(): void 
  {
    this.frm = new FormGroup({
      "code": new FormControl("", [Validators.required] ),
      "name": new FormControl("", [Validators.required, Validators.minLength(2), Validators.pattern('[A-Za-zא-ת]{2,}')]),
      "family": new FormControl("", [Validators.required, Validators.minLength(2), Validators.pattern('[A-Za-zא-ת]{2,}')]),
      "phone": new FormControl("", [Validators.required, Validators.max(10), Validators.minLength(10), Validators.pattern('[0-9]{10,}')]),
      "email": new FormControl("", [Validators.required, Validators.email]),
      "password": new FormControl("", [Validators.required, Validators.minLength(5) ,Validators.pattern('[A-Za-z0-9#@$&]{5,}')])
    })
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

  SignUp(){
    alert("נכנסתי")
    this.sUser.get(this.u.Email!,this.u.LoginPassword!).subscribe(
      succ=>
      {
        if(succ)
        {
          alert("קיים משתמש כזה במערכת")
          this.MyRouter.navigate([`./sign-in`])
        }
        else{
          this.sUser.add(this.u).subscribe(
            s=>{
              if (succ)
              alert("נוספת בהצלחה למערכת")
              this.sCurrent.User=this.u
              this.MyRouter.navigate([`./Trips`])
              },
            e=>{alert(e.message)}
          );
        }
      }
      
    )
    
    }
  
}
