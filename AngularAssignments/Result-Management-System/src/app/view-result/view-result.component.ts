import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentDataService } from '../Service/student-data.service';

@Component({
  selector: 'app-view-result',
  templateUrl: './view-result.component.html',
  styleUrls: ['./view-result.component.css']
})
export class ViewResultComponent implements OnInit {

  constructor(private data:StudentDataService,private route:ActivatedRoute,private route2:Router) { }
result:any;
grade:any;
  ngOnInit(): void {
    let roll=this.route.snapshot.paramMap.get('Rollno');
    let name=this.route.snapshot.paramMap.get('Name');
    console.warn("roll number is ",roll);
    console.warn("name is ",name);
    this.data.getoneresult(roll,name).subscribe((res)=>{
      
     
      this.result=res;
      if(this.result.Score<33)this.grade="FAIL";
      else this.grade="PASS";
    });

    
  }

}
