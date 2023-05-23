import { Component, OnInit } from '@angular/core';
import { Form, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserdataService } from '../Services/userdata.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  constructor(private data:UserdataService,private route:Router) { }
  passwordsMatching: boolean = false;
  isConfirmPasswordDirty: boolean = false;
  emailPattern = "^[a-zA-Z0-9_.+-]+@[A-Za-z0-9-]+\.[a-zA-Z0-9-.]+$";
  displaymsg:string="";
  isAccountCreated:boolean=false;
  ngOnInit(): void {
  }
  isShowDivIf=false;
  toggleDisplayDivIf() {
    this.isShowDivIf = !this.isShowDivIf;
  }
  signupform=new FormGroup({
    Email:new FormControl("",[Validators.required,Validators.pattern(this.emailPattern)]),
    Password:new FormControl("",[Validators.required,Validators.minLength(5),Validators.pattern("(?=.{5,})(?=.*[@#!$%^&+=]).*")]),
    ConfirmPassword:new FormControl("",[Validators.required,Validators.minLength(5),Validators.pattern("(?=.{5,})(?=.*[@#!$%^&+=]).*")])
  });

  
  createuser(){
    this.isConfirmPasswordDirty=true;
   this.passwordsMatching=false;
    //if(this.signupform.value.Password===this.signupform.value.ConfirmPassword){
      this.passwordsMatching = true;
      this.data.saveuser([
        this.signupform.value.Email,
        this.signupform.value.Password,
        this.signupform.value.ConfirmPassword

      ]
      ).subscribe((res)=>{
        console.warn(res);
        if(res=='Success'){
          this.displaymsg="*Account created successfully";
          this.isAccountCreated=true;
          alert("Account created");
          this.route.navigateByUrl('Login');
          //this.signupform.reset();
        }else if(res=="Already Exists"){
          this.displaymsg="*EmaiId Already Exists.";
          this.isAccountCreated=false;
        }
        else{
          this.displaymsg="Something went wrong";
          this.isAccountCreated=false;
        }
      });
    // }
    // else{
    //   this.passwordsMatching = false;
    // }
    // this.data.saveuser(this.signupform.value).subscribe((result)=>{
    //   console.warn(this.signupform.value);
    //   //this.route.navigateByUrl('Teacher/AllRecords');
    // });

    

  }

}
