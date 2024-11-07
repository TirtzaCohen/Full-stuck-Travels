import { Injectable, OnInit } from '@angular/core';
import { User } from '../classes/User';

@Injectable({
  providedIn: 'root'
})
export class CurrentService{
  Managger:Boolean = false
  User:User = new User(0,"אורח")
  
  
}
