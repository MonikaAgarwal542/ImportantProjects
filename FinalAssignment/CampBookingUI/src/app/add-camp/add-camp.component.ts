import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserdataService } from '../Services/userdata.service';

@Component({
  selector: 'app-add-camp',
  templateUrl: './add-camp.component.html',
  styleUrls: ['./add-camp.component.css']
})
export class AddCampComponent implements OnInit {

  constructor(private data:UserdataService,private route:Router) { }

  ngOnInit(): void {
  }
  addcampform=new FormGroup({
    Campname:new FormControl("",[Validators.required]),
    Capacity:new FormControl("",[Validators.required,Validators.max(20),Validators.min(2)]),
    Description:new FormControl("",[Validators.required]),
    Ratepernightforweekdays:new FormControl("",[Validators.required,Validators.min(0)]),
    Ratepernightforweekend:new FormControl("",[Validators.required,Validators.min(0)]),
    Availablefrom:new FormControl("",[Validators.required]),
    Availableto:new FormControl("",[Validators.required]),
    Imageurl:new FormControl("",[Validators.required])
   

  });

  
  addcamp(){
      this.data.addcamp([
        this.addcampform.value.Campname,
        this.addcampform.value.Capacity,
        this.addcampform.value.Description,
        this.addcampform.value.Ratepernightforweekdays,
        this.addcampform.value.Ratepernightforweekend,
        this.addcampform.value.Availablefrom,
        this.addcampform.value.Availableto,
        this.addcampform.value.Imageurl,


      ]
      ).subscribe((res)=>{
        console.warn(res);
        if(res=='Success'){
         
          alert("Camp created");
          this.addcampform.reset();
          //this.route.navigateByUrl('Login');
          //this.signupform.reset();
        }
      });

}}
