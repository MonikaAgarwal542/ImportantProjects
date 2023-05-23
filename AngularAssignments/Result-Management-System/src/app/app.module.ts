import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NoPageComponent } from './no-page/no-page.component';
import { HomeComponent } from './home/home.component';
import { AllRecordsComponent } from './all-records/all-records.component';
import { AddRecordsComponent } from './add-records/add-records.component';
import { AboutComponent } from './about/about.component';
import { HelpComponent } from './help/help.component';
import { TeacherComponent } from './teacher/teacher.component';
import { StudentComponent } from './student/student.component';
import {HttpClientModule} from '@angular/common/http';
import { UpdateRecordsComponent } from './update-records/update-records.component';
import { FindResultComponent } from './find-result/find-result.component';
import { ViewResultComponent } from './view-result/view-result.component';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    NoPageComponent,
    HomeComponent,
    AllRecordsComponent,
    AddRecordsComponent,
    AboutComponent,
    HelpComponent,
    TeacherComponent,
    StudentComponent,
    UpdateRecordsComponent,
    FindResultComponent,
    ViewResultComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
