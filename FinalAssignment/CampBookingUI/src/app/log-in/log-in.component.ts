import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserdataService } from '../Services/userdata.service';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {

  constructor(private data:UserdataService,private route:Router) { }
  isShowDivIf=false;
  admin:any;
  emailid:any;
  toggleDisplayDivIf() {
    this.isShowDivIf = !this.isShowDivIf;
  }
  isuservalid:boolean=false;
  ngOnInit(): void {}
  loginform=new FormGroup({
    Email:new FormControl("",[Validators.required]),
    Password:new FormControl("",[Validators.required,Validators.minLength(5),Validators.pattern("(?=.{5,})(?=.*[@#!$%^&+=]).*")]),
   
  });
value:any;
  checkuser(){
    this.data.checkuser([
      this.loginform.value.Email,
      this.loginform.value.Password,
    ]).subscribe((res)=>{
      if(res=='Failure'){
        this.isuservalid=false;
        alert("Login Unsuccessfull");
        
      }else{
        if(this.loginform.value.Email=="Admin123@gmail.com"){
          console.warn(this.loginform.value.Email);
          sessionStorage.setItem("isadmin", "true");
         
          this.admin=true;
          console.warn(this.admin);}
        else{
          this.admin=false;
          sessionStorage.setItem("isadmin", "false");

        } 
       // this.value=sessionStorage.getItem("isadmin");
        //console.warn("admin vale is ",this.value);
       this.emailid=this.loginform.value.Email;
        this.isuservalid=true;
      //  console.warn(this.admin);
       // console.warn(this.emailid);
        //alert(res);
        this.data.setToken(res);
        alert("Login successfull!!");
        this.route.navigateByUrl('Dashboard/Camp');
      
       
      }

    });
  }
  

}
