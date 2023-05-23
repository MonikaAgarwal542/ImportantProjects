import { formatDate } from '@angular/common';
import { analyzeAndValidateNgModules } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserdataService } from '../Services/userdata.service';

@Component({
  selector: 'app-edit-camp',
  templateUrl: './edit-camp.component.html',
  styleUrls: ['./edit-camp.component.css']
})
export class EditCampComponent implements OnInit {

  constructor(private data:UserdataService,private route:ActivatedRoute,private route2:Router) { }
result:any;
CampId:any;
dat:any;
dateFormat = "yyyy-MM-dd";

  language = "en";
  ngOnInit(): void {
    this.CampId=this.route.snapshot.paramMap.get('CampId');
    
    console.warn("id is ",this.CampId)
    this.data.getcampbyid(this.CampId).subscribe((res)=>{

      this.result=res;
      console.warn(this.result);
     
      this.updatecampform = new FormGroup({
        Campname: new FormControl(this.result.campname),
        Imageurl: new FormControl(this.result.imageurl),
        Capacity: new FormControl(this.result.capacity),
        Description: new FormControl(this.result.description),
        Availablefrom: new FormControl(this.formatFormDate(this.result.availablefrom)),
        Availableto: new FormControl(this.formatFormDate(this.result.availableto)),
        Ratepernightforweekdays: new FormControl(this.result.ratepernightforweekdays),
        Ratepernightforweekend: new FormControl(this.result.ratepernightforweekend)
  
      })
    });
   
    
  }
  formatFormDate(date: any) {

    this.dat =  formatDate(date, this.dateFormat, this.language);    

    return this.dat;

  }

  updatecampform=new FormGroup({
    Campname:new FormControl("",[Validators.required]),
    Capacity:new FormControl("",[Validators.required]),
    Description:new FormControl("",[Validators.required]),
    Ratepernightforweekdays:new FormControl("",[Validators.required]),
    Ratepernightforweekend:new FormControl("",[Validators.required]),
    Availablefrom:new FormControl("",[Validators.required]),
    Availableto:new FormControl("",[Validators.required]),
    Imageurl:new FormControl("",[Validators.required])
   

  });


  updatecamp(){
     this.data.updatecamp(this.CampId,[
      this.updatecampform.value.Campname,
      this.updatecampform.value.Capacity,
      this.updatecampform.value.Description,
      this.updatecampform.value.Ratepernightforweekdays,
      this.updatecampform.value.Ratepernightforweekend,
      this.updatecampform.value.Availablefrom,
      this.updatecampform.value.Availableto,
      this.updatecampform.value.Imageurl,


    ]).subscribe((data)=>{
       console.warn("reason is ",data);
       this.route2.navigateByUrl('Dashboard/AllCamps');
     }
 
     );
 
    
   }

}
