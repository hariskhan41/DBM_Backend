import { Component, OnInit, VERSION } from '@angular/core';

@Component({
  selector: 'app-allcourses',
  templateUrl: './allcourses.component.html',
  styleUrls: ['./allcourses.component.css']
})
export class AllcoursesComponent implements OnInit {
  ngVersion: string = VERSION.full;
  matVersion: string = '5.1.0';
  breakpoint: number;
  constructor() { }

  ngOnInit() {
    if (window.innerWidth <= 800)
     {
       this.breakpoint = 2;
     }
     else if (window.innerWidth <= 500)
     {
       this.breakpoint = 1;
     }
     else
     {
       this.breakpoint = 4;
     }
    // this.breakpoint = (window.innerWidth <= 800 ) ? 2 :
    // (window.innerWidth <= 600) ? 1: 4;
    // this.breakpoint = (window.innerWidth <= 500) ? 1 : 4;
  }
  
   onResize(event) {
    if (event.target.innerWidth <= 670)
    {
      this.breakpoint = 1;
    }
    
     else
     {
      if (event.target.innerWidth <= 800)
      {
        this.breakpoint = 2;
      }
      else if (event.target.innerWidth <= 1100)
      {
        this.breakpoint = 3;
      }
       else
       {
        this.breakpoint = 4;
       }
       
     }
  //  this.breakpoint = (event.target.innerWidth <= 800) ? 2 :
  //  this.breakpoint =(event.target.innerWidth <= 600) ? 1:4;
  //   // this.breakpoint = (event.target.innerWidth <= 500) ? 1 : 4;
  }
 
  

}
