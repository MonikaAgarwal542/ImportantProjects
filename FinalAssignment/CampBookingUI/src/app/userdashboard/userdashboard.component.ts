import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserdataService } from '../Services/userdata.service';

@Component({
  selector: 'app-userdashboard',
  templateUrl: './userdashboard.component.html',
  styleUrls: ['./userdashboard.component.css']
})
export class UserdashboardComponent implements OnInit {
list:any;
p:any;
date:any;
dat:any;
totalstay:any;
value:any;
Days:any;
show:any;
totalprice:number=0;
price:any;
Date1: any

Date2: any

minDate: any = new Date();

minDate1: any = new Date()

// dateFormat = "yyyy-MM-dd";

//   language = "en";

  constructor(private data:UserdataService,private route:Router) { }

  ngOnInit(): void {
    this.camplist();
    this.date=new Date();
    this.dat=formatDate(this.date, "dd-MM-yyyy", "en");  
    console.warn("date is ",this.dat);
    console.warn("value of checkbox is ",this.value);
    

   
  }
  searchform=new FormGroup({
    Availablefrom:new FormControl("",[Validators.required]),
    Availableto:new FormControl("",[Validators.required]),
    capacity:new FormControl("",[Validators.required])
  });

  camplist(){
    this.data.getallcamps().subscribe((result)=>{
      console.warn(result);
        this.list=result;
        console.warn("data is ",this.list);
      })

  }


setMin(){
  this.minDate1=this.Date1;
}


 
  searchcamp(){

   const Date1Modified =new Date(this.searchform.value.Availablefrom);
    const Date2Modified =new Date(this.searchform.value.Availableto);
   const Time= Date2Modified.getTime()-Date1Modified.getTime();
   this.Days=(Time/(1000*3600*24))+1;
 
  // console.warn("total stay is ",this.Days);
   this.data.searchcamps([
    this.searchform.value.Availablefrom,
  this.searchform.value.Availableto,
    this.searchform.value.capacity

   ]).subscribe((res)=>{
   // console.warn("search data is ",res);
    this.list=res;
    console.warn("length of the camps is ",this.list.length);
    this.listlength();
    
   })
  }
  listlength(){
    if(this.list.length==0){
      alert("No Camp Available.Check for another dates.");
      this.searchform.reset();
    }
    
  }


  bookcamp(item:any){
    console.warn("searced data dhjssjdysydsdj",this.searchform.value);
    this.data.setdata(item);
    this.data.setsearchdata(this.searchform.value);
    this.data.setcouponcode(this.Days);
    this.data.settotalstay(this.Days);
    this.show=this.data.showdiv(this.Days);
   // console.warn("total price is  are ",this.calculateprice());
    this.data.settotalprice(this.calculateprice());
    this.route.navigateByUrl('Dashboard/Camp/booking');

  }

  calculateprice(){
    var sDate = new Date(this.searchform.value.Availablefrom);
    var eDate = new Date(this.searchform.value.Availableto);
    var dayMap = ["Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday"];
    var dates = [];
    var campdata=this.data.getdata();
   for(var i=0;i<this.Days;i++) {
        dates.push(dayMap[new Date(sDate).getDay()]);
        sDate.setDate(sDate.getDate()+1);      
    }
    
    for(var i=0;i<this.Days;i++) {
      if(dates[i]=='Monday' || dates[i]=='Tuesday' || dates[i]=='Wednesday' || dates[i]=='Thursday' || dates[i]=='Friday'){
        this.value=campdata.ratepernightforweekdays;
      }
        else this.value=campdata.ratepernightforweekend;
      
      this.totalprice=this.totalprice+this.value
          
  }
  return this.totalprice;


  }


  onCheckboxChange(event: any) {
    if (event.target.checked) {
      this.value=true;
    }
    else this.value=false;
  }
}
