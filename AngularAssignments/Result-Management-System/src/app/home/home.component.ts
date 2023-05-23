import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor() { }
  element:any;
  logout:any;
  checkifteacher(){
    this.element=true;
    this.logout=true;
  }
  checkifstudent(){
    this.element=false;
    this.logout=true;

  }
  ngOnInit(): void {
  }

}
