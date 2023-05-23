import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {map} from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class StudentDataService {
  url='http://localhost:8082/allstudents';
  
  constructor(private http:HttpClient) {}
 
   studentdata(){
    return this.http.get(this.url);

  }

  saveresult(data:any){
    return this.http.post('http://localhost:8082/addstudent',data);
  }

  deleteresult(id:number){
    return this.http.delete(`http://localhost:8082/${id}`);
  }
  

  
  getresult(id:any){
    return this.http.get(`http://localhost:8082/${id}`);
  }

  getoneresult(roll:any,name:any){
    return this.http.get(`http://localhost:8082/${roll}/${name}`);
  }

  updateresult(result:any){
    return this.http.put(`http://localhost:8082/${result.id}`,result);

  }
}
