import { Injectable } from '@angular/core';
import { AddInstituteModelClass } from "src/app/shared/InstituteModelClass/add-institute-model-class.model";
import { HttpClient } from "@angular/common/http";
@Injectable({
  providedIn: 'root'
})
export class AddInstituteServiceService {

  formData = new AddInstituteModelClass();
  readonly rootURL = 'http://localhost:3845/api'
  constructor(private http: HttpClient) { }
  
  postAddInstitute(formData: AddInstituteModelClass) {
    return this.http.post(this.rootURL + '/Institute', formData);
  }


}

