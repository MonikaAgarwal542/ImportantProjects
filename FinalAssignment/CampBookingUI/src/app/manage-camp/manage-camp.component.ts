import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserdataService } from '../Services/userdata.service';

@Component({
  selector: 'app-manage-camp',
  templateUrl: './manage-camp.component.html',
  styleUrls: ['./manage-camp.component.css']
})
export class ManageCampComponent implements OnInit {
p:any;
  constructor(private data:UserdataService,private route:Router) { }
  list:any;
  ngOnInit(): void {
    this.camplist();
  }
  camplist(){
    this.data.getallcamps().subscribe((result)=>{
      console.warn(result);
        this.list=result;
        console.warn("data is ",this.list);
      })

  }

  deletecamp(CampId:any){
    this.data.deletecamp(CampId).subscribe(res=>{
       console.log(res);
       this.camplist();
      // alert("Camp deleted successfully");
       this.route.navigateByUrl('Dashboard/AllCamps');
      });
  }
  editcamp(CampId:number){
    this.route.navigateByUrl(`Dashboard/EditCamp/${CampId}`);
  }

}
