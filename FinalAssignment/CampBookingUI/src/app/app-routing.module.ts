import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddCampComponent } from './add-camp/add-camp.component';
import { BookingComponentComponent } from './booking-component/booking-component.component';
import { EditCampComponent } from './edit-camp/edit-camp.component';
import { HomePageComponent } from './home-page/home-page.component';
import { LogInComponent } from './log-in/log-in.component';
import { ManageBookingComponent } from './manage-booking/manage-booking.component';
import { ManageCampComponent } from './manage-camp/manage-camp.component';
import { NavbarComponent } from './navbar/navbar.component';
import { NoPageFoundComponent } from './no-page-found/no-page-found.component';
import { AuthGuard } from './Services/auth.guard';
import { SignUpComponent } from './sign-up/sign-up.component';
import { UserdashboardComponent } from './userdashboard/userdashboard.component';

const routes: Routes = [
  {
    path:"",
    redirectTo:"Login",
    pathMatch:"full"
  },
  {
    path:"Dashboard",
    children:[
      {path:"AddCamp",component:AddCampComponent},
      {path:"AllCamps",component:ManageCampComponent},
      {path:"EditCamp/:CampId",component:EditCampComponent},
      {path:"Camp",component:UserdashboardComponent},
      {path:"Camp/booking",component:BookingComponentComponent},
      {path:"SearchBooking",component:ManageBookingComponent},

    
    ],
    
    component:NavbarComponent,
    canActivate:[AuthGuard],
    
  },
 
 
  {
    path:"Login",
    component:LogInComponent
  },
  {
    path:"Signup",
    component:SignUpComponent
  },
  {
    path:"**",
    component:NoPageFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
