import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { NoPageComponent } from './no-page/no-page.component';
import { HomeComponent } from './home/home.component';
import { AllRecordsComponent } from './all-records/all-records.component';
import { AddRecordsComponent } from './add-records/add-records.component';
import { AboutComponent } from './about/about.component';
import { HelpComponent } from './help/help.component';
import { NavbarComponent } from './navbar/navbar.component';
import { StudentComponent } from './student/student.component';
import { TeacherComponent } from './teacher/teacher.component';
import { UpdateRecordsComponent } from './update-records/update-records.component';
import { ViewResultComponent } from './view-result/view-result.component';
import { FindResultComponent } from './find-result/find-result.component';
const routes: Routes = [
  
 
  {
    path:"",
    component:HomeComponent
  },
 
  {
    path:"Student",
    children:[
      {path:"Result",component:FindResultComponent},
      {path:"About",component:AboutComponent},
      {path:"Help",component:HelpComponent},
      {path:"ViewResult/:Rollno/:Name",component:ViewResultComponent}
   

    ],
    component:StudentComponent
  },
  {
    path:"Teacher",
    children:[
      {path:"About",component:AboutComponent},
      {path:"Help",component:HelpComponent},
      {path:"AddRecords",component:AddRecordsComponent},
      {path:"AllRecords",component:AllRecordsComponent},
      {path:"UpdateRecords/:id",component:UpdateRecordsComponent}
     

    ],
    component:TeacherComponent
  },
 
  
  {
    path:"**",
    component:NoPageComponent
  }




];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
