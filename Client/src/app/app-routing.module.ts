import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './comps/home/home.component';
import { TripsComponent } from './comps/trips/trips.component';
import { SignInComponent } from './comps/sign-in/sign-in.component';
import { SignUpComponent } from './comps/sign-up/sign-up.component';
import { UsersComponent } from './comps/users/users.component';
import { PersonalAreaComponent } from './comps/personal-area/personal-area.component';
import { TripDetailsComponent } from './comps/trip-details/trip-details.component';

const routes: Routes = [
  {path:'Home', component:HomeComponent},
  {path:'Trips', component:TripsComponent},
  {path:'SignIn', component:SignInComponent},
  {path:'SignUp', component:SignUpComponent},
  {path:'Users', component:UsersComponent},
  {path:'PersonalArea', component:PersonalAreaComponent},
  {path:'TripDetails/:code', component:TripDetailsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
