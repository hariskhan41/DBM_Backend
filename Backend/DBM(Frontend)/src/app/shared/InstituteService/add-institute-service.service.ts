import { Injectable } from '@angular/core';
import { AddInstituteModelClass } from "src/app/shared/InstituteModelClass/add-institute-model-class.model";
import { HttpClient } from "@angular/common/http";
@Injectable({
  providedIn: 'root'
})
export class AddInstituteServiceService {

  formData = new AddInstituteModelClass();
  readonly rootURL = 'http://localhost:3845/api';
  list: AddInstituteModelClass[];

  constructor(private http: HttpClient) { }

  postAddInstitute(formData: AddInstituteModelClass) {
    return this.http.post(this.rootURL + '/Institute', formData);
  }

  getInstitutesList() {
    this.http.get(this.rootURL + '/Institute')
    .toPromise()
    .then(res => {
      this.list = res as AddInstituteModelClass[];
      console.log(this.list);
    });
  }

}

