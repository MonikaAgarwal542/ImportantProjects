import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { StudentDataService } from '../Service/student-data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-update-records',
  templateUrl: './update-records.component.html',
  styleUrls: ['./update-records.component.css']
})
export class UpdateRecordsComponent implements OnInit {

  constructor(private data:StudentDataService,private route:ActivatedRoute,private route2:Router) { }
  result:any;
  ngOnInit(): void {
    let resultid=this.route.snapshot.paramMap.get('id');
    console.warn("id is ",resultid)
    this.data.getresult(resultid).subscribe((res)=>{
      this.result=res;
    });

  }
  updatestudentresult(ans:any){
   console.warn(ans);
   ans.id=this.result.id;
    this.data.updateresult(ans).subscribe((data)=>{
      console.warn(data);
      this.route2.navigateByUrl('Teacher/AllRecords');
    }

    );

   
  }

}
