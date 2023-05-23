import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserdataService } from '../Services/userdata.service';

@Component({
  selector: 'app-booking-component',
  templateUrl: './booking-component.component.html',
  styleUrls: ['./booking-component.component.css']
})
export class BookingComponentComponent implements OnInit {

  constructor(private data:UserdataService,private route:Router) { }
campdata:any;
searchdates:any;
totalstay:any;
couponcode:any;
totalprice:any;
Bookingreferencenumber:any;
Totalprice:any;
Totalstay:any;
Campid:any;
Bookingfrom:any;
Bookingto:any;
user:any;
count:number=1;
  ngOnInit(): void {
    // console.log("insde booking cimpinntn",this.campid);
    // console.log("insde booking cimpinntn",this.searchdata); 
    this.campdata=this.data.getdata();
    this.searchdates=this.data.getsearchdata();
    this.totalstay=this.data.gettotalstay();
    
    this.couponcode=this.data.getcouponcode();
    this.totalprice=this.data.gettotalprice();
    console.log("total price in is ffdf",this.totalprice);

    //this.ans=this.data.showdiv(this.totalstay);
   
  //console.warn(this.ans);
  }

  bookingform=new FormGroup({
    Address:new FormControl("",[Validators.required]),
    State:new FormControl("",[Validators.required]),
    Country:new FormControl("",[Validators.required]),
    Zipcode:new FormControl("",[Validators.required]),
    Cellphone:new FormControl("",[Validators.required])
  });
  genUniqueId(): string {
    const dateStr = Date.now().toString(36); 
    return `${dateStr}`;
  }

  addbooking(){
    console.warn("camp data is ",this.campdata);
    console.warn("dates are",this.data.getsearchdata());
    console.warn("dates are",this.searchdates);
    this.data.getuser(this.data.loadCurrentUser()).subscribe((res)=>{
          this.user=res;
    });
    console.warn("user data is monika dsds",this.user);

    // let x = Math.floor((Math.random() * 100000000) + 1);

    // this.Bookingreferencenumber = x.toString()
    this.Bookingreferencenumber=this.genUniqueId();

    this.data.addbooking([
      this.bookingform.value.Address,
      this.bookingform.value.State,
      this.bookingform.value.Country,
      this.bookingform.value.Zipcode,
      this.bookingform.value.Cellphone,
      this.Bookingreferencenumber,
      this.totalprice,
      this.totalstay,
      this.campdata.campId,
      this.user.userId,
      this.searchdates.Availablefrom,
      this.searchdates.Availableto
    ]).subscribe((res)=>{
      alert("Booking successful.Check your mail for Reference number.");
      this.route.navigateByUrl('Dashboard/Camp');
      console.warn(res);
    });

    this.data


  }
  updateprice(){
    this.count=this.count+1;
   
    if(this.couponcode=='DISC1000' && this.totalprice>1000)this.totalprice=this.totalprice-1000;
    else if(this.couponcode=='DISC1500' && this.totalprice>1500)this.totalprice=this.totalprice-1000;
    else this.count=3;

    
  
   
  }
 

}
