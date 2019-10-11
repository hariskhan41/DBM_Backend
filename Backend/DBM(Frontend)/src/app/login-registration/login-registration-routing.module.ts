import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
//import {LoginRegistrationComponent} from './pages/login-registration.component';
import { LoginComponent } from './pages/login/login.component';
import { SignupComponent } from './pages/signup/signup.component';


const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LoginRegistrationRoutingModule { }
