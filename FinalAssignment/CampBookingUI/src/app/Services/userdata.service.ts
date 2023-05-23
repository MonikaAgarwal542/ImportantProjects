import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {map} from 'rxjs/operators';
import {BehaviorSubject} from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
@Injectable({
  providedIn: 'root'
})

export class UserdataService {

  constructor(private http:HttpClient) { }
  currentUser:BehaviorSubject<any>=new BehaviorSubject(null);
  jwtHelperService=new JwtHelperService();
data:any;
searchdata:any;
couponcode:any;
totalstay:any;
totalprice:number=0;
   saveuser(user:Array<String>){
    return this.http.post('http://localhost:51060/SignUp',{
      Email:user[0],
      Password:user[1],
      ConfirmPassword:user[2]
    },{
      responseType:'text'
    });
  }

  addbooking(booking:Array<String>){
    return this.http.post('http://localhost:51060/Camp/Booking',{
      Adress:booking[0],
      State:booking[1],
      Country:booking[2],
      Zipcode:booking[3],
      Cellphone:booking[4],
      Bookingreferencenumber:booking[5],
      Totalprice:booking[6],
      Totalstay:booking[7],
      Campid:booking[8],
      Userid:booking[9],
      Bookingfrom:booking[10],
      Bookingto:booking[11],
      

    },{
      responseType:'text'
    });
  }
  
  setdata(obj:any){
    this.data=obj;

  }
  getdata(){
    return this.data;
  }
  settotalprice(price:number){
    this.totalprice=price;
    console.warn("inside service api",this.totalprice);

  }
  gettotalprice(){
    console.warn("inside derive api ",this.totalprice);
    return this.totalprice;
  }

  setsearchdata(obj:any){
    this.searchdata=obj;

  }
  getsearchdata(){
    return this.searchdata;
  }

  setcouponcode(days:any){
   
    if(days>2 && days<5){
      this.couponcode="DISC1000";
    }
    else if(days>=5){
      this.couponcode="DISC1500";
    }
    else this.couponcode="nodiscount";

  }
  showdiv(days:any)
  {
    if(days<3)return false;
    else return true;
  }
  getcouponcode(){
    return this.couponcode;
  }
  settotalstay(days:any){
    this.totalstay=days;
  }
  gettotalstay(){
    return this.totalstay;
  }

  addcamp(camp:Array<String>){
    console.warn("inside api");
    return this.http.post('http://localhost:51060/Camp/AddCamp',{
      Campname:camp[0],
      Capacity:camp[1],
      Description:camp[2],
      Ratepernightforweekdays:camp[3],
      Ratepernightforweekend:camp[4],
       Availablefrom:camp[5],
       Availableto:camp[6],
      Imageurl:camp[7]
    },{
      responseType:'text'
    });
  }

  searchcamps(camp:Array<string>){
    //console.log("value of ca,p is ",camp[0]);
    var one=camp[0];
    let params = new HttpParams();
params = params.append('Availablefrom', one);
params = params.append('Availableto', camp[1]);
params = params.append('capacity', camp[2]);

    // const params1 = new HttpParams().append('Availablefrom',one);
    // const params2=new HttpParams().append("Availableto",camp[1]);
    // const params3=new HttpParams().append("Capacity",camp[2]);
    return this.http.get('http://localhost:51060/Camp/FilteredCamps',
    
      {params: params}
    
    
    );
  }
   
  updatecamp(campId:number,camp:Array<String>){
    console.warn("inside api");
    return this.http.put(`http://localhost:51060/Camp/UpdateCamp/${campId}`,{
     // CampId:campId,
      Campname:camp[0],
      Capacity:camp[1],
      Description:camp[2],
      Ratepernightforweekdays:camp[3],
      Ratepernightforweekend:camp[4],
      Availablefrom:camp[5],
      Availableto:camp[6],
      Imageurl:camp[7]
    },{
      responseType:'text'
    });
  }

  

  getallcamps(){
    return this.http.get("http://localhost:51060/Camp/AllCamps");
  }


  deletecamp(CampId:any){
    return this.http.delete(`http://localhost:51060/Camp/DeleteCamp/${CampId}`,{
      responseType:'text'
    });

  }


  getcampbyid(CampId:any){
    return this.http.get(`http://localhost:51060/Camp/getCamp/${CampId}`);

  }

  getcampbyrefid(bookrefid:string){
    return this.http.get(`http://localhost:51060/Camp/Booking/getCamp/${bookrefid}`);

  }

  
  getuser(email:string){
    return this.http.get(`http://localhost:51060/User/getUser/${email}`);

  }

  getbookingbyrefid(bookrefid:string){
    return this.http.get(`http://localhost:51060/Camp/Booking/getBooking/${bookrefid}`);

  }

  deletebooking(bookrefid:string){
    return this.http.delete(`http://localhost:51060/Camp/Booking/DeleteBooking/${bookrefid}`,{
      responseType:'text'
    });

  }

  checkuser(user:Array<String>){
    return this.http.post('http://localhost:51060/Login',{
      Email:user[0],
      Password:user[1]
     
    },{
      responseType:'text'
    });
  }
  setToken(token:string){
    localStorage.setItem("access_token",token);
    this.loadCurrentUser();
  }
  loadCurrentUser(){
    const token=localStorage.getItem("access_token");
    const userInfo=token!=null?this.jwtHelperService.decodeToken(token):null;
    const data=userInfo?{
      Email:userInfo.Email
    }:null;
    console.log(data);
    this.currentUser.next(data);
    return data?.Email;

  }
  isLoggedin():boolean{
    return localStorage.getItem("access_token")?true:false;

  }
  logout(){
    localStorage.removeItem("access_token");
  }

}
