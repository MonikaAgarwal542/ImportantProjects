import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LogInComponent } from './log-in/log-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import {HttpClientModule} from '@angular/common/http';
import { HomePageComponent } from './home-page/home-page.component';
import { NoPageFoundComponent } from './no-page-found/no-page-found.component';
import { JwtModule } from '@auth0/angular-jwt';
import { AddCampComponent } from './add-camp/add-camp.component';
import { ManageCampComponent } from './manage-camp/manage-camp.component';
import { EditCampComponent } from './edit-camp/edit-camp.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { UserdashboardComponent } from './userdashboard/userdashboard.component';
import { BookingComponentComponent } from './booking-component/booking-component.component';
import { ManageBookingComponent } from './manage-booking/manage-booking.component';
@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    LogInComponent,
    SignUpComponent,
    HomePageComponent,
    NoPageFoundComponent,
    AddCampComponent,
    ManageCampComponent,
    EditCampComponent,
    UserdashboardComponent,
    BookingComponentComponent,
    ManageBookingComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    JwtModule,
    NgxPaginationModule
   
    

   
   
  ],
  providers: [
   
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
