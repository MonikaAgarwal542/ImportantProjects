import { Component, OnInit } from '@angular/core';
import { textChangeRangeIsUnchanged } from 'typescript';
import { StudentDataService } from '../Service/student-data.service';
import {Router} from '@angular/router';
@Component({
  selector: 'app-all-records',
  templateUrl: './all-records.component.html',
  styleUrls: ['./all-records.component.css']

})
export class AllRecordsComponent implements OnInit {

  students:any;
  count:number=0;
  
  constructor(private data:StudentDataService,private route:Router) {
    
   }

  ngOnInit(): void {
    this.list();
   
  }

  deletestudentresult(id:any){
    this.data.deleteresult(id).subscribe(res=>{
      
       console.log(res);
       this.list();
       this.route.navigateByUrl('Teacher/AllRecords');
       
 
      });
     
     

  }

  list(){
    this.data.studentdata().subscribe((result)=>{
        this.students=result;
        this.count=this.students.length;
    
  })

  }

  editresult(id:number){
    this.route.navigateByUrl(`Teacher/UpdateRecords/${id}`);
  }
}
