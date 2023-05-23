import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserdataService } from '../Services/userdata.service';
import { JwtHelperService } from '@auth0/angular-jwt';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
 admin:any;
 check:boolean=false;
  constructor(private route:Router,private data:UserdataService) {
   
   }
   value:boolean=false;
  isShowDivIf=false;
  toggleDisplayDivIf() {
    this.isShowDivIf = !this.isShowDivIf;
  }
//   @Input() admin=false;
//  @Input() emailid="";
  ngOnInit(): void {
    this.admin=sessionStorage.getItem("isadmin");
    //this.isadmin();


  }
// str=localStorage.getItem("access_token");;
//  ans=this.jwtHelper.decodeToken(this.str?this.str:undefined);
emailid=this.data.loadCurrentUser();
ans=this.emailid.split("@");


  onlogout(){
   
   // this.anstoken=this.jwtHelper.decodeToken(localStorage.getItem('access_token'));

    this.data.logout();
    this.route.navigateByUrl('Login');

    //console.warn(this.admin);
    //console.warn(this.data.getToken(key));
  }
 
  
  isadmin(){
    //console.warn(localStorage.getItem("access_token"));
  //  console.log("admin is ",sessionStorage.getItem("isadmin"));

return sessionStorage.getItem("isadmin");

    
  }

}
