import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './comps/home/home.component';
import { SignInComponent } from './comps/sign-in/sign-in.component';
import { SignUpComponent } from './comps/sign-up/sign-up.component';
import { TripsComponent } from './comps/trips/trips.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { UsersComponent } from './comps/users/users.component';
import { PersonalAreaComponent } from './comps/personal-area/personal-area.component';
import { TripDetailsComponent } from './comps/trip-details/trip-details.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    TripsComponent,
    SignInComponent,
    SignUpComponent,
    UsersComponent,
    PersonalAreaComponent,
    TripDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
