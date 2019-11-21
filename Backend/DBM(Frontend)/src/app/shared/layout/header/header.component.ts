import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SignInService } from '../../SignInService/sign-in.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  LoggedIn: boolean;

  constructor(private router:Router) { }

  ngOnInit() {
  }

  onLogout() {
    this.LoggedIn = SignInService.isLoggedIn;
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }

}
