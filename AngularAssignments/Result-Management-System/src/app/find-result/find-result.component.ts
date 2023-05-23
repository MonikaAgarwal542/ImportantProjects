import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { StudentDataService } from '../Service/student-data.service';

@Component({
  selector: 'app-find-result',
  templateUrl: './find-result.component.html',
  styleUrls: ['./find-result.component.css']
})
export class FindResultComponent implements OnInit {
 
  constructor(private data:StudentDataService,private route:Router) { }
  name:any;
  result:any;
  ngOnInit(): void {
  }
  findresult(value:any){
    this.name=value.Name.replace("%2O"," ");
    console.warn(this.name);
    this.data.getoneresult(value.Rollno,this.name).subscribe((res)=>{
      
      if(res==null)alert("Result not available");
     else{
      this.route.navigateByUrl(`Student/ViewResult/${value.Rollno}/${value.Name}`);

     }
    });
    

   
    

  }
  
}
