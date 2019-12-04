import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder, AbstractControl, ValidatorFn } from '@angular/forms';
import { of } from 'rxjs';

import { NgForm } from '@angular/forms';
import { SignUpService } from "src/app/shared/SignUpService/sign-up.service";
import { HttpClient, HttpErrorResponse } from '@angular/common/http';


export interface Designation {
  value: string;
  viewValue: string;
}

export interface institute {
  id: string;
  name: string;
}

export interface error_messages {
  EmailAddress: string;
  message: string;
}

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  form: FormGroup;
  institutes = [''];
  successfulSave: boolean;
  errors: string[];
  temp1: any;

  // constructor(private service: SignUpService) {

  // }

  constructor(private service: SignUpService, private httpService: HttpClient) {

  }

  myInstitute: institute[];
  selected = null;

  // constructor(private service: SignUpService, private formBuilder: FormBuilder) {
  //   this.form = this.formBuilder.group({
  //     institutes: ['']
  //   });
  //   //this.institutes = this.getInstitutes();

  // }

  // getInstitutes() {
  //   return this.service.getInstitutes().subscribe(p => {

  //   });
  //   // return [
  //   //   { value: '1', viewValue: 'order 1' },
  //   //   { value: '2', viewValue: 'order 2' },
  //   //   { value: '3', viewValue: 'order 3' },
  //   //   { value: '4', viewValue: 'order 4' }
  //   // ];
  // }



  ngOnInit() {

    this.resetForm();
    this.service.getInstitutes().subscribe(
      data => {
        this.myInstitute = data as institute[];
        alert(this.myInstitute[0]["id"]);
      },
      (err: HttpErrorResponse) => {
        console.log(err.message);
      }
    );
    for (let prop in this.myInstitute) {
      console.log(prop);
    }
    this.errors = [];
  }

  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }
    this.service.formData = {
      //Id: 0,
      FirstName: '',
      LastName: '',
      Cnic: '',
      Email: '',
      Password: '',
      Designation: '',
      DateOfBirth: new Date(Date.now()),
      //LoginStatus: 0,
      //ActiveStatue: 0,
      //InstituteId: 0,
      InstituteName: ''
    }
  }

  p = "";

  onSubmit(form: NgForm) {
    let error_msg: {};
    this.service.postAddUser(form.value).subscribe(
      res => {
        this.resetForm(form);
      },
      err => {
        console.log(err);
        this.temp1 = err;
        console.error(err);
        alert(this.temp1.error["EmailAddress"]);
        this.p = this.temp1.error["EmailAddress"];
      }
    );

  }

  designations: Designation[] = [
    { value: 'Teacher', viewValue: 'Teacher' },
    { value: 'Student', viewValue: 'Student' },
    { value: 'Admin', viewValue: 'Admin' },
    { value: 'SuperAdmin', viewValue: 'Super Admin' }
  ];

  // Institutes: Institute[] = [
  //   { value: 'Uet', viewValue: 'Uet' }
  // ];


  checkPasswords(group: FormGroup) { // here we have the 'passwords' group
    let pass = group.controls.password.value;
    let confirmPass = group.controls.ConfirmPassword.value;

    return pass === confirmPass ? 'Password do not match' :
      '';
  }

  FirstName = new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z \-\']+')]);
  LastName = new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z \-\']+')]);
  email = new FormControl('', [Validators.required, Validators.email, this.uniqueEmailValidator(this.p)]);
  CNIC = new FormControl('', [Validators.required, Validators.pattern('^[0-9]+$'), Validators.maxLength(13), Validators.minLength(13)]);
  DateOfBirth = new FormControl('', [Validators.required]);
  Password = new FormControl('', [Validators.required, Validators.pattern('')]);

  uniqueEmailValidator(s: string): ValidatorFn {
    return (control: AbstractControl): { [key: string]: string } | null => {
      if (s == "")
      {
        return { 'InvalidEmail': "Unique Email Error" }
      }
      return null;
    };
  }

  getErrorMessageUniqueEmail()
  {
    return this.email.hasError('uniqueEmailValidator') ? 'Unique Email Error':
    '';
  }

  getErrorMessageEmail() {
    return this.email.hasError('required') ? 'You must enter a value' :
      this.email.hasError('email') ? 'Not a valid email' :
        '';
  }

  getErrorMessageLastName() {
    return this.LastName.hasError('required') ? 'You must enter a value' :
      this.LastName.hasError('pattern') ? 'Last Name should not have numbers' :
        '';
  }

  getErrorMessageFirstName() {
    return this.FirstName.hasError('required') ? 'You must enter a value' :
      this.FirstName.hasError('pattern') ? 'First Name should not have numbers' :
        '';
  }

  getErrorMessageCNIC() {
    return this.CNIC.hasError('required') ? 'You must enter a value' :
      this.CNIC.hasError('pattern') ? 'CNIC should not have alphabets' :
        this.CNIC.hasError('maxlength') ? 'CNIC must have 13 digits' :
          this.CNIC.hasError('minlength') ? 'CNIC must have 13 digits' :
            '';
  }

  getErrorMessagePassword() {
    return this.FirstName.hasError('required') ? 'You must enter a value' :
      '';
  }

  getErrorMessageDOB() {
    return this.FirstName.hasError('required') ? 'You must enter a date' :
      '';
  }



}
