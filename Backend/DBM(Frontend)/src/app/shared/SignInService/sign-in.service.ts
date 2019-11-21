import { Injectable } from '@angular/core';
//import { SignIn } from "src/app/shared/SignInModelClass/sign-in.model";
import { HttpClient } from "@angular/common/http";
import { SignIn } from '../SignInModelClass/sign-in.model';
//import { httpClient } from "@angular/common/http";
//import { HttpClient } from 'selenium-webdriver/http';

@Injectable({
  providedIn: 'root'
})
export class SignInService {

  formData: SignIn;
  readonly rootURL = 'http://localhost:3845/api';
  public static isLoggedIn = false;

  constructor(private http: HttpClient) { }

  postLogin(formData: SignIn) {
    return this.http.post(this.rootURL + '/Users/Login', formData);
  }
}
