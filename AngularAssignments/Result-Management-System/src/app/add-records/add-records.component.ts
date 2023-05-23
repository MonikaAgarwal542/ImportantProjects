import { Component, OnInit } from '@angular/core';
import { StudentDataService } from '../Service/student-data.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-add-records',
  templateUrl: './add-records.component.html',
  styleUrls: ['./add-records.component.css']
})
export class AddRecordsComponent implements OnInit {

  constructor(private data:StudentDataService,private route:Router) { }

  ngOnInit(): void {
  }
  addstudentresult(data:any){
    this.data.saveresult(data).subscribe((result)=>{
      console.warn(result);
      this.route.navigateByUrl('Teacher/AllRecords');
    }

    );
    //alert("New Result Added");
    
   
    
  }
  

}
