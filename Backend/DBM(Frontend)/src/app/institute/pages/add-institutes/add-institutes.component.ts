import { Component, OnInit } from '@angular/core';
import { AddInstituteServiceService } from "src/app/shared/InstituteService/add-institute-service.service";
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { NgForm, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-institutes',
  templateUrl: './add-institutes.component.html',
  styleUrls: ['./add-institutes.component.css']
})
export class AddInstitutesComponent implements OnInit {

  InstituteNameError = '';


  constructor(private service: AddInstituteServiceService, private httpService: HttpClient) {

  }


  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }
    this.service.formData = {
      InstituteName: '',
    }
  }

  onSubmit(form: NgForm) {
    this.service.postAddInstitute(form.value).subscribe(
      res => {
        this.resetForm(form);
      },
      err => {
        console.log(err);
        alert(err.error["UniqueInstituteName"]);
        this.InstituteNameError = err.error["UniqueInstituteName"];
      }
    );
  }




}
