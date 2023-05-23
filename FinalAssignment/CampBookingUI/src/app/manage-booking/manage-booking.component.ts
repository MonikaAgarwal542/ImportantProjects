import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { UserdataService } from '../Services/userdata.service';


@Component({
  selector: 'app-manage-booking',
  templateUrl: './manage-booking.component.html',
  styleUrls: ['./manage-booking.component.css']
})
export class ManageBookingComponent implements OnInit {
 

  constructor(private service:UserdataService,private route:Router) { }
data:any;
show:boolean=false;
bookingdata:any;
dat:any;
dateFormat = "yyyy-MM-dd";
bookingfrom:any;
bookingto:any;
today:any;
  ngOnInit(): void {
   
  }
  
  cancelbooking(){
    this.today=new Date();
    this.today=this.formatFormDate(this.today);
    console.warn(this.today);
    if(this.today<this.bookingfrom){
      console.warn("Booking cancelled");
      this.service.deletebooking(this.searchbooking.value.Bookingreferencenumber).subscribe(res=>{
         console.log(res);
        alert("Booking deleted");
         this.route.navigateByUrl('Dashboard/Camp');
        });
    }
  
    else {
      alert("Past Bookings cannot be cancelled");
    }
  

  }

  formatFormDate(date: any) {

    this.dat =  formatDate(date, this.dateFormat,"en");    

    return this.dat;

  }
  searchbooking=new FormGroup({
    Bookingreferencenumber:new FormControl("")
    
   

  });

  search()
  {
    this.service.getcampbyrefid(this.searchbooking.value.Bookingreferencenumber).
    subscribe((res)=>{
      if(res!=null){
        this.data=res;
        this.service.getbookingbyrefid(this.searchbooking.value.Bookingreferencenumber).
        subscribe((res)=>{
          if(res!=null){
            this.bookingdata=res;
          console.warn("boking data is ",this.bookingdata);
         // this.show=true;
          this.bookingfrom=this.formatFormDate(this.bookingdata.bookingfrom);
          this.bookingto=this.formatFormDate(this.bookingdata.bookingto);
    
          }
          
          
    
        });
      console.warn("campdata is ",this.data);
      this.show=true;

      }
      else{
       this.show=false;
        alert("No Booking available");
        
      }
      

    });

   

  
  }

}


