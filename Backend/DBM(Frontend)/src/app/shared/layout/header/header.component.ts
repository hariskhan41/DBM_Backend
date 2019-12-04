import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SignInService } from '../../SignInService/sign-in.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  userDetails;

  // LoggedIn: boolean;

  constructor(private router: Router, private service: SignInService) { }

  ngOnInit() {
    this.service.getUserProfile().subscribe(
      (res:any) => {
        this.userDetails = res;
        localStorage.setItem('Id', res.tempId);
        console.log(this.userDetails);
      },
      err => {
        console.log(err);
      }
    );
  }

  loggedIn() {
    return !!localStorage.getItem('token')
  }

  onLogout() {
    // this.LoggedIn = SignInService.isLoggedIn;
    this.userDetails = null;
    localStorage.removeItem('token');
    localStorage.removeItem('Id');
    this.router.navigate(['']);
  }

}
